using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System.Text;

namespace MailCompose.Editor;

public partial class MainForm : Form
{
    // ── State ────────────────────────────────────────────────────
    private string _lastHtml = "";
    private bool _showingSource = false;
    private CancellationTokenSource? _cts;
    private readonly System.Windows.Forms.Timer _evalTimer;       // Roslyn evaluation debounce
    private readonly System.Windows.Forms.Timer _highlightTimer;  // Syntax highlighting debounce
    private bool _highlightPending;                                // Pending highlight flag
    private static readonly string TemplatesDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates");

    // ── C# Keywords para syntax highlighting ─────────────────────
    private static readonly HashSet<string> CSharpKeywords = new(StringComparer.Ordinal)
    {
        "abstract", "as", "base", "bool", "break", "byte", "case", "catch",
        "char", "checked", "class", "const", "continue", "decimal", "default",
        "delegate", "do", "double", "else", "enum", "event", "explicit",
        "extern", "false", "finally", "fixed", "float", "for", "foreach",
        "goto", "if", "implicit", "in", "int", "interface", "internal",
        "is", "lock", "long", "namespace", "new", "null", "object",
        "operator", "out", "override", "params", "private", "protected",
        "public", "readonly", "ref", "return", "sbyte", "sealed", "short",
        "sizeof", "stackalloc", "static", "string", "struct", "switch",
        "this", "throw", "true", "try", "typeof", "uint", "ulong",
        "unchecked", "unsafe", "ushort", "using", "var", "virtual", "void",
        "volatile", "while", "async", "await", "dynamic", "nameof", "when",
        "yield", "record", "init", "required", "global"
    };

    private static readonly HashSet<string> ComposeKeywords = new(StringComparer.Ordinal)
    {
        "Email", "TailwindColors", "EmailTheme", "TextAlign", "FontWeight"
    };

    // ── Roslyn ScriptOptions ─────────────────────────────────────
    private ScriptOptions? _scriptOptions;

    private ScriptOptions GetScriptOptions()
    {
        return _scriptOptions ??= ScriptOptions.Default
            .WithReferences(
                typeof(Email).Assembly,
                typeof(object).Assembly,
                typeof(Enumerable).Assembly
            )
            .WithImports(
                "System",
                "System.Linq",
                "System.Collections.Generic",
                "MailCompose",
                "MailCompose.Nodes"
            );
    }

    // ══════════════════════════════════════════════════════════════
    // Constructor
    // ══════════════════════════════════════════════════════════════
    public MainForm()
    {
        InitializeComponent();

        // Evaluation timer: evalúa Roslyn tras 600ms sin teclear
        _evalTimer = new System.Windows.Forms.Timer { Interval = 600 };
        _evalTimer.Tick += async (s, e) =>
        {
            _evalTimer.Stop();
            await EvaluateCodeAsync();
        };

        // Highlight timer: re-colorea tras 800ms sin teclear
        _highlightTimer = new System.Windows.Forms.Timer { Interval = 800 };
        _highlightTimer.Tick += (s, e) =>
        {
            _highlightTimer.Stop();
            if (_highlightPending)
            {
                _highlightPending = false;
                ApplySyntaxHighlightingFrozen();
            }
        };

        // Asegurar que existe la carpeta de templates
        Directory.CreateDirectory(TemplatesDir);

        LoadTemplateList();

        // Cargar el primer template si existe
        if (cboTemplates.Items.Count > 0)
            cboTemplates.SelectedIndex = 0;
    }

    // ══════════════════════════════════════════════════════════════
    // Template Management
    // ══════════════════════════════════════════════════════════════

    private void LoadTemplateList()
    {
        cboTemplates.Items.Clear();

        if (!Directory.Exists(TemplatesDir)) return;

        var templates = Directory.EnumerateFiles(TemplatesDir, "*.txt")
            .Select(Path.GetFileNameWithoutExtension)
            .Where(n => n != null && !n.StartsWith("_"))
            .OrderBy(n => n)
            .ToArray();

        foreach (var t in templates)
            cboTemplates.Items.Add(t!);
    }

    private void cboTemplates_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (cboTemplates.SelectedItem is string name)
            LoadTemplate(name);
    }

    private void LoadTemplate(string name)
    {
        var path = Path.Combine(TemplatesDir, name + ".txt");
        if (File.Exists(path))
        {
            SetCodeWithoutEvent(File.ReadAllText(path));
            lblStatus.Text = $"Loaded: {name}";
        }
    }

    private void btnReload_Click(object? sender, EventArgs e)
    {
        if (cboTemplates.SelectedItem is string name)
            LoadTemplate(name);
    }

    private void btnSave_Click(object? sender, EventArgs e)
    {
        if (cboTemplates.SelectedItem is not string name || string.IsNullOrWhiteSpace(name))
        {
            MessageBox.Show("Select a template first.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        File.WriteAllText(Path.Combine(TemplatesDir, name + ".txt"), txtCode.Text);
        lblStatus.Text = $"Saved: {name}";
    }

    private void btnSaveAs_Click(object? sender, EventArgs e)
    {
        var name = PromptInput("Save As...", "Enter template name:");
        if (name == null) return;

        File.WriteAllText(Path.Combine(TemplatesDir, name + ".txt"), txtCode.Text);
        LoadTemplateList();
        cboTemplates.SelectedItem = name;
        lblStatus.Text = $"Saved: {name}";
    }

    private void btnRemove_Click(object? sender, EventArgs e)
    {
        if (cboTemplates.SelectedItem is not string name) return;

        var result = MessageBox.Show($"Remove template '{name}'?", "Confirm",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            var path = Path.Combine(TemplatesDir, name + ".txt");
            if (File.Exists(path)) File.Delete(path);
            LoadTemplateList();
            txtCode.Clear();
            lblStatus.Text = $"Removed: {name}";
        }
    }

    // ══════════════════════════════════════════════════════════════
    // Code Editing & Evaluation
    // ══════════════════════════════════════════════════════════════

    private bool _suppressTextChanged;

    private void txtCode_TextChanged(object? sender, EventArgs e)
    {
        if (_suppressTextChanged) return;

        lblCharCount.Text = $"{txtCode.TextLength} chars";

        // Restart eval timer (Roslyn)
        _evalTimer.Stop();
        _evalTimer.Start();

        // Schedule highlight (separate, longer debounce)
        _highlightPending = true;
        _highlightTimer.Stop();
        _highlightTimer.Start();
    }

    private async Task EvaluateCodeAsync()
    {
        // Cancelar evaluación anterior
        _cts?.Cancel();
        _cts = new CancellationTokenSource();
        var token = _cts.Token;

        var code = txtCode.Text;
        if (string.IsNullOrWhiteSpace(code))
        {
            webPreview.DocumentText = BlankHtml();
            lblStatus.Text = "Empty";
            return;
        }

        lblStatus.Text = "⏳ Evaluating...";
        statusStrip.BackColor = Color.FromArgb(0, 122, 204);

        try
        {
            // Leer header/footer
            var header = ReadTemplateFile("_Header.txt");
            var footer = ReadTemplateFile("_Footer.txt");
            var fullCode = header + code + footer;

            var result = await CSharpScript.EvaluateAsync<string>(
                fullCode,
                GetScriptOptions(),
                cancellationToken: token);

            if (token.IsCancellationRequested) return;

            _lastHtml = result ?? "";
            if (_showingSource)
                ShowHtmlSource();
            else
                webPreview.DocumentText = _lastHtml;

            lblStatus.Text = "✅ OK";
            statusStrip.BackColor = Color.FromArgb(22, 163, 74); // green-600
        }
        catch (OperationCanceledException)
        {
            // Ignorar si fue cancelada
        }
        catch (CompilationErrorException ex)
        {
            if (token.IsCancellationRequested) return;

            var errors = string.Join("<br/>", ex.Diagnostics.Select(d => d.ToString()));
            webPreview.DocumentText = ErrorHtml("Compilation Error", errors);
            lblStatus.Text = "❌ Compilation error";
            statusStrip.BackColor = Color.FromArgb(220, 38, 38); // red-600
        }
        catch (Exception ex)
        {
            if (token.IsCancellationRequested) return;

            webPreview.DocumentText = ErrorHtml("Runtime Error", HtmlEncode(ex.Message));
            lblStatus.Text = "❌ Runtime error";
            statusStrip.BackColor = Color.FromArgb(220, 38, 38);
        }
    }

    private static string ReadTemplateFile(string fileName)
    {
        var path = Path.Combine(TemplatesDir, fileName);
        return File.Exists(path) ? File.ReadAllText(path) : "";
    }

    // ══════════════════════════════════════════════════════════════
    // Syntax Highlighting (flicker-free)
    // ══════════════════════════════════════════════════════════════

    /// <summary>
    /// Applies syntax highlighting with WM_SETREDRAW trick to prevent
    /// all visual flickering. The RichTextBox is completely frozen
    /// during the re-coloring pass.
    /// </summary>
    private void ApplySyntaxHighlightingFrozen()
    {
        if (txtCode.TextLength == 0) return;

        _suppressTextChanged = true;

        // Save state
        var selStart = txtCode.SelectionStart;
        var selLen = txtCode.SelectionLength;
        var scrollPos = GetScrollPos();

        // ── FREEZE painting ──────────────────────────────────
        SendMessage(txtCode.Handle, WM_SETREDRAW, 0, 0);

        try
        {
            // Reset all to default color
            txtCode.SelectAll();
            txtCode.SelectionColor = Color.FromArgb(212, 212, 212);

            var text = txtCode.Text;
            var i = 0;

            while (i < text.Length)
            {
                // ── Interpolated strings $"..." ──────────────
                if (i + 1 < text.Length && text[i] == '$' && text[i + 1] == '"')
                {
                    var start = i;
                    i += 2;
                    var depth = 0;
                    while (i < text.Length)
                    {
                        if (text[i] == '\\') { i += 2; continue; }
                        if (text[i] == '{') depth++;
                        else if (text[i] == '}') { if (depth > 0) depth--; }
                        else if (text[i] == '"' && depth == 0) { i++; break; }
                        i++;
                    }
                    ColorRange(start, i - start, Color.FromArgb(206, 145, 120));
                    continue;
                }

                // ── Strings ──────────────────────────────────
                if (text[i] == '"')
                {
                    var start = i;
                    i++;
                    while (i < text.Length && text[i] != '"')
                    {
                        if (text[i] == '\\') i++;
                        i++;
                    }
                    if (i < text.Length) i++;
                    ColorRange(start, i - start, Color.FromArgb(206, 145, 120));
                    continue;
                }

                // ── Line comments ────────────────────────────
                if (i + 1 < text.Length && text[i] == '/' && text[i + 1] == '/')
                {
                    var start = i;
                    while (i < text.Length && text[i] != '\n') i++;
                    ColorRange(start, i - start, Color.FromArgb(106, 153, 85));
                    continue;
                }

                // ── Numbers ──────────────────────────────────
                if (char.IsDigit(text[i]) && (i == 0 || !char.IsLetterOrDigit(text[i - 1])))
                {
                    var start = i;
                    while (i < text.Length && (char.IsDigit(text[i]) || text[i] == '.' || text[i] == 'm'))
                        i++;
                    ColorRange(start, i - start, Color.FromArgb(181, 206, 168));
                    continue;
                }

                // ── Identifiers / keywords ───────────────────
                if (char.IsLetter(text[i]) || text[i] == '_')
                {
                    var start = i;
                    while (i < text.Length && (char.IsLetterOrDigit(text[i]) || text[i] == '_'))
                        i++;

                    var word = text[start..i];

                    if (CSharpKeywords.Contains(word))
                        ColorRange(start, i - start, Color.FromArgb(86, 156, 214));
                    else if (ComposeKeywords.Contains(word))
                        ColorRange(start, i - start, Color.FromArgb(78, 201, 176));
                    else if (word.StartsWith("ctx"))
                        ColorRange(start, i - start, Color.FromArgb(156, 220, 254));
                    continue;
                }

                // ── Method calls after dot ───────────────────
                if (text[i] == '.')
                {
                    i++;
                    if (i < text.Length && char.IsLetter(text[i]))
                    {
                        var start = i;
                        while (i < text.Length && (char.IsLetterOrDigit(text[i]) || text[i] == '_'))
                            i++;
                        ColorRange(start, i - start, Color.FromArgb(220, 220, 170));
                    }
                    continue;
                }

                i++;
            }

            // Restore cursor position
            txtCode.SelectionStart = selStart;
            txtCode.SelectionLength = selLen;
        }
        finally
        {
            // ── UNFREEZE painting ────────────────────────────
            SendMessage(txtCode.Handle, WM_SETREDRAW, 1, 0);

            // Restore scroll position
            SetScrollPos(scrollPos);

            // Force a single repaint
            txtCode.Invalidate();

            _suppressTextChanged = false;
        }
    }

    private void ColorRange(int start, int length, Color color)
    {
        if (length <= 0 || start + length > txtCode.TextLength) return;
        txtCode.Select(start, length);
        txtCode.SelectionColor = color;
    }

    // ══════════════════════════════════════════════════════════════
    // Win32 helpers for flicker-free RichTextBox
    // ══════════════════════════════════════════════════════════════

    private const int WM_SETREDRAW = 0x000B;
    private const int WM_USER = 0x0400;
    private const int EM_GETSCROLLPOS = WM_USER + 221;
    private const int EM_SETSCROLLPOS = WM_USER + 222;

    [System.Runtime.InteropServices.DllImport("user32.dll")]
    private static extern nint SendMessage(nint hWnd, int msg, int wParam, int lParam);

    [System.Runtime.InteropServices.DllImport("user32.dll")]
    private static extern nint SendMessage(nint hWnd, int msg, int wParam, ref Point lParam);

    private Point GetScrollPos()
    {
        var pt = Point.Empty;
        SendMessage(txtCode.Handle, EM_GETSCROLLPOS, 0, ref pt);
        return pt;
    }

    private void SetScrollPos(Point pt)
    {
        SendMessage(txtCode.Handle, EM_SETSCROLLPOS, 0, ref pt);
    }

    // ══════════════════════════════════════════════════════════════
    // Preview Toggle
    // ══════════════════════════════════════════════════════════════

    private void btnToggleView_Click(object? sender, EventArgs e)
    {
        _showingSource = !_showingSource;
        if (_showingSource)
        {
            btnToggleView.Text = "👁 Preview";
            ShowHtmlSource();
        }
        else
        {
            btnToggleView.Text = "🔍 Source";
            webPreview.DocumentText = _lastHtml;
        }
    }

    private void ShowHtmlSource()
    {
        var escaped = HtmlEncode(_lastHtml);
        webPreview.DocumentText =
            "<html><body style='background:#1e1e1e;color:#d4d4d4;font-family:Cascadia Code,Consolas,monospace;" +
            "font-size:13px;padding:16px;white-space:pre-wrap;word-wrap:break-word;'>" +
            escaped + "</body></html>";
    }

    // ══════════════════════════════════════════════════════════════
    // Copy / Export
    // ══════════════════════════════════════════════════════════════

    private void btnCopyHtml_Click(object? sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(_lastHtml))
        {
            Clipboard.SetText(_lastHtml);
            lblStatus.Text = "📋 HTML copied to clipboard";
        }
    }

    private void btnExportHtml_Click(object? sender, EventArgs e)
    {
        using var dlg = new SaveFileDialog
        {
            Filter = "HTML Files|*.html|All Files|*.*",
            DefaultExt = "html",
            FileName = (cboTemplates.SelectedItem as string ?? "email") + ".html"
        };

        if (dlg.ShowDialog() == DialogResult.OK)
        {
            File.WriteAllText(dlg.FileName, _lastHtml);
            lblStatus.Text = $"Exported: {dlg.FileName}";
        }
    }

    // ══════════════════════════════════════════════════════════════
    // Helpers
    // ══════════════════════════════════════════════════════════════

    private void SetCodeWithoutEvent(string code)
    {
        _suppressTextChanged = true;
        txtCode.Text = code;
        _suppressTextChanged = false;
        lblCharCount.Text = $"{txtCode.TextLength} chars";

        // Trigger evaluation + highlighting
        ApplySyntaxHighlightingFrozen();
        _ = EvaluateCodeAsync();
    }

    private static string? PromptInput(string title, string label)
    {
        var form = new Form
        {
            Text = title,
            ClientSize = new Size(400, 120),
            FormBorderStyle = FormBorderStyle.FixedDialog,
            StartPosition = FormStartPosition.CenterParent,
            MinimizeBox = false,
            MaximizeBox = false,
            BackColor = Color.FromArgb(37, 37, 38)
        };

        var lbl = new Label
        {
            Text = label,
            ForeColor = Color.FromArgb(204, 204, 204),
            Location = new Point(12, 15),
            AutoSize = true
        };

        var txt = new TextBox
        {
            Location = new Point(12, 40),
            Size = new Size(370, 25),
            BackColor = Color.FromArgb(60, 60, 60),
            ForeColor = Color.White
        };

        var btnOk = new Button
        {
            Text = "OK",
            DialogResult = DialogResult.OK,
            Location = new Point(226, 78),
            Size = new Size(75, 28),
            BackColor = Color.FromArgb(0, 122, 204),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat
        };

        var btnCancel = new Button
        {
            Text = "Cancel",
            DialogResult = DialogResult.Cancel,
            Location = new Point(307, 78),
            Size = new Size(75, 28),
            ForeColor = Color.FromArgb(204, 204, 204),
            FlatStyle = FlatStyle.Flat
        };

        form.Controls.AddRange([lbl, txt, btnOk, btnCancel]);
        form.AcceptButton = btnOk;
        form.CancelButton = btnCancel;

        return form.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(txt.Text)
            ? txt.Text.Trim()
            : null;
    }

    private static string ErrorHtml(string title, string body)
    {
        return $"""
            <html><body style='background:#1e1e1e;color:#f87171;font-family:Segoe UI,sans-serif;padding:24px;'>
            <h2 style='color:#fca5a5;margin:0 0 12px 0;'>❌ {title}</h2>
            <pre style='color:#fca5a5;white-space:pre-wrap;font-size:13px;font-family:Cascadia Code,Consolas,monospace;'>{body}</pre>
            </body></html>
            """;
    }

    private static string BlankHtml()
    {
        return """
            <html><body style='background:#1e1e1e;color:#6b7280;font-family:Segoe UI,sans-serif;
            display:flex;align-items:center;justify-content:center;height:100vh;margin:0;'>
            <div style='text-align:center;'>
            <p style='font-size:48px;margin:0;'>📧</p>
            <p style='font-size:16px;margin:8px 0 0 0;'>Write code to preview your email</p>
            </div>
            </body></html>
            """;
    }

    private static string HtmlEncode(string text)
    {
        return text
            .Replace("&", "&amp;")
            .Replace("<", "&lt;")
            .Replace(">", "&gt;")
            .Replace("\"", "&quot;");
    }
}
