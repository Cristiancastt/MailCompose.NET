namespace MailCompose.Nodes;

/// <summary>
/// Imagen en el email.
/// </summary>
public sealed class ImageNode : EmailNode
{
    public string Src { get; }
    public string Alt { get; }
    public int? Width { get; set; }
    public int? Height { get; set; }

    public ImageNode(string src, string alt = "")
    {
        Src = src;
        Alt = alt;
    }

    public override void Render(HtmlWriter writer)
    {
        var styles = Style.ToCss();
        var sizeAttrs = "";
        if (Width.HasValue) sizeAttrs += $" width=\"{Width.Value}\"";
        if (Height.HasValue) sizeAttrs += $" height=\"{Height.Value}\"";

        writer.WriteRaw(
            $"<img src=\"{HtmlWriter.AttributeEncode(Src)}\" " +
            $"alt=\"{HtmlWriter.AttributeEncode(Alt)}\"" +
            $"{sizeAttrs} " +
            $"style=\"display:block;border:0;outline:none;{styles}\" />");
    }

    protected override string GetDebugInfo() => $"\"{Src}\"";
}
