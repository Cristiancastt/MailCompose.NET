using System.Text;

namespace MailCompose;

/// <summary>
/// Estilos inline tipados para nodos de email.
/// Cada propiedad genera CSS inline al renderizar.
/// Inspirado en los utilities de Tailwind CSS.
/// </summary>
public sealed class NodeStyle
{
    // ── Tipografía ────────────────────────────────────────────────
    public int? FontSize { get; set; }
    public FontWeight? FontWeight { get; set; }
    public string? FontFamily { get; set; }
    public string? TextColor { get; set; }
    public TextAlign? TextAlign { get; set; }
    public bool Italic { get; set; }
    public bool Underline { get; set; }
    public bool LineThrough { get; set; }
    public int? LineHeight { get; set; }
    public double? LineHeightMultiplier { get; set; }
    public int? LetterSpacing { get; set; }
    public double? LetterSpacingEm { get; set; }
    public TextTransform? TextTransform { get; set; }
    public TextOverflow? TextOverflow { get; set; }
    public WhiteSpace? WhiteSpace { get; set; }
    public WordBreak? WordBreak { get; set; }

    // Heading (internal)
    internal bool IsHeading { get; set; }
    internal int HeadingLevel { get; set; }

    // ── Fondo ─────────────────────────────────────────────────────
    public string? BackgroundColor { get; set; }
    public string? BackgroundImage { get; set; }
    public string? BackgroundPosition { get; set; }
    public string? BackgroundRepeat { get; set; }
    public string? BackgroundSize { get; set; }

    // ── Bordes ────────────────────────────────────────────────────
    public int BorderRadius { get; set; }
    public int? BorderRadiusTopLeft { get; set; }
    public int? BorderRadiusTopRight { get; set; }
    public int? BorderRadiusBottomLeft { get; set; }
    public int? BorderRadiusBottomRight { get; set; }

    // Borde completo (shorthand)
    public int? BorderWidth { get; set; }
    public string? BorderColor { get; set; }
    public string? BorderStyle { get; set; }

    // Bordes individuales por lado
    public int? BorderTopWidth { get; set; }
    public string? BorderTopColor { get; set; }
    public string? BorderTopStyle { get; set; }
    public int? BorderBottomWidth { get; set; }
    public string? BorderBottomColor { get; set; }
    public string? BorderBottomStyle { get; set; }
    public int? BorderLeftWidth { get; set; }
    public string? BorderLeftColor { get; set; }
    public string? BorderLeftStyle { get; set; }
    public int? BorderRightWidth { get; set; }
    public string? BorderRightColor { get; set; }
    public string? BorderRightStyle { get; set; }

    // ── Espaciado ─────────────────────────────────────────────────
    public int? Padding { get; set; }
    public int? PaddingTop { get; set; }
    public int? PaddingBottom { get; set; }
    public int? PaddingLeft { get; set; }
    public int? PaddingRight { get; set; }
    public int PaddingHorizontal { get; set; }
    public int PaddingVertical { get; set; }

    public int? Margin { get; set; }
    public int? MarginTop { get; set; }
    public int? MarginBottom { get; set; }
    public int? MarginLeft { get; set; }
    public int? MarginRight { get; set; }
    public int? MarginHorizontal { get; set; }
    public int? MarginVertical { get; set; }

    // ── Dimensiones ───────────────────────────────────────────────
    public string? Width { get; set; }
    public string? MinWidth { get; set; }
    public string? MaxWidth { get; set; }
    public string? Height { get; set; }
    public string? MinHeight { get; set; }
    public string? MaxHeight { get; set; }

    // ── Layout ────────────────────────────────────────────────────
    public Display? Display { get; set; }
    public VerticalAlign? VerticalAlign { get; set; }
    public Overflow? Overflow { get; set; }
    public Overflow? OverflowX { get; set; }
    public Overflow? OverflowY { get; set; }

    // ── Efectos ───────────────────────────────────────────────────
    public double? Opacity { get; set; }
    public string? BoxShadow { get; set; }

    // ── Cursor / Interacción ──────────────────────────────────────
    public string? Cursor { get; set; }

    /// <summary>
    /// Genera la cadena CSS inline completa.
    /// </summary>
    public string ToCss()
    {
        var sb = new StringBuilder(256);
        AppendAll(sb);
        return sb.ToString();
    }

    /// <summary>
    /// Genera CSS excluyendo ciertas propiedades (para nodos que las manejan aparte).
    /// </summary>
    public string ToCssWithout(params string[] exclude)
    {
        var sb = new StringBuilder(256);
        var ex = new HashSet<string>(exclude, StringComparer.OrdinalIgnoreCase);
        AppendTypography(sb, ex);
        AppendBackground(sb, ex);
        AppendBorders(sb, ex);
        AppendSpacing(sb, ex);
        AppendDimensions(sb, ex);
        AppendLayout(sb, ex);
        AppendEffects(sb, ex);
        return sb.ToString();
    }

    // ═══════════════════════════════════════════════════════════════
    //  Métodos internos de renderizado CSS
    // ═══════════════════════════════════════════════════════════════

    private void AppendAll(StringBuilder sb)
    {
        AppendTypography(sb, null);
        AppendBackground(sb, null);
        AppendBorders(sb, null);
        AppendSpacing(sb, null);
        AppendDimensions(sb, null);
        AppendLayout(sb, null);
        AppendEffects(sb, null);
    }

    private void AppendTypography(StringBuilder sb, HashSet<string>? ex)
    {
        if (FontSize.HasValue && !Excluded(ex, "font-size"))
            sb.Append($"font-size:{FontSize}px;");
        if (FontWeight.HasValue && !Excluded(ex, "font-weight"))
            sb.Append($"font-weight:{FontWeight.Value.ToCss()};");
        if (FontFamily != null && !Excluded(ex, "font-family"))
            sb.Append($"font-family:{FontFamily};");
        if (TextColor != null && !Excluded(ex, "color"))
            sb.Append($"color:{TextColor};");
        if (TextAlign.HasValue && !Excluded(ex, "text-align"))
            sb.Append($"text-align:{TextAlign.Value.ToCss()};");
        if (Italic && !Excluded(ex, "font-style"))
            sb.Append("font-style:italic;");

        // Text decoration: combinar underline + line-through
        if ((Underline || LineThrough) && !Excluded(ex, "text-decoration"))
        {
            var deco = Underline && LineThrough ? "underline line-through"
                     : Underline ? "underline" : "line-through";
            sb.Append($"text-decoration:{deco};");
        }

        if (LineHeight.HasValue && !Excluded(ex, "line-height"))
            sb.Append($"line-height:{LineHeight}px;");
        else if (LineHeightMultiplier.HasValue && !Excluded(ex, "line-height"))
            sb.Append($"line-height:{LineHeightMultiplier.Value:F2};");

        if (LetterSpacing.HasValue && !Excluded(ex, "letter-spacing"))
            sb.Append($"letter-spacing:{LetterSpacing}px;");
        else if (LetterSpacingEm.HasValue && !Excluded(ex, "letter-spacing"))
            sb.Append($"letter-spacing:{LetterSpacingEm.Value:F3}em;");

        if (TextTransform.HasValue && TextTransform != MailCompose.TextTransform.None
            && !Excluded(ex, "text-transform"))
            sb.Append($"text-transform:{TextTransform.Value.ToCss()};");

        if (TextOverflow.HasValue && !Excluded(ex, "text-overflow"))
            sb.Append($"text-overflow:{TextOverflow.Value.ToCss()};");

        if (WhiteSpace.HasValue && !Excluded(ex, "white-space"))
            sb.Append($"white-space:{WhiteSpace.Value.ToCss()};");

        if (WordBreak.HasValue && !Excluded(ex, "word-break"))
            sb.Append($"word-break:{WordBreak.Value.ToCss()};");
    }

    private void AppendBackground(StringBuilder sb, HashSet<string>? ex)
    {
        if (BackgroundColor != null && !Excluded(ex, "background-color"))
            sb.Append($"background-color:{BackgroundColor};");
        if (BackgroundImage != null && !Excluded(ex, "background-image"))
            sb.Append($"background-image:url('{BackgroundImage}');");
        if (BackgroundPosition != null && !Excluded(ex, "background-position"))
            sb.Append($"background-position:{BackgroundPosition};");
        if (BackgroundRepeat != null && !Excluded(ex, "background-repeat"))
            sb.Append($"background-repeat:{BackgroundRepeat};");
        if (BackgroundSize != null && !Excluded(ex, "background-size"))
            sb.Append($"background-size:{BackgroundSize};");
    }

    private void AppendBorders(StringBuilder sb, HashSet<string>? ex)
    {
        // Border radius
        if (!Excluded(ex, "border-radius"))
        {
            if (BorderRadiusTopLeft.HasValue || BorderRadiusTopRight.HasValue
                || BorderRadiusBottomLeft.HasValue || BorderRadiusBottomRight.HasValue)
            {
                // Individual corners
                var tl = BorderRadiusTopLeft ?? BorderRadius;
                var tr = BorderRadiusTopRight ?? BorderRadius;
                var bl = BorderRadiusBottomLeft ?? BorderRadius;
                var br = BorderRadiusBottomRight ?? BorderRadius;
                sb.Append($"border-radius:{tl}px {tr}px {br}px {bl}px;");
            }
            else if (BorderRadius > 0)
            {
                sb.Append($"border-radius:{BorderRadius}px;");
            }
        }

        // Borde completo shorthand
        if (BorderWidth.HasValue && !Excluded(ex, "border"))
            sb.Append($"border:{BorderWidth}px {BorderStyle ?? "solid"} {BorderColor ?? TailwindColors.Gray300};");

        // Bordes individuales
        if (BorderTopWidth.HasValue && !Excluded(ex, "border-top"))
            sb.Append($"border-top:{BorderTopWidth}px {BorderTopStyle ?? "solid"} {BorderTopColor ?? TailwindColors.Gray300};");
        if (BorderBottomWidth.HasValue && !Excluded(ex, "border-bottom"))
            sb.Append($"border-bottom:{BorderBottomWidth}px {BorderBottomStyle ?? "solid"} {BorderBottomColor ?? TailwindColors.Gray300};");
        if (BorderLeftWidth.HasValue && !Excluded(ex, "border-left"))
            sb.Append($"border-left:{BorderLeftWidth}px {BorderLeftStyle ?? "solid"} {BorderLeftColor ?? TailwindColors.Gray300};");
        if (BorderRightWidth.HasValue && !Excluded(ex, "border-right"))
            sb.Append($"border-right:{BorderRightWidth}px {BorderRightStyle ?? "solid"} {BorderRightColor ?? TailwindColors.Gray300};");
    }

    private void AppendSpacing(StringBuilder sb, HashSet<string>? ex)
    {
        // Padding
        if (!Excluded(ex, "padding"))
        {
            if (Padding.HasValue)
            {
                sb.Append($"padding:{Padding}px;");
            }
            else if (PaddingHorizontal > 0 || PaddingVertical > 0)
            {
                sb.Append($"padding:{PaddingVertical}px {PaddingHorizontal}px;");
            }
            else
            {
                if (PaddingTop.HasValue) sb.Append($"padding-top:{PaddingTop}px;");
                if (PaddingBottom.HasValue) sb.Append($"padding-bottom:{PaddingBottom}px;");
                if (PaddingLeft.HasValue) sb.Append($"padding-left:{PaddingLeft}px;");
                if (PaddingRight.HasValue) sb.Append($"padding-right:{PaddingRight}px;");
            }
        }

        // Margin
        if (!Excluded(ex, "margin"))
        {
            if (Margin.HasValue)
            {
                sb.Append($"margin:{Margin}px;");
            }
            else if (MarginHorizontal.HasValue || MarginVertical.HasValue)
            {
                var mv = MarginVertical ?? 0;
                var mh = MarginHorizontal ?? 0;
                sb.Append($"margin:{mv}px {mh}px;");
            }
            else
            {
                if (MarginTop.HasValue) sb.Append($"margin-top:{MarginTop}px;");
                if (MarginBottom.HasValue) sb.Append($"margin-bottom:{MarginBottom}px;");
                if (MarginLeft.HasValue) sb.Append($"margin-left:{MarginLeft}px;");
                if (MarginRight.HasValue) sb.Append($"margin-right:{MarginRight}px;");
            }
        }
    }

    private void AppendDimensions(StringBuilder sb, HashSet<string>? ex)
    {
        if (Width != null && !Excluded(ex, "width"))
            sb.Append($"width:{Width};");
        if (MinWidth != null && !Excluded(ex, "min-width"))
            sb.Append($"min-width:{MinWidth};");
        if (MaxWidth != null && !Excluded(ex, "max-width"))
            sb.Append($"max-width:{MaxWidth};");
        if (Height != null && !Excluded(ex, "height"))
            sb.Append($"height:{Height};");
        if (MinHeight != null && !Excluded(ex, "min-height"))
            sb.Append($"min-height:{MinHeight};");
        if (MaxHeight != null && !Excluded(ex, "max-height"))
            sb.Append($"max-height:{MaxHeight};");
    }

    private void AppendLayout(StringBuilder sb, HashSet<string>? ex)
    {
        if (Display.HasValue && !Excluded(ex, "display"))
            sb.Append($"display:{Display.Value.ToCss()};");
        if (VerticalAlign.HasValue && !Excluded(ex, "vertical-align"))
            sb.Append($"vertical-align:{VerticalAlign.Value.ToCss()};");

        if (!Excluded(ex, "overflow"))
        {
            if (OverflowX.HasValue && OverflowY.HasValue
                && OverflowX == OverflowY && Overflow == null)
            {
                sb.Append($"overflow:{OverflowX.Value.ToCss()};");
            }
            else
            {
                if (Overflow.HasValue)
                    sb.Append($"overflow:{Overflow.Value.ToCss()};");
                if (OverflowX.HasValue && Overflow == null)
                    sb.Append($"overflow-x:{OverflowX.Value.ToCss()};");
                if (OverflowY.HasValue && Overflow == null)
                    sb.Append($"overflow-y:{OverflowY.Value.ToCss()};");
            }
        }
    }

    private void AppendEffects(StringBuilder sb, HashSet<string>? ex)
    {
        if (Opacity.HasValue && !Excluded(ex, "opacity"))
            sb.Append($"opacity:{Opacity.Value:F2};");
        if (BoxShadow != null && !Excluded(ex, "box-shadow"))
            sb.Append($"box-shadow:{BoxShadow};");
        if (Cursor != null && !Excluded(ex, "cursor"))
            sb.Append($"cursor:{Cursor};");
    }

    private static bool Excluded(HashSet<string>? ex, string prop)
        => ex?.Contains(prop) == true;
}
