namespace MailCompose.Nodes;

/// <summary>
/// Nodo de texto simple.
/// </summary>
public sealed class TextNode : EmailNode
{
    public string Content { get; }

    public TextNode(string content)
    {
        Content = content;
    }

    public override void Render(HtmlWriter writer)
    {
        var tag = Style.IsHeading ? GetHeadingTag() : "p";
        var styles = Style.ToCss();
        writer.WriteOpenTag(tag, styles);
        writer.WriteEncoded(Content);
        writer.WriteCloseTag(tag);
    }

    private string GetHeadingTag() => Style.HeadingLevel switch
    {
        1 => "h1",
        2 => "h2",
        3 => "h3",
        4 => "h4",
        _ => "p"
    };

    protected override string GetDebugInfo() => $"\"{Content}\"";
}
