namespace MailCompose.Nodes;

/// <summary>
/// Contenedor horizontal (fila). Renderiza como tabla con celdas lado a lado.
/// </summary>
public sealed class RowNode : EmailNode
{
    public int Spacing { get; }
    public int Padding { get; }

    public RowNode(int spacing = 0, int padding = 0)
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
        writer.WriteOpenTag("tr");

        for (var i = 0; i < Children.Count; i++)
        {
            var cellStyle = i > 0 && Spacing > 0 ? $"padding-left:{Spacing}px;" : "";
            cellStyle += "vertical-align:top;";
            writer.WriteOpenTag("td", cellStyle);
            Children[i].Render(writer);
            writer.WriteCloseTag("td");
        }

        writer.WriteCloseTag("tr");
        writer.WriteCloseTag("table");
    }

    protected override string GetDebugInfo() =>
        $"spacing={Spacing}, padding={Padding}";
}
