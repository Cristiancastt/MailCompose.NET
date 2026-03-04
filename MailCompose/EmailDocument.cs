using MailCompose.Nodes;

namespace MailCompose;

/// <summary>
/// Documento de email resultante de Email.Compose().
/// Contiene el árbol de nodos y puede renderizarse a HTML.
/// </summary>
public sealed class EmailDocument
{
    /// <summary>
    /// Nodo raíz del árbol de composición.
    /// </summary>
    public EmailNode Root { get; }

    /// <summary>
    /// Configuración del documento (tema, fuente base, etc.).
    /// </summary>
    public EmailTheme Theme { get; set; } = EmailTheme.Default;

    internal EmailDocument(EmailNode root)
    {
        Root = root;
    }

    /// <summary>
    /// Renderiza el email a HTML completo (con DOCTYPE, html, body).
    /// </summary>
    public string Render(bool pretty = false)
    {
        var writer = new HtmlWriter(pretty);

        writer.WriteRaw("<!DOCTYPE html>");
        writer.WriteOpenTag("html", attributes: "xmlns=\"http://www.w3.org/1999/xhtml\"");
        writer.WriteOpenTag("head");
        writer.WriteRaw("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />");
        writer.WriteRaw("<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />");
        writer.WriteRaw($"<title>{HtmlWriter.HtmlEncode(Theme.Title)}</title>");

        // Reset CSS para email
        writer.WriteRaw(@"<style type=""text/css"">
body, table, td, p, a, li, blockquote { -webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; }
table, td { mso-table-lspace: 0pt; mso-table-rspace: 0pt; }
img { -ms-interpolation-mode: bicubic; border: 0; outline: none; text-decoration: none; }
body { margin: 0; padding: 0; width: 100% !important; }
</style>");

        writer.WriteCloseTag("head");

        // Body
        var bodyStyle = $"margin:0;padding:0;background-color:{Theme.BodyBackground};" +
                        $"font-family:{Theme.FontFamily};font-size:{Theme.BaseFontSize}px;" +
                        $"color:{Theme.BaseTextColor};line-height:{Theme.BaseLineHeight};";
        writer.WriteOpenTag("body", bodyStyle);

        // Wrapper table (centrado, max-width)
        writer.WriteOpenTag("table",
            $"width:100%;border-collapse:collapse;background-color:{Theme.BodyBackground};",
            "role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\"");
        writer.WriteOpenTag("tr");
        writer.WriteOpenTag("td", "text-align:center;");

        // Container principal
        var containerStyle = $"max-width:{Theme.ContentMaxWidth}px;margin:0 auto;" +
                             $"background-color:{Theme.ContentBackground};" +
                             (Theme.ContentBorderRadius > 0 ? $"border-radius:{Theme.ContentBorderRadius}px;" : "") +
                             (Theme.ContentPadding > 0 ? $"padding:{Theme.ContentPadding}px;" : "") +
                             "text-align:left;";
        writer.WriteOpenTag("table",
            $"width:100%;max-width:{Theme.ContentMaxWidth}px;border-collapse:collapse;" +
            $"background-color:{Theme.ContentBackground};" +
            (Theme.ContentBorderRadius > 0 ? $"border-radius:{Theme.ContentBorderRadius}px;" : ""),
            "role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" align=\"center\"");
        writer.WriteOpenTag("tr");
        writer.WriteOpenTag("td", $"padding:{Theme.ContentPadding}px;text-align:left;");

        // Renderizar el árbol
        Root.Render(writer);

        // Footer (si existe)
        if (!string.IsNullOrEmpty(Theme.FooterText))
        {
            writer.WriteRaw($"<hr style=\"border:none;border-top:1px solid {TailwindColors.Gray200};margin:24px 0;\" />");
            writer.WriteOpenTag("p",
                $"font-size:12px;color:{TailwindColors.Gray400};text-align:center;margin:0;");
            writer.WriteEncoded(Theme.FooterText);
            writer.WriteCloseTag("p");
        }

        writer.WriteCloseTag("td");
        writer.WriteCloseTag("tr");
        writer.WriteCloseTag("table");

        writer.WriteCloseTag("td");
        writer.WriteCloseTag("tr");
        writer.WriteCloseTag("table");

        writer.WriteCloseTag("body");
        writer.WriteCloseTag("html");

        return writer.ToString();
    }

    /// <summary>
    /// Renderiza solo el cuerpo (sin DOCTYPE ni wrappers).
    /// Útil para inyectar en templates existentes.
    /// </summary>
    public string RenderBody(bool pretty = false)
    {
        var writer = new HtmlWriter(pretty);
        Root.Render(writer);
        return writer.ToString();
    }

    /// <summary>
    /// Devuelve la representación en texto del árbol (debug).
    /// </summary>
    public string DumpTree() => Root.DumpTree();

    /// <summary>
    /// Configura el tema del documento.
    /// </summary>
    public EmailDocument WithTheme(EmailTheme theme)
    {
        Theme = theme;
        return this;
    }

    /// <summary>
    /// Configura el tema con un builder fluent.
    /// </summary>
    public EmailDocument WithTheme(Action<EmailTheme> configure)
    {
        var theme = EmailTheme.Default;
        configure(theme);
        Theme = theme;
        return this;
    }
}
