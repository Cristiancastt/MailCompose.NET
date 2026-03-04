namespace MailCompose.Nodes;

/// <summary>
/// Enlace de texto.
/// </summary>
public sealed class LinkNode : EmailNode
{
    public string Href { get; }
    public string Content { get; }

    public LinkNode(string href, string content)
    {
        Href = href;
        Content = content;
        // Default: Tailwind blue-600
        Style.TextColor = TailwindColors.Blue600;
    }

    public override void Render(HtmlWriter writer)
    {
        var color = Style.TextColor ?? TailwindColors.Blue600;
        var extraCss = Style.ToCssWithout("color");
        var css = $"color:{color};{extraCss}";

        writer.WriteRaw(
            $"<a href=\"{HtmlWriter.AttributeEncode(Href)}\" style=\"{css}\">");
        writer.WriteEncoded(Content);
        writer.WriteRaw("</a>");
    }

    protected override string GetDebugInfo() => $"\"{Content}\" -> {Href}";
}
