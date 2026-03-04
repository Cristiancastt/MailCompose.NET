using System.Text;

namespace MailCompose;

/// <summary>
/// Writer de HTML email-safe. Genera HTML con tablas e inline styles,
/// escapando contenido correctamente.
/// </summary>
public sealed class HtmlWriter
{
    private readonly StringBuilder _sb = new();
    private int _indent;
    private readonly bool _pretty;

    public HtmlWriter(bool pretty = false)
    {
        _pretty = pretty;
    }

    /// <summary>
    /// Escribe una etiqueta de apertura con estilos inline opcionales.
    /// </summary>
    public void WriteOpenTag(string tag, string? style = null, string? attributes = null)
    {
        if (_pretty) _sb.Append(new string(' ', _indent * 2));

        _sb.Append('<').Append(tag);

        if (!string.IsNullOrEmpty(style))
            _sb.Append(" style=\"").Append(style).Append('"');

        if (!string.IsNullOrEmpty(attributes))
            _sb.Append(' ').Append(attributes);

        _sb.Append('>');

        if (_pretty) _sb.AppendLine();
        _indent++;
    }

    /// <summary>
    /// Escribe una etiqueta de cierre.
    /// </summary>
    public void WriteCloseTag(string tag)
    {
        _indent--;
        if (_pretty) _sb.Append(new string(' ', _indent * 2));
        _sb.Append("</").Append(tag).Append('>');
        if (_pretty) _sb.AppendLine();
    }

    /// <summary>
    /// Escribe texto HTML-encoded.
    /// </summary>
    public void WriteEncoded(string text)
    {
        _sb.Append(HtmlEncode(text));
    }

    /// <summary>
    /// Escribe HTML crudo sin escapar.
    /// </summary>
    public void WriteRaw(string html)
    {
        if (_pretty) _sb.Append(new string(' ', _indent * 2));
        _sb.Append(html);
        if (_pretty) _sb.AppendLine();
    }

    /// <summary>
    /// Escribe una línea vacía (para legibilidad).
    /// </summary>
    public void WriteLine()
    {
        _sb.AppendLine();
    }

    /// <summary>
    /// Devuelve el HTML generado.
    /// </summary>
    public override string ToString() => _sb.ToString();

    /// <summary>
    /// Escapa caracteres HTML en texto de contenido.
    /// </summary>
    public static string HtmlEncode(string text)
    {
        var sb = new StringBuilder(text.Length);
        foreach (var c in text)
        {
            switch (c)
            {
                case '<': sb.Append("&lt;"); break;
                case '>': sb.Append("&gt;"); break;
                case '&': sb.Append("&amp;"); break;
                case '"': sb.Append("&quot;"); break;
                default: sb.Append(c); break;
            }
        }
        return sb.ToString();
    }

    /// <summary>
    /// Escapa caracteres para atributos HTML.
    /// </summary>
    public static string AttributeEncode(string text)
    {
        var sb = new StringBuilder(text.Length);
        foreach (var c in text)
        {
            switch (c)
            {
                case '"': sb.Append("&quot;"); break;
                case '\'': sb.Append("&#x27;"); break;
                case '<': sb.Append("&lt;"); break;
                case '>': sb.Append("&gt;"); break;
                case '&': sb.Append("&amp;"); break;
                default: sb.Append(c); break;
            }
        }
        return sb.ToString();
    }
}
