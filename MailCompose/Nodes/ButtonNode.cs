namespace MailCompose.Nodes;

/// <summary>
/// Botón de acción (CTA). Renderiza como tabla con enlace estilizado.
/// </summary>
public sealed class ButtonNode : EmailNode
{
    public string Label { get; }
    public string? Href { get; set; }

    public ButtonNode(string label)
    {
        Label = label;
        // Defaults tipo Tailwind: bg-blue-600, text-white, rounded, px-6 py-3
        Style.BackgroundColor = TailwindColors.Blue600;
        Style.TextColor = "#ffffff";
        Style.BorderRadius = 6;
        Style.PaddingHorizontal = 24;
        Style.PaddingVertical = 12;
        Style.FontWeight = FontWeight.SemiBold;
        Style.FontSize = 14;
    }

    public override void Render(HtmlWriter writer)
    {
        // Bulletproof button para email (tabla + VML fallback)
        var bgColor = Style.BackgroundColor ?? TailwindColors.Blue600;
        var textColor = Style.TextColor ?? "#ffffff";
        var radius = Style.BorderRadius;
        var px = Style.PaddingHorizontal;
        var py = Style.PaddingVertical;
        var fontSize = Style.FontSize ?? 14;
        var fontWeight = Style.FontWeight?.ToCss() ?? "600";
        var align = Style.TextAlign?.ToCss() ?? "center";
        var extraCss = Style.ToCssWithout("background-color", "color", "border-radius",
            "padding", "font-size", "font-weight", "text-align");

        var btnStyle = $"background-color:{bgColor};color:{textColor};border-radius:{radius}px;" +
                       $"padding:{py}px {px}px;font-size:{fontSize}px;font-weight:{fontWeight};" +
                       $"text-decoration:none;display:inline-block;text-align:{align};{extraCss}";

        writer.WriteOpenTag("table",
            "border-collapse:collapse;",
            "role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\"");
        writer.WriteOpenTag("tr");
        writer.WriteOpenTag("td", $"text-align:{align};");

        if (!string.IsNullOrEmpty(Href))
        {
            writer.WriteRaw($"<a href=\"{HtmlWriter.AttributeEncode(Href)}\" style=\"{btnStyle}\">");
            writer.WriteEncoded(Label);
            writer.WriteRaw("</a>");
        }
        else
        {
            writer.WriteOpenTag("span", btnStyle);
            writer.WriteEncoded(Label);
            writer.WriteCloseTag("span");
        }

        writer.WriteCloseTag("td");
        writer.WriteCloseTag("tr");
        writer.WriteCloseTag("table");
    }

    protected override string GetDebugInfo() => $"\"{Label}\"";
}
