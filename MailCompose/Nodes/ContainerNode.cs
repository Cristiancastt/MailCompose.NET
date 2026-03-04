namespace MailCompose.Nodes;

/// <summary>
/// Contenedor genérico (card, section, etc.).
/// Renderiza como tabla con una sola celda.
/// </summary>
public sealed class ContainerNode : EmailNode
{
    public override void Render(HtmlWriter writer)
    {
        var css = Style.ToCss();

        writer.WriteOpenTag("table",
            $"width:100%;border-collapse:collapse;{css}",
            "role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\"");
        writer.WriteOpenTag("tr");
        writer.WriteOpenTag("td");

        foreach (var child in Children)
            child.Render(writer);

        writer.WriteCloseTag("td");
        writer.WriteCloseTag("tr");
        writer.WriteCloseTag("table");
    }
}
