using MailCompose.Nodes;

namespace MailCompose;

/// <summary>
/// Métodos de extensión fluent estilo Tailwind CSS para estilizar nodos de email.
/// Permiten encadenar: Text("Hola").Bold().TextLg().TextColor(TailwindColors.Gray900).Uppercase()
/// </summary>
public static class NodeStyleExtensions
{
    // ═══════════════════════════════════════════════════════════════
    //  TIPOGRAFÍA — Font Size Presets (text-xs ... text-9xl)
    // ═══════════════════════════════════════════════════════════════

    /// <summary>text-xs: 12px / line-height 16px</summary>
    public static T TextXs<T>(this T node) where T : EmailNode
    { node.Style.FontSize = TailwindPresets.TextXs; node.Style.LineHeight = TailwindPresets.TextXsLh; return node; }

    /// <summary>text-sm: 14px / line-height 20px</summary>
    public static T TextSm<T>(this T node) where T : EmailNode
    { node.Style.FontSize = TailwindPresets.TextSm; node.Style.LineHeight = TailwindPresets.TextSmLh; return node; }

    /// <summary>text-base: 16px / line-height 24px</summary>
    public static T TextBase<T>(this T node) where T : EmailNode
    { node.Style.FontSize = TailwindPresets.TextBase; node.Style.LineHeight = TailwindPresets.TextBaseLh; return node; }

    /// <summary>text-lg: 18px / line-height 28px</summary>
    public static T TextLg<T>(this T node) where T : EmailNode
    { node.Style.FontSize = TailwindPresets.TextLg; node.Style.LineHeight = TailwindPresets.TextLgLh; return node; }

    /// <summary>text-xl: 20px / line-height 28px</summary>
    public static T TextXl<T>(this T node) where T : EmailNode
    { node.Style.FontSize = TailwindPresets.TextXl; node.Style.LineHeight = TailwindPresets.TextXlLh; return node; }

    /// <summary>text-2xl: 24px / line-height 32px</summary>
    public static T Text2Xl<T>(this T node) where T : EmailNode
    { node.Style.FontSize = TailwindPresets.Text2Xl; node.Style.LineHeight = TailwindPresets.Text2XlLh; return node; }

    /// <summary>text-3xl: 30px / line-height 36px</summary>
    public static T Text3Xl<T>(this T node) where T : EmailNode
    { node.Style.FontSize = TailwindPresets.Text3Xl; node.Style.LineHeight = TailwindPresets.Text3XlLh; return node; }

    /// <summary>text-4xl: 36px / line-height 40px</summary>
    public static T Text4Xl<T>(this T node) where T : EmailNode
    { node.Style.FontSize = TailwindPresets.Text4Xl; node.Style.LineHeight = TailwindPresets.Text4XlLh; return node; }

    /// <summary>text-5xl: 48px / line-height 48px</summary>
    public static T Text5Xl<T>(this T node) where T : EmailNode
    { node.Style.FontSize = TailwindPresets.Text5Xl; node.Style.LineHeight = TailwindPresets.Text5XlLh; return node; }

    /// <summary>text-6xl: 60px</summary>
    public static T Text6Xl<T>(this T node) where T : EmailNode
    { node.Style.FontSize = TailwindPresets.Text6Xl; node.Style.LineHeight = TailwindPresets.Text6XlLh; return node; }

    /// <summary>text-7xl: 72px</summary>
    public static T Text7Xl<T>(this T node) where T : EmailNode
    { node.Style.FontSize = TailwindPresets.Text7Xl; node.Style.LineHeight = TailwindPresets.Text7XlLh; return node; }

    /// <summary>text-8xl: 96px</summary>
    public static T Text8Xl<T>(this T node) where T : EmailNode
    { node.Style.FontSize = TailwindPresets.Text8Xl; node.Style.LineHeight = TailwindPresets.Text8XlLh; return node; }

    /// <summary>text-9xl: 128px</summary>
    public static T Text9Xl<T>(this T node) where T : EmailNode
    { node.Style.FontSize = TailwindPresets.Text9Xl; node.Style.LineHeight = TailwindPresets.Text9XlLh; return node; }

    /// <summary>Tamaño de fuente libre en px.</summary>
    public static T FontSize<T>(this T node, int size) where T : EmailNode
    { node.Style.FontSize = size; return node; }

    // ═══════════════════════════════════════════════════════════════
    //  TIPOGRAFÍA — Font Weight (font-thin ... font-black)
    // ═══════════════════════════════════════════════════════════════

    /// <summary>font-thin: 100</summary>
    public static T Thin<T>(this T node) where T : EmailNode
    { node.Style.FontWeight = MailCompose.FontWeight.Thin; return node; }

    /// <summary>font-extralight: 200</summary>
    public static T ExtraLight<T>(this T node) where T : EmailNode
    { node.Style.FontWeight = MailCompose.FontWeight.ExtraLight; return node; }

    /// <summary>font-light: 300</summary>
    public static T Light<T>(this T node) where T : EmailNode
    { node.Style.FontWeight = MailCompose.FontWeight.Light; return node; }

    /// <summary>font-normal: 400</summary>
    public static T Normal<T>(this T node) where T : EmailNode
    { node.Style.FontWeight = MailCompose.FontWeight.Normal; return node; }

    /// <summary>font-medium: 500</summary>
    public static T Medium<T>(this T node) where T : EmailNode
    { node.Style.FontWeight = MailCompose.FontWeight.Medium; return node; }

    /// <summary>font-semibold: 600</summary>
    public static T SemiBold<T>(this T node) where T : EmailNode
    { node.Style.FontWeight = MailCompose.FontWeight.SemiBold; return node; }

    /// <summary>font-bold: 700</summary>
    public static T Bold<T>(this T node) where T : EmailNode
    { node.Style.FontWeight = MailCompose.FontWeight.Bold; return node; }

    /// <summary>font-extrabold: 800</summary>
    public static T ExtraBold<T>(this T node) where T : EmailNode
    { node.Style.FontWeight = MailCompose.FontWeight.ExtraBold; return node; }

    /// <summary>font-black: 900</summary>
    public static T FontBlack<T>(this T node) where T : EmailNode
    { node.Style.FontWeight = MailCompose.FontWeight.Black; return node; }

    /// <summary>Establece el peso de fuente explícitamente.</summary>
    public static T Weight<T>(this T node, FontWeight weight) where T : EmailNode
    { node.Style.FontWeight = weight; return node; }

    // ═══════════════════════════════════════════════════════════════
    //  TIPOGRAFÍA — Font Style & Decoration
    // ═══════════════════════════════════════════════════════════════

    /// <summary>italic</summary>
    public static T Italic<T>(this T node) where T : EmailNode
    { node.Style.Italic = true; return node; }

    /// <summary>not-italic</summary>
    public static T NotItalic<T>(this T node) where T : EmailNode
    { node.Style.Italic = false; return node; }

    /// <summary>underline</summary>
    public static T Underline<T>(this T node) where T : EmailNode
    { node.Style.Underline = true; return node; }

    /// <summary>no-underline</summary>
    public static T NoUnderline<T>(this T node) where T : EmailNode
    { node.Style.Underline = false; return node; }

    /// <summary>line-through</summary>
    public static T LineThrough<T>(this T node) where T : EmailNode
    { node.Style.LineThrough = true; return node; }

    // ═══════════════════════════════════════════════════════════════
    //  TIPOGRAFÍA — Text Transform
    // ═══════════════════════════════════════════════════════════════

    /// <summary>uppercase</summary>
    public static T Uppercase<T>(this T node) where T : EmailNode
    { node.Style.TextTransform = MailCompose.TextTransform.Uppercase; return node; }

    /// <summary>lowercase</summary>
    public static T Lowercase<T>(this T node) where T : EmailNode
    { node.Style.TextTransform = MailCompose.TextTransform.Lowercase; return node; }

    /// <summary>capitalize</summary>
    public static T Capitalize<T>(this T node) where T : EmailNode
    { node.Style.TextTransform = MailCompose.TextTransform.Capitalize; return node; }

    /// <summary>normal-case (reset)</summary>
    public static T NormalCase<T>(this T node) where T : EmailNode
    { node.Style.TextTransform = MailCompose.TextTransform.None; return node; }

    // ═══════════════════════════════════════════════════════════════
    //  TIPOGRAFÍA — Font Family
    // ═══════════════════════════════════════════════════════════════

    /// <summary>font-sans (system stack)</summary>
    public static T FontSans<T>(this T node) where T : EmailNode
    { node.Style.FontFamily = TailwindPresets.FontSans; return node; }

    /// <summary>font-serif</summary>
    public static T FontSerif<T>(this T node) where T : EmailNode
    { node.Style.FontFamily = TailwindPresets.FontSerif; return node; }

    /// <summary>font-mono</summary>
    public static T FontMono<T>(this T node) where T : EmailNode
    { node.Style.FontFamily = TailwindPresets.FontMono; return node; }

    /// <summary>Font family libre.</summary>
    public static T Font<T>(this T node, string family) where T : EmailNode
    { node.Style.FontFamily = family; return node; }

    // ═══════════════════════════════════════════════════════════════
    //  TIPOGRAFÍA — Line Height (leading)
    // ═══════════════════════════════════════════════════════════════

    /// <summary>Line height en px.</summary>
    public static T Leading<T>(this T node, int lineHeightPx) where T : EmailNode
    { node.Style.LineHeight = lineHeightPx; node.Style.LineHeightMultiplier = null; return node; }

    /// <summary>leading-none: 1.0</summary>
    public static T LeadingNone<T>(this T node) where T : EmailNode
    { node.Style.LineHeightMultiplier = TailwindPresets.LeadingNone; node.Style.LineHeight = null; return node; }

    /// <summary>leading-tight: 1.25</summary>
    public static T LeadingTight<T>(this T node) where T : EmailNode
    { node.Style.LineHeightMultiplier = TailwindPresets.LeadingTight; node.Style.LineHeight = null; return node; }

    /// <summary>leading-snug: 1.375</summary>
    public static T LeadingSnug<T>(this T node) where T : EmailNode
    { node.Style.LineHeightMultiplier = TailwindPresets.LeadingSnug; node.Style.LineHeight = null; return node; }

    /// <summary>leading-normal: 1.5</summary>
    public static T LeadingNormal<T>(this T node) where T : EmailNode
    { node.Style.LineHeightMultiplier = TailwindPresets.LeadingNormal; node.Style.LineHeight = null; return node; }

    /// <summary>leading-relaxed: 1.625</summary>
    public static T LeadingRelaxed<T>(this T node) where T : EmailNode
    { node.Style.LineHeightMultiplier = TailwindPresets.LeadingRelaxed; node.Style.LineHeight = null; return node; }

    /// <summary>leading-loose: 2.0</summary>
    public static T LeadingLoose<T>(this T node) where T : EmailNode
    { node.Style.LineHeightMultiplier = TailwindPresets.LeadingLoose; node.Style.LineHeight = null; return node; }

    // ═══════════════════════════════════════════════════════════════
    //  TIPOGRAFÍA — Letter Spacing (tracking)
    // ═══════════════════════════════════════════════════════════════

    /// <summary>Letter spacing libre en px.</summary>
    public static T Tracking<T>(this T node, int letterSpacingPx) where T : EmailNode
    { node.Style.LetterSpacing = letterSpacingPx; node.Style.LetterSpacingEm = null; return node; }

    /// <summary>tracking-tighter: -0.05em</summary>
    public static T TrackingTighter<T>(this T node) where T : EmailNode
    { node.Style.LetterSpacingEm = TailwindPresets.TrackingTighter; node.Style.LetterSpacing = null; return node; }

    /// <summary>tracking-tight: -0.025em</summary>
    public static T TrackingTight<T>(this T node) where T : EmailNode
    { node.Style.LetterSpacingEm = TailwindPresets.TrackingTight; node.Style.LetterSpacing = null; return node; }

    /// <summary>tracking-normal: 0em</summary>
    public static T TrackingNormal<T>(this T node) where T : EmailNode
    { node.Style.LetterSpacingEm = TailwindPresets.TrackingNormal; node.Style.LetterSpacing = null; return node; }

    /// <summary>tracking-wide: 0.025em</summary>
    public static T TrackingWide<T>(this T node) where T : EmailNode
    { node.Style.LetterSpacingEm = TailwindPresets.TrackingWide; node.Style.LetterSpacing = null; return node; }

    /// <summary>tracking-wider: 0.05em</summary>
    public static T TrackingWider<T>(this T node) where T : EmailNode
    { node.Style.LetterSpacingEm = TailwindPresets.TrackingWider; node.Style.LetterSpacing = null; return node; }

    /// <summary>tracking-widest: 0.1em</summary>
    public static T TrackingWidest<T>(this T node) where T : EmailNode
    { node.Style.LetterSpacingEm = TailwindPresets.TrackingWidest; node.Style.LetterSpacing = null; return node; }

    // ═══════════════════════════════════════════════════════════════
    //  TIPOGRAFÍA — Text Overflow & White Space
    // ═══════════════════════════════════════════════════════════════

    /// <summary>text-ellipsis + overflow-hidden + whitespace-nowrap (truncate)</summary>
    public static T Truncate<T>(this T node) where T : EmailNode
    {
        node.Style.TextOverflow = MailCompose.TextOverflow.Ellipsis;
        node.Style.Overflow = MailCompose.Overflow.Hidden;
        node.Style.WhiteSpace = MailCompose.WhiteSpace.Nowrap;
        return node;
    }

    /// <summary>whitespace-normal</summary>
    public static T WhitespaceNormal<T>(this T node) where T : EmailNode
    { node.Style.WhiteSpace = MailCompose.WhiteSpace.Normal; return node; }

    /// <summary>whitespace-nowrap</summary>
    public static T WhitespaceNowrap<T>(this T node) where T : EmailNode
    { node.Style.WhiteSpace = MailCompose.WhiteSpace.Nowrap; return node; }

    /// <summary>whitespace-pre</summary>
    public static T WhitespacePre<T>(this T node) where T : EmailNode
    { node.Style.WhiteSpace = MailCompose.WhiteSpace.Pre; return node; }

    /// <summary>whitespace-pre-wrap</summary>
    public static T WhitespacePreWrap<T>(this T node) where T : EmailNode
    { node.Style.WhiteSpace = MailCompose.WhiteSpace.PreWrap; return node; }

    /// <summary>whitespace-pre-line</summary>
    public static T WhitespacePreLine<T>(this T node) where T : EmailNode
    { node.Style.WhiteSpace = MailCompose.WhiteSpace.PreLine; return node; }

    /// <summary>break-normal</summary>
    public static T BreakNormal<T>(this T node) where T : EmailNode
    { node.Style.WordBreak = MailCompose.WordBreak.Normal; return node; }

    /// <summary>break-all</summary>
    public static T BreakAll<T>(this T node) where T : EmailNode
    { node.Style.WordBreak = MailCompose.WordBreak.BreakAll; return node; }

    /// <summary>break-words (overflow-wrap: break-word)</summary>
    public static T BreakWords<T>(this T node) where T : EmailNode
    { node.Style.WordBreak = MailCompose.WordBreak.BreakWord; return node; }

    // ═══════════════════════════════════════════════════════════════
    //  COLOR — Text & Background
    // ═══════════════════════════════════════════════════════════════

    /// <summary>Color del texto (ej: TailwindColors.Gray900).</summary>
    public static T TextColor<T>(this T node, string color) where T : EmailNode
    { node.Style.TextColor = color; return node; }

    /// <summary>Alias de TextColor. Ej: .Text(TailwindColors.Red500)</summary>
    public static T Text<T>(this T node, string color) where T : EmailNode
    { node.Style.TextColor = color; return node; }

    /// <summary>Color de fondo. Ej: .Background(TailwindColors.Blue100)</summary>
    public static T Background<T>(this T node, string color) where T : EmailNode
    { node.Style.BackgroundColor = color; return node; }

    /// <summary>Alias de Background. Ej: .Bg(TailwindColors.Gray50)</summary>
    public static T Bg<T>(this T node, string color) where T : EmailNode
    { node.Style.BackgroundColor = color; return node; }

    /// <summary>Imagen de fondo (soporte limitado en email).</summary>
    public static T BgImage<T>(this T node, string url, string position = "center", string size = "cover") where T : EmailNode
    {
        node.Style.BackgroundImage = url;
        node.Style.BackgroundPosition = position;
        node.Style.BackgroundSize = size;
        node.Style.BackgroundRepeat = "no-repeat";
        return node;
    }

    // ═══════════════════════════════════════════════════════════════
    //  ALINEACIÓN DE TEXTO
    // ═══════════════════════════════════════════════════════════════

    /// <summary>text-left</summary>
    public static T TextLeft<T>(this T node) where T : EmailNode
    { node.Style.TextAlign = MailCompose.TextAlign.Left; return node; }

    /// <summary>text-center</summary>
    public static T TextCenter<T>(this T node) where T : EmailNode
    { node.Style.TextAlign = MailCompose.TextAlign.Center; return node; }

    /// <summary>text-right</summary>
    public static T TextRight<T>(this T node) where T : EmailNode
    { node.Style.TextAlign = MailCompose.TextAlign.Right; return node; }

    /// <summary>text-justify</summary>
    public static T TextJustify<T>(this T node) where T : EmailNode
    { node.Style.TextAlign = MailCompose.TextAlign.Justify; return node; }

    /// <summary>Alias: centra el texto.</summary>
    public static T Center<T>(this T node) where T : EmailNode
    { node.Style.TextAlign = MailCompose.TextAlign.Center; return node; }

    /// <summary>Alinea el texto según el enum.</summary>
    public static T Align<T>(this T node, TextAlign align) where T : EmailNode
    { node.Style.TextAlign = align; return node; }

    // ═══════════════════════════════════════════════════════════════
    //  BORDER RADIUS — rounded presets
    // ═══════════════════════════════════════════════════════════════

    /// <summary>rounded-none: 0px</summary>
    public static T RoundedNone<T>(this T node) where T : EmailNode
    { node.Style.BorderRadius = TailwindPresets.RoundedNone; return node; }

    /// <summary>rounded-sm: 2px</summary>
    public static T RoundedSm<T>(this T node) where T : EmailNode
    { node.Style.BorderRadius = TailwindPresets.RoundedSm; return node; }

    /// <summary>rounded: 4px (default)</summary>
    public static T Rounded<T>(this T node) where T : EmailNode
    { node.Style.BorderRadius = TailwindPresets.Rounded; return node; }

    /// <summary>rounded con valor libre en px.</summary>
    public static T Rounded<T>(this T node, int radiusPx) where T : EmailNode
    { node.Style.BorderRadius = radiusPx; return node; }

    /// <summary>rounded-md: 6px</summary>
    public static T RoundedMd<T>(this T node) where T : EmailNode
    { node.Style.BorderRadius = TailwindPresets.RoundedMd; return node; }

    /// <summary>rounded-lg: 8px</summary>
    public static T RoundedLg<T>(this T node) where T : EmailNode
    { node.Style.BorderRadius = TailwindPresets.RoundedLg; return node; }

    /// <summary>rounded-xl: 12px</summary>
    public static T RoundedXl<T>(this T node) where T : EmailNode
    { node.Style.BorderRadius = TailwindPresets.RoundedXl; return node; }

    /// <summary>rounded-2xl: 16px</summary>
    public static T Rounded2Xl<T>(this T node) where T : EmailNode
    { node.Style.BorderRadius = TailwindPresets.Rounded2Xl; return node; }

    /// <summary>rounded-3xl: 24px</summary>
    public static T Rounded3Xl<T>(this T node) where T : EmailNode
    { node.Style.BorderRadius = TailwindPresets.Rounded3Xl; return node; }

    /// <summary>rounded-full: 9999px (pill/circle)</summary>
    public static T RoundedFull<T>(this T node) where T : EmailNode
    { node.Style.BorderRadius = TailwindPresets.RoundedFull; return node; }

    // ── Rounded por esquina ──────────────────────────────────────

    /// <summary>rounded-tl: esquina superior izquierda.</summary>
    public static T RoundedTl<T>(this T node, int px) where T : EmailNode
    { node.Style.BorderRadiusTopLeft = px; return node; }

    /// <summary>rounded-tr: esquina superior derecha.</summary>
    public static T RoundedTr<T>(this T node, int px) where T : EmailNode
    { node.Style.BorderRadiusTopRight = px; return node; }

    /// <summary>rounded-bl: esquina inferior izquierda.</summary>
    public static T RoundedBl<T>(this T node, int px) where T : EmailNode
    { node.Style.BorderRadiusBottomLeft = px; return node; }

    /// <summary>rounded-br: esquina inferior derecha.</summary>
    public static T RoundedBr<T>(this T node, int px) where T : EmailNode
    { node.Style.BorderRadiusBottomRight = px; return node; }

    /// <summary>rounded-t: esquinas superiores.</summary>
    public static T RoundedT<T>(this T node, int px) where T : EmailNode
    { node.Style.BorderRadiusTopLeft = px; node.Style.BorderRadiusTopRight = px; return node; }

    /// <summary>rounded-b: esquinas inferiores.</summary>
    public static T RoundedB<T>(this T node, int px) where T : EmailNode
    { node.Style.BorderRadiusBottomLeft = px; node.Style.BorderRadiusBottomRight = px; return node; }

    /// <summary>rounded-l: esquinas izquierdas.</summary>
    public static T RoundedL<T>(this T node, int px) where T : EmailNode
    { node.Style.BorderRadiusTopLeft = px; node.Style.BorderRadiusBottomLeft = px; return node; }

    /// <summary>rounded-r: esquinas derechas.</summary>
    public static T RoundedR<T>(this T node, int px) where T : EmailNode
    { node.Style.BorderRadiusTopRight = px; node.Style.BorderRadiusBottomRight = px; return node; }

    // ═══════════════════════════════════════════════════════════════
    //  BORDES — border, border-t, border-b, border-l, border-r
    // ═══════════════════════════════════════════════════════════════

    /// <summary>border (todos los lados).</summary>
    public static T Border<T>(this T node, int width = 1, string? color = null, string style = "solid") where T : EmailNode
    {
        node.Style.BorderWidth = width;
        node.Style.BorderColor = color ?? TailwindColors.Gray300;
        node.Style.BorderStyle = style;
        return node;
    }

    /// <summary>border-0: sin borde.</summary>
    public static T Border0<T>(this T node) where T : EmailNode
    { node.Style.BorderWidth = 0; return node; }

    /// <summary>border-2</summary>
    public static T Border2<T>(this T node, string? color = null) where T : EmailNode
    { node.Style.BorderWidth = 2; node.Style.BorderColor = color ?? TailwindColors.Gray300; node.Style.BorderStyle = "solid"; return node; }

    /// <summary>border-4</summary>
    public static T Border4<T>(this T node, string? color = null) where T : EmailNode
    { node.Style.BorderWidth = 4; node.Style.BorderColor = color ?? TailwindColors.Gray300; node.Style.BorderStyle = "solid"; return node; }

    /// <summary>border-8</summary>
    public static T Border8<T>(this T node, string? color = null) where T : EmailNode
    { node.Style.BorderWidth = 8; node.Style.BorderColor = color ?? TailwindColors.Gray300; node.Style.BorderStyle = "solid"; return node; }

    /// <summary>border-t: solo borde superior.</summary>
    public static T BorderT<T>(this T node, int width = 1, string? color = null, string style = "solid") where T : EmailNode
    { node.Style.BorderTopWidth = width; node.Style.BorderTopColor = color; node.Style.BorderTopStyle = style; return node; }

    /// <summary>border-b: solo borde inferior.</summary>
    public static T BorderB<T>(this T node, int width = 1, string? color = null, string style = "solid") where T : EmailNode
    { node.Style.BorderBottomWidth = width; node.Style.BorderBottomColor = color; node.Style.BorderBottomStyle = style; return node; }

    /// <summary>border-l: solo borde izquierdo.</summary>
    public static T BorderL<T>(this T node, int width = 1, string? color = null, string style = "solid") where T : EmailNode
    { node.Style.BorderLeftWidth = width; node.Style.BorderLeftColor = color; node.Style.BorderLeftStyle = style; return node; }

    /// <summary>border-r: solo borde derecho.</summary>
    public static T BorderR<T>(this T node, int width = 1, string? color = null, string style = "solid") where T : EmailNode
    { node.Style.BorderRightWidth = width; node.Style.BorderRightColor = color; node.Style.BorderRightStyle = style; return node; }

    /// <summary>border-x: bordes horizontales (izquierdo + derecho).</summary>
    public static T BorderX<T>(this T node, int width = 1, string? color = null, string style = "solid") where T : EmailNode
    { node.BorderL(width, color, style).BorderR(width, color, style); return node; }

    /// <summary>border-y: bordes verticales (superior + inferior).</summary>
    public static T BorderY<T>(this T node, int width = 1, string? color = null, string style = "solid") where T : EmailNode
    { node.BorderT(width, color, style).BorderB(width, color, style); return node; }

    /// <summary>border-dashed</summary>
    public static T BorderDashed<T>(this T node) where T : EmailNode
    { node.Style.BorderStyle = "dashed"; return node; }

    /// <summary>border-dotted</summary>
    public static T BorderDotted<T>(this T node) where T : EmailNode
    { node.Style.BorderStyle = "dotted"; return node; }

    /// <summary>border-double</summary>
    public static T BorderDouble<T>(this T node) where T : EmailNode
    { node.Style.BorderStyle = "double"; return node; }

    /// <summary>border-none</summary>
    public static T BorderNone<T>(this T node) where T : EmailNode
    { node.Style.BorderStyle = "none"; return node; }

    /// <summary>border-color: color del borde.</summary>
    public static T BorderColor<T>(this T node, string color) where T : EmailNode
    { node.Style.BorderColor = color; return node; }

    // ═══════════════════════════════════════════════════════════════
    //  PADDING — p, px, py, pt, pb, pl, pr
    // ═══════════════════════════════════════════════════════════════

    /// <summary>Padding uniforme en px. Ej: .P(16)</summary>
    public static T P<T>(this T node, int px) where T : EmailNode
    { node.Style.Padding = px; return node; }

    /// <summary>Padding horizontal (left + right). Ej: .Px(24)</summary>
    public static T Px<T>(this T node, int px) where T : EmailNode
    { node.Style.PaddingLeft = px; node.Style.PaddingRight = px; return node; }

    /// <summary>Padding vertical (top + bottom). Ej: .Py(12)</summary>
    public static T Py<T>(this T node, int px) where T : EmailNode
    { node.Style.PaddingTop = px; node.Style.PaddingBottom = px; return node; }

    /// <summary>padding-top</summary>
    public static T Pt<T>(this T node, int px) where T : EmailNode
    { node.Style.PaddingTop = px; return node; }

    /// <summary>padding-bottom</summary>
    public static T Pb<T>(this T node, int px) where T : EmailNode
    { node.Style.PaddingBottom = px; return node; }

    /// <summary>padding-left</summary>
    public static T Pl<T>(this T node, int px) where T : EmailNode
    { node.Style.PaddingLeft = px; return node; }

    /// <summary>padding-right</summary>
    public static T Pr<T>(this T node, int px) where T : EmailNode
    { node.Style.PaddingRight = px; return node; }

    /// <summary>Padding uniforme en px (alias largo).</summary>
    public static T Padding<T>(this T node, int all) where T : EmailNode
    { node.Style.Padding = all; return node; }

    /// <summary>Padding vertical y horizontal.</summary>
    public static T Padding<T>(this T node, int vertical, int horizontal) where T : EmailNode
    { node.Style.PaddingVertical = vertical; node.Style.PaddingHorizontal = horizontal; return node; }

    /// <summary>Padding por lado (alias largo).</summary>
    public static T PaddingTop<T>(this T node, int px) where T : EmailNode { node.Style.PaddingTop = px; return node; }
    public static T PaddingBottom<T>(this T node, int px) where T : EmailNode { node.Style.PaddingBottom = px; return node; }
    public static T PaddingLeft<T>(this T node, int px) where T : EmailNode { node.Style.PaddingLeft = px; return node; }
    public static T PaddingRight<T>(this T node, int px) where T : EmailNode { node.Style.PaddingRight = px; return node; }

    // ═══════════════════════════════════════════════════════════════
    //  MARGIN — m, mx, my, mt, mb, ml, mr
    // ═══════════════════════════════════════════════════════════════

    /// <summary>Margin uniforme en px. Ej: .M(8)</summary>
    public static T M<T>(this T node, int px) where T : EmailNode
    { node.Style.Margin = px; return node; }

    /// <summary>Margin horizontal (left + right). Ej: .Mx(16)</summary>
    public static T Mx<T>(this T node, int px) where T : EmailNode
    { node.Style.MarginLeft = px; node.Style.MarginRight = px; return node; }

    /// <summary>Margin vertical (top + bottom). Ej: .My(8)</summary>
    public static T My<T>(this T node, int px) where T : EmailNode
    { node.Style.MarginTop = px; node.Style.MarginBottom = px; return node; }

    /// <summary>margin-top</summary>
    public static T Mt<T>(this T node, int px) where T : EmailNode
    { node.Style.MarginTop = px; return node; }

    /// <summary>margin-bottom</summary>
    public static T Mb<T>(this T node, int px) where T : EmailNode
    { node.Style.MarginBottom = px; return node; }

    /// <summary>margin-left</summary>
    public static T Ml<T>(this T node, int px) where T : EmailNode
    { node.Style.MarginLeft = px; return node; }

    /// <summary>margin-right</summary>
    public static T Mr<T>(this T node, int px) where T : EmailNode
    { node.Style.MarginRight = px; return node; }

    /// <summary>mx-auto (margen horizontal auto para centrar bloques).</summary>
    public static T MxAuto<T>(this T node) where T : EmailNode
    {
        // En email no hay "auto" directo en inline styles para margin, pero
        // se usa margin:0 auto con display:block para centrar.
        node.Style.Display = MailCompose.Display.Block;
        node.Style.Width ??= "auto";
        return node;
    }

    /// <summary>Margin uniforme (alias largo).</summary>
    public static T Margin<T>(this T node, int all) where T : EmailNode
    { node.Style.Margin = all; return node; }

    /// <summary>Margin top (alias largo).</summary>
    public static T MarginTop<T>(this T node, int px) where T : EmailNode { node.Style.MarginTop = px; return node; }

    /// <summary>Margin bottom (alias largo).</summary>
    public static T MarginBottom<T>(this T node, int px) where T : EmailNode { node.Style.MarginBottom = px; return node; }

    // ═══════════════════════════════════════════════════════════════
    //  DIMENSIONES — width, height, min/max
    // ═══════════════════════════════════════════════════════════════

    /// <summary>Width libre (ej: "100%", "600px", "auto").</summary>
    public static T W<T>(this T node, string width) where T : EmailNode
    { node.Style.Width = width; return node; }

    /// <summary>Width en px. Ej: .W(200)</summary>
    public static T W<T>(this T node, int px) where T : EmailNode
    { node.Style.Width = $"{px}px"; return node; }

    /// <summary>w-full: 100%</summary>
    public static T WFull<T>(this T node) where T : EmailNode
    { node.Style.Width = TailwindPresets.WFull; return node; }

    /// <summary>w-auto</summary>
    public static T WAuto<T>(this T node) where T : EmailNode
    { node.Style.Width = TailwindPresets.WAuto; return node; }

    /// <summary>w-1/2: 50%</summary>
    public static T WHalf<T>(this T node) where T : EmailNode
    { node.Style.Width = TailwindPresets.WHalf; return node; }

    /// <summary>w-1/3: 33.333%</summary>
    public static T WThird<T>(this T node) where T : EmailNode
    { node.Style.Width = TailwindPresets.WThird; return node; }

    /// <summary>w-2/3: 66.667%</summary>
    public static T WTwoThirds<T>(this T node) where T : EmailNode
    { node.Style.Width = TailwindPresets.WTwoThirds; return node; }

    /// <summary>w-1/4: 25%</summary>
    public static T WQuarter<T>(this T node) where T : EmailNode
    { node.Style.Width = TailwindPresets.WQuarter; return node; }

    /// <summary>w-3/4: 75%</summary>
    public static T WThreeQuarters<T>(this T node) where T : EmailNode
    { node.Style.Width = TailwindPresets.WThreeQuarters; return node; }

    /// <summary>w-1/5: 20%</summary>
    public static T WFifth<T>(this T node) where T : EmailNode
    { node.Style.Width = TailwindPresets.WFifth; return node; }

    /// <summary>Width libre (alias largo).</summary>
    public static T Width<T>(this T node, string width) where T : EmailNode
    { node.Style.Width = width; return node; }

    /// <summary>Height libre (ej: "200px", "100%").</summary>
    public static T H<T>(this T node, string height) where T : EmailNode
    { node.Style.Height = height; return node; }

    /// <summary>Height en px. Ej: .H(48)</summary>
    public static T H<T>(this T node, int px) where T : EmailNode
    { node.Style.Height = $"{px}px"; return node; }

    /// <summary>h-full: 100%</summary>
    public static T HFull<T>(this T node) where T : EmailNode
    { node.Style.Height = TailwindPresets.HFull; return node; }

    /// <summary>h-auto</summary>
    public static T HAuto<T>(this T node) where T : EmailNode
    { node.Style.Height = TailwindPresets.HAuto; return node; }

    /// <summary>Height libre (alias largo).</summary>
    public static T Height<T>(this T node, string height) where T : EmailNode
    { node.Style.Height = height; return node; }

    /// <summary>min-width en px.</summary>
    public static T MinW<T>(this T node, int px) where T : EmailNode
    { node.Style.MinWidth = $"{px}px"; return node; }

    /// <summary>min-width libre.</summary>
    public static T MinW<T>(this T node, string minWidth) where T : EmailNode
    { node.Style.MinWidth = minWidth; return node; }

    /// <summary>max-width en px.</summary>
    public static T MaxW<T>(this T node, int px) where T : EmailNode
    { node.Style.MaxWidth = $"{px}px"; return node; }

    /// <summary>max-width libre (alias largo).</summary>
    public static T MaxWidth<T>(this T node, string maxWidth) where T : EmailNode
    { node.Style.MaxWidth = maxWidth; return node; }

    /// <summary>max-w-xs: 320px</summary>
    public static T MaxWXs<T>(this T node) where T : EmailNode
    { node.Style.MaxWidth = $"{TailwindPresets.MaxWXs}px"; return node; }

    /// <summary>max-w-sm: 384px</summary>
    public static T MaxWSm<T>(this T node) where T : EmailNode
    { node.Style.MaxWidth = $"{TailwindPresets.MaxWSm}px"; return node; }

    /// <summary>max-w-md: 448px</summary>
    public static T MaxWMd<T>(this T node) where T : EmailNode
    { node.Style.MaxWidth = $"{TailwindPresets.MaxWMd}px"; return node; }

    /// <summary>max-w-lg: 512px</summary>
    public static T MaxWLg<T>(this T node) where T : EmailNode
    { node.Style.MaxWidth = $"{TailwindPresets.MaxWLg}px"; return node; }

    /// <summary>max-w-xl: 576px</summary>
    public static T MaxWXl<T>(this T node) where T : EmailNode
    { node.Style.MaxWidth = $"{TailwindPresets.MaxWXl}px"; return node; }

    /// <summary>max-w-2xl: 672px</summary>
    public static T MaxW2Xl<T>(this T node) where T : EmailNode
    { node.Style.MaxWidth = $"{TailwindPresets.MaxW2Xl}px"; return node; }

    /// <summary>max-w-3xl: 768px</summary>
    public static T MaxW3Xl<T>(this T node) where T : EmailNode
    { node.Style.MaxWidth = $"{TailwindPresets.MaxW3Xl}px"; return node; }

    /// <summary>max-w-full: 100%</summary>
    public static T MaxWFull<T>(this T node) where T : EmailNode
    { node.Style.MaxWidth = "100%"; return node; }

    /// <summary>max-w-prose: 640px (optimal reading width)</summary>
    public static T MaxWProse<T>(this T node) where T : EmailNode
    { node.Style.MaxWidth = $"{TailwindPresets.MaxWProse}px"; return node; }

    /// <summary>min-height en px.</summary>
    public static T MinH<T>(this T node, int px) where T : EmailNode
    { node.Style.MinHeight = $"{px}px"; return node; }

    /// <summary>min-height libre.</summary>
    public static T MinH<T>(this T node, string minHeight) where T : EmailNode
    { node.Style.MinHeight = minHeight; return node; }

    /// <summary>max-height en px.</summary>
    public static T MaxH<T>(this T node, int px) where T : EmailNode
    { node.Style.MaxHeight = $"{px}px"; return node; }

    /// <summary>max-height libre.</summary>
    public static T MaxH<T>(this T node, string maxHeight) where T : EmailNode
    { node.Style.MaxHeight = maxHeight; return node; }

    /// <summary>size: width = height (cuadrado). Ej: .Size(48)</summary>
    public static T Size<T>(this T node, int px) where T : EmailNode
    { node.Style.Width = $"{px}px"; node.Style.Height = $"{px}px"; return node; }

    /// <summary>size libre: width = height. Ej: .Size("100%")</summary>
    public static T Size<T>(this T node, string size) where T : EmailNode
    { node.Style.Width = size; node.Style.Height = size; return node; }

    // ═══════════════════════════════════════════════════════════════
    //  LAYOUT — Display, Vertical Align, Overflow
    // ═══════════════════════════════════════════════════════════════

    /// <summary>display: block</summary>
    public static T Block<T>(this T node) where T : EmailNode
    { node.Style.Display = MailCompose.Display.Block; return node; }

    /// <summary>display: inline-block</summary>
    public static T InlineBlock<T>(this T node) where T : EmailNode
    { node.Style.Display = MailCompose.Display.InlineBlock; return node; }

    /// <summary>display: inline</summary>
    public static T Inline<T>(this T node) where T : EmailNode
    { node.Style.Display = MailCompose.Display.Inline; return node; }

    /// <summary>display: none (hidden)</summary>
    public static T Hidden<T>(this T node) where T : EmailNode
    { node.Style.Display = MailCompose.Display.None; return node; }

    /// <summary>vertical-align: top</summary>
    public static T AlignTop<T>(this T node) where T : EmailNode
    { node.Style.VerticalAlign = MailCompose.VerticalAlign.Top; return node; }

    /// <summary>vertical-align: middle</summary>
    public static T AlignMiddle<T>(this T node) where T : EmailNode
    { node.Style.VerticalAlign = MailCompose.VerticalAlign.Middle; return node; }

    /// <summary>vertical-align: bottom</summary>
    public static T AlignBottom<T>(this T node) where T : EmailNode
    { node.Style.VerticalAlign = MailCompose.VerticalAlign.Bottom; return node; }

    /// <summary>vertical-align: baseline</summary>
    public static T AlignBaseline<T>(this T node) where T : EmailNode
    { node.Style.VerticalAlign = MailCompose.VerticalAlign.Baseline; return node; }

    /// <summary>overflow: hidden</summary>
    public static T OverflowHidden<T>(this T node) where T : EmailNode
    { node.Style.Overflow = MailCompose.Overflow.Hidden; return node; }

    /// <summary>overflow: visible</summary>
    public static T OverflowVisible<T>(this T node) where T : EmailNode
    { node.Style.Overflow = MailCompose.Overflow.Visible; return node; }

    /// <summary>overflow: auto</summary>
    public static T OverflowAuto<T>(this T node) where T : EmailNode
    { node.Style.Overflow = MailCompose.Overflow.Auto; return node; }

    /// <summary>overflow: scroll</summary>
    public static T OverflowScroll<T>(this T node) where T : EmailNode
    { node.Style.Overflow = MailCompose.Overflow.Scroll; return node; }

    /// <summary>overflow-x: hidden</summary>
    public static T OverflowXHidden<T>(this T node) where T : EmailNode
    { node.Style.OverflowX = MailCompose.Overflow.Hidden; return node; }

    /// <summary>overflow-y: hidden</summary>
    public static T OverflowYHidden<T>(this T node) where T : EmailNode
    { node.Style.OverflowY = MailCompose.Overflow.Hidden; return node; }

    // ═══════════════════════════════════════════════════════════════
    //  SHADOW — box-shadow presets
    //  (funciona en Gmail, Apple Mail, Yahoo; NO en Outlook)
    // ═══════════════════════════════════════════════════════════════

    /// <summary>shadow-sm</summary>
    public static T ShadowSm<T>(this T node) where T : EmailNode
    { node.Style.BoxShadow = TailwindPresets.ShadowSm; return node; }

    /// <summary>shadow (default)</summary>
    public static T Shadow<T>(this T node) where T : EmailNode
    { node.Style.BoxShadow = TailwindPresets.Shadow; return node; }

    /// <summary>shadow-md</summary>
    public static T ShadowMd<T>(this T node) where T : EmailNode
    { node.Style.BoxShadow = TailwindPresets.ShadowMd; return node; }

    /// <summary>shadow-lg</summary>
    public static T ShadowLg<T>(this T node) where T : EmailNode
    { node.Style.BoxShadow = TailwindPresets.ShadowLg; return node; }

    /// <summary>shadow-xl</summary>
    public static T ShadowXl<T>(this T node) where T : EmailNode
    { node.Style.BoxShadow = TailwindPresets.ShadowXl; return node; }

    /// <summary>shadow-2xl</summary>
    public static T Shadow2Xl<T>(this T node) where T : EmailNode
    { node.Style.BoxShadow = TailwindPresets.Shadow2Xl; return node; }

    /// <summary>shadow-inner</summary>
    public static T ShadowInner<T>(this T node) where T : EmailNode
    { node.Style.BoxShadow = TailwindPresets.ShadowInner; return node; }

    /// <summary>shadow-none</summary>
    public static T ShadowNone<T>(this T node) where T : EmailNode
    { node.Style.BoxShadow = TailwindPresets.ShadowNone; return node; }

    /// <summary>Box shadow libre.</summary>
    public static T Shadow<T>(this T node, string shadow) where T : EmailNode
    { node.Style.BoxShadow = shadow; return node; }

    // ═══════════════════════════════════════════════════════════════
    //  OPACITY
    // ═══════════════════════════════════════════════════════════════

    /// <summary>Opacidad libre (0.0 a 1.0).</summary>
    public static T Opacity<T>(this T node, double opacity) where T : EmailNode
    { node.Style.Opacity = Math.Clamp(opacity, 0.0, 1.0); return node; }

    /// <summary>opacity-0</summary>
    public static T Opacity0<T>(this T node) where T : EmailNode
    { node.Style.Opacity = 0.0; return node; }

    /// <summary>opacity-25</summary>
    public static T Opacity25<T>(this T node) where T : EmailNode
    { node.Style.Opacity = 0.25; return node; }

    /// <summary>opacity-50</summary>
    public static T Opacity50<T>(this T node) where T : EmailNode
    { node.Style.Opacity = 0.50; return node; }

    /// <summary>opacity-75</summary>
    public static T Opacity75<T>(this T node) where T : EmailNode
    { node.Style.Opacity = 0.75; return node; }

    /// <summary>opacity-100</summary>
    public static T Opacity100<T>(this T node) where T : EmailNode
    { node.Style.Opacity = 1.0; return node; }

    // ═══════════════════════════════════════════════════════════════
    //  CURSOR
    // ═══════════════════════════════════════════════════════════════

    /// <summary>cursor: pointer</summary>
    public static T CursorPointer<T>(this T node) where T : EmailNode
    { node.Style.Cursor = "pointer"; return node; }

    /// <summary>cursor: default</summary>
    public static T CursorDefault<T>(this T node) where T : EmailNode
    { node.Style.Cursor = "default"; return node; }

    /// <summary>cursor: not-allowed</summary>
    public static T CursorNotAllowed<T>(this T node) where T : EmailNode
    { node.Style.Cursor = "not-allowed"; return node; }
}
