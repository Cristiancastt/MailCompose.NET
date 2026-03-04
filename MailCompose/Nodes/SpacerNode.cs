namespace MailCompose.Nodes;

/// <summary>
/// Espaciador vertical (espacio en blanco).
/// </summary>
public sealed class SpacerNode : EmailNode
{
    public int Height { get; }

    public SpacerNode(int height = 16)
    {
        Height = height;
    }

    public override void Render(HtmlWriter writer)
    {
        writer.WriteRaw(
            $"<div style=\"height:{Height}px;line-height:{Height}px;font-size:1px;\">&#160;</div>");
    }

    protected override string GetDebugInfo() => $"{Height}px";
}
