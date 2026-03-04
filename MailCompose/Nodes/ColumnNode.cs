namespace MailCompose.Nodes;

/// <summary>
/// Contenedor vertical (columna). Renderiza como tabla con filas apiladas.
/// </summary>
public sealed class ColumnNode : EmailNode
{
    public int Spacing { get; }
    public int Padding { get; }

    public ColumnNode(int spacing = 0, int padding = 0)
    {
        Spacing = spacing;
        Padding = padding;
    }

    public override void Render(HtmlWriter writer)
    {
        var tableStyle = Style.ToCss();
        if (Padding > 0 && !tableStyle.Contains("padding"))
            tableStyle = $"padding:{Padding}px;{tableStyle}";

        writer.WriteOpenTag("table", $"width:100%;border-collapse:collapse;{tableStyle}",
            attributes: "role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\"");

        for (var i = 0; i < Children.Count; i++)
        {
            writer.WriteOpenTag("tr");
            writer.WriteOpenTag("td", i > 0 && Spacing > 0 ? $"padding-top:{Spacing}px;" : "");
            Children[i].Render(writer);
            writer.WriteCloseTag("td");
            writer.WriteCloseTag("tr");
        }

        writer.WriteCloseTag("table");
    }

    protected override string GetDebugInfo() =>
        $"spacing={Spacing}, padding={Padding}";
}
