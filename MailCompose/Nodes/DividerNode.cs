namespace MailCompose.Nodes;

/// <summary>
/// Línea divisora horizontal.
/// </summary>
public sealed class DividerNode : EmailNode
{
    public string Color { get; set; } = TailwindColors.Gray200;
    public int Thickness { get; set; } = 1;
    public int MarginVertical { get; set; } = 16;

    public override void Render(HtmlWriter writer)
    {
        writer.WriteRaw(
            $"<hr style=\"border:none;border-top:{Thickness}px solid {Color};" +
            $"margin:{MarginVertical}px 0;\" />");
    }
}
