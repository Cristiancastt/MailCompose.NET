namespace MailCompose.Editor;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        this.splitMain = new SplitContainer();
        this.toolStrip = new ToolStrip();
        this.lblTemplate = new ToolStripLabel();
        this.cboTemplates = new ToolStripComboBox();
        this.btnReload = new ToolStripButton();
        this.btnSave = new ToolStripButton();
        this.btnSaveAs = new ToolStripButton();
        this.btnRemove = new ToolStripButton();
        this.toolStripSeparator1 = new ToolStripSeparator();
        this.btnCopyHtml = new ToolStripButton();
        this.btnExportHtml = new ToolStripButton();
        this.panelEditor = new Panel();
        this.txtCode = new RichTextBox();
        this.statusStrip = new StatusStrip();
        this.lblStatus = new ToolStripStatusLabel();
        this.lblCharCount = new ToolStripStatusLabel();
        this.webPreview = new WebBrowser();
        this.panelPreviewHeader = new Panel();
        this.lblPreviewTitle = new Label();
        this.btnToggleView = new Button();

        ((System.ComponentModel.ISupportInitialize)this.splitMain).BeginInit();
        this.splitMain.Panel1.SuspendLayout();
        this.splitMain.Panel2.SuspendLayout();
        this.splitMain.SuspendLayout();
        this.toolStrip.SuspendLayout();
        this.statusStrip.SuspendLayout();
        this.SuspendLayout();

        // ── splitMain ──────────────────────────────────────────
        this.splitMain.Dock = DockStyle.Fill;
        this.splitMain.SplitterWidth = 6;
        this.splitMain.SplitterDistance = 580;
        this.splitMain.BackColor = Color.FromArgb(30, 30, 30);

        // ── Panel1 (Editor) ─────────────────────────────────────
        this.splitMain.Panel1.Controls.Add(this.panelEditor);
        this.splitMain.Panel1.Controls.Add(this.toolStrip);
        this.splitMain.Panel1.Controls.Add(this.statusStrip);
        this.splitMain.Panel1.BackColor = Color.FromArgb(30, 30, 30);

        // ── Panel2 (Preview) ────────────────────────────────────
        this.splitMain.Panel2.Controls.Add(this.webPreview);
        this.splitMain.Panel2.Controls.Add(this.panelPreviewHeader);

        // ── toolStrip ──────────────────────────────────────────
        this.toolStrip.BackColor = Color.FromArgb(37, 37, 38);
        this.toolStrip.ForeColor = Color.FromArgb(204, 204, 204);
        this.toolStrip.GripStyle = ToolStripGripStyle.Hidden;
        this.toolStrip.Padding = new Padding(8, 4, 8, 4);
        this.toolStrip.RenderMode = ToolStripRenderMode.System;
        this.toolStrip.Items.AddRange(new ToolStripItem[] {
            this.lblTemplate,
            this.cboTemplates,
            this.btnReload,
            this.btnSave,
            this.btnSaveAs,
            this.btnRemove,
            this.toolStripSeparator1,
            this.btnCopyHtml,
            this.btnExportHtml
        });

        // ── lblTemplate ────────────────────────────────────────
        this.lblTemplate.Text = "📄 Template:";
        this.lblTemplate.ForeColor = Color.FromArgb(180, 180, 180);

        // ── cboTemplates ───────────────────────────────────────
        this.cboTemplates.Size = new Size(200, 25);
        this.cboTemplates.BackColor = Color.FromArgb(60, 60, 60);
        this.cboTemplates.ForeColor = Color.White;
        this.cboTemplates.DropDownStyle = ComboBoxStyle.DropDownList;
        this.cboTemplates.SelectedIndexChanged += new EventHandler(this.cboTemplates_SelectedIndexChanged);

        // ── Buttons ────────────────────────────────────────────
        this.btnReload.Text = "↻ Reload";
        this.btnReload.ForeColor = Color.FromArgb(204, 204, 204);
        this.btnReload.Click += new EventHandler(this.btnReload_Click);

        this.btnSave.Text = "💾 Save";
        this.btnSave.ForeColor = Color.FromArgb(204, 204, 204);
        this.btnSave.Click += new EventHandler(this.btnSave_Click);

        this.btnSaveAs.Text = "📋 Save As";
        this.btnSaveAs.ForeColor = Color.FromArgb(204, 204, 204);
        this.btnSaveAs.Click += new EventHandler(this.btnSaveAs_Click);

        this.btnRemove.Text = "🗑 Remove";
        this.btnRemove.ForeColor = Color.FromArgb(204, 204, 204);
        this.btnRemove.Click += new EventHandler(this.btnRemove_Click);

        this.toolStripSeparator1.ForeColor = Color.FromArgb(60, 60, 60);

        this.btnCopyHtml.Text = "📄 Copy HTML";
        this.btnCopyHtml.ForeColor = Color.FromArgb(204, 204, 204);
        this.btnCopyHtml.Click += new EventHandler(this.btnCopyHtml_Click);

        this.btnExportHtml.Text = "📤 Export";
        this.btnExportHtml.ForeColor = Color.FromArgb(204, 204, 204);
        this.btnExportHtml.Click += new EventHandler(this.btnExportHtml_Click);

        // ── panelEditor ────────────────────────────────────────
        this.panelEditor.Dock = DockStyle.Fill;
        this.panelEditor.Padding = new Padding(0);
        this.panelEditor.Controls.Add(this.txtCode);

        // ── txtCode (RichTextBox) ──────────────────────────────
        this.txtCode.Dock = DockStyle.Fill;
        this.txtCode.BackColor = Color.FromArgb(30, 30, 30);
        this.txtCode.ForeColor = Color.FromArgb(212, 212, 212);
        this.txtCode.Font = new Font("Cascadia Code", 11F, FontStyle.Regular, GraphicsUnit.Point);
        this.txtCode.BorderStyle = BorderStyle.None;
        this.txtCode.AcceptsTab = true;
        this.txtCode.WordWrap = false;
        this.txtCode.ScrollBars = RichTextBoxScrollBars.Both;
        this.txtCode.DetectUrls = false;
        this.txtCode.TextChanged += new EventHandler(this.txtCode_TextChanged);

        // ── statusStrip ────────────────────────────────────────
        this.statusStrip.BackColor = Color.FromArgb(0, 122, 204);
        this.statusStrip.SizingGrip = false;
        this.statusStrip.Items.AddRange(new ToolStripItem[] {
            this.lblStatus,
            this.lblCharCount
        });

        this.lblStatus.Text = "Ready";
        this.lblStatus.ForeColor = Color.White;
        this.lblStatus.Spring = true;
        this.lblStatus.TextAlign = ContentAlignment.MiddleLeft;

        this.lblCharCount.Text = "0 chars";
        this.lblCharCount.ForeColor = Color.White;

        // ── panelPreviewHeader ─────────────────────────────────
        this.panelPreviewHeader.Dock = DockStyle.Top;
        this.panelPreviewHeader.Height = 36;
        this.panelPreviewHeader.BackColor = Color.FromArgb(37, 37, 38);
        this.panelPreviewHeader.Padding = new Padding(10, 6, 10, 6);
        this.panelPreviewHeader.Controls.Add(this.btnToggleView);
        this.panelPreviewHeader.Controls.Add(this.lblPreviewTitle);

        this.lblPreviewTitle.Text = "📧 Preview";
        this.lblPreviewTitle.ForeColor = Color.FromArgb(204, 204, 204);
        this.lblPreviewTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        this.lblPreviewTitle.Dock = DockStyle.Left;
        this.lblPreviewTitle.AutoSize = true;
        this.lblPreviewTitle.Padding = new Padding(0, 3, 0, 0);

        this.btnToggleView.Text = "🔍 Source";
        this.btnToggleView.Dock = DockStyle.Right;
        this.btnToggleView.FlatStyle = FlatStyle.Flat;
        this.btnToggleView.FlatAppearance.BorderColor = Color.FromArgb(60, 60, 60);
        this.btnToggleView.ForeColor = Color.FromArgb(180, 180, 180);
        this.btnToggleView.BackColor = Color.FromArgb(50, 50, 50);
        this.btnToggleView.Font = new Font("Segoe UI", 8F);
        this.btnToggleView.Size = new Size(90, 26);
        this.btnToggleView.Click += new EventHandler(this.btnToggleView_Click);

        // ── webPreview ─────────────────────────────────────────
        this.webPreview.Dock = DockStyle.Fill;
        this.webPreview.ScriptErrorsSuppressed = true;
        this.webPreview.IsWebBrowserContextMenuEnabled = false;

        // ── Form ───────────────────────────────────────────────
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(1400, 700);
        this.Controls.Add(this.splitMain);
        this.Text = "MailCompose.NET Editor";
        this.BackColor = Color.FromArgb(30, 30, 30);
        this.StartPosition = FormStartPosition.CenterScreen;

        this.splitMain.Panel1.ResumeLayout(false);
        this.splitMain.Panel1.PerformLayout();
        this.splitMain.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)this.splitMain).EndInit();
        this.splitMain.ResumeLayout(false);
        this.toolStrip.ResumeLayout(false);
        this.toolStrip.PerformLayout();
        this.statusStrip.ResumeLayout(false);
        this.statusStrip.PerformLayout();
        this.ResumeLayout(false);
    }

    #endregion

    private SplitContainer splitMain;
    private ToolStrip toolStrip;
    private ToolStripLabel lblTemplate;
    private ToolStripComboBox cboTemplates;
    private ToolStripButton btnReload;
    private ToolStripButton btnSave;
    private ToolStripButton btnSaveAs;
    private ToolStripButton btnRemove;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripButton btnCopyHtml;
    private ToolStripButton btnExportHtml;
    private Panel panelEditor;
    private RichTextBox txtCode;
    private StatusStrip statusStrip;
    private ToolStripStatusLabel lblStatus;
    private ToolStripStatusLabel lblCharCount;
    private WebBrowser webPreview;
    private Panel panelPreviewHeader;
    private Label lblPreviewTitle;
    private Button btnToggleView;
}
