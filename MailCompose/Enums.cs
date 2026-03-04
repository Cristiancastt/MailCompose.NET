namespace MailCompose;

// ── Tipografía ───────────────────────────────────────────────────

/// <summary>Alineación de texto.</summary>
public enum TextAlign { Left, Center, Right, Justify }

/// <summary>Peso de fuente tipado.</summary>
public enum FontWeight
{
    Thin,       // 100
    ExtraLight, // 200
    Light,      // 300
    Normal,     // 400
    Medium,     // 500
    SemiBold,   // 600
    Bold,       // 700
    ExtraBold,  // 800
    Black       // 900
}

/// <summary>Transformación de texto (uppercase, lowercase, capitalize).</summary>
public enum TextTransform { None, Uppercase, Lowercase, Capitalize }

/// <summary>Desbordamiento de texto con ellipsis.</summary>
public enum TextOverflow { Clip, Ellipsis }

// ── Layout ───────────────────────────────────────────────────────

/// <summary>Alineación vertical (celdas de tabla en email).</summary>
public enum VerticalAlign { Top, Middle, Bottom, Baseline }

/// <summary>Display CSS (subset compatible con email).</summary>
public enum Display { Block, InlineBlock, Inline, None }

/// <summary>White-space CSS.</summary>
public enum WhiteSpace { Normal, Nowrap, Pre, PreWrap, PreLine }

/// <summary>Word-break CSS.</summary>
public enum WordBreak { Normal, BreakAll, BreakWord, KeepAll }

/// <summary>Overflow CSS.</summary>
public enum Overflow { Visible, Hidden, Auto, Scroll }

/// <summary>Estilo de borde CSS.</summary>
public enum BorderStyleType { None, Solid, Dashed, Dotted, Double, Groove, Ridge, Inset, Outset }

// ── Extensiones de conversión a CSS ─────────────────────────────

/// <summary>
/// Extensiones para convertir enums a valores CSS inline.
/// </summary>
public static class EnumExtensions
{
    public static string ToCss(this TextAlign align) => align switch
    {
        TextAlign.Left => "left",
        TextAlign.Center => "center",
        TextAlign.Right => "right",
        TextAlign.Justify => "justify",
        _ => "left"
    };

    public static string ToCss(this FontWeight weight) => weight switch
    {
        FontWeight.Thin => "100",
        FontWeight.ExtraLight => "200",
        FontWeight.Light => "300",
        FontWeight.Normal => "400",
        FontWeight.Medium => "500",
        FontWeight.SemiBold => "600",
        FontWeight.Bold => "700",
        FontWeight.ExtraBold => "800",
        FontWeight.Black => "900",
        _ => "400"
    };

    public static string ToCss(this TextTransform transform) => transform switch
    {
        TextTransform.Uppercase => "uppercase",
        TextTransform.Lowercase => "lowercase",
        TextTransform.Capitalize => "capitalize",
        _ => "none"
    };

    public static string ToCss(this TextOverflow overflow) => overflow switch
    {
        TextOverflow.Ellipsis => "ellipsis",
        _ => "clip"
    };

    public static string ToCss(this VerticalAlign align) => align switch
    {
        VerticalAlign.Top => "top",
        VerticalAlign.Middle => "middle",
        VerticalAlign.Bottom => "bottom",
        VerticalAlign.Baseline => "baseline",
        _ => "top"
    };

    public static string ToCss(this Display display) => display switch
    {
        Display.Block => "block",
        Display.InlineBlock => "inline-block",
        Display.Inline => "inline",
        Display.None => "none",
        _ => "block"
    };

    public static string ToCss(this WhiteSpace ws) => ws switch
    {
        WhiteSpace.Nowrap => "nowrap",
        WhiteSpace.Pre => "pre",
        WhiteSpace.PreWrap => "pre-wrap",
        WhiteSpace.PreLine => "pre-line",
        _ => "normal"
    };

    public static string ToCss(this WordBreak wb) => wb switch
    {
        WordBreak.BreakAll => "break-all",
        WordBreak.BreakWord => "break-word",
        WordBreak.KeepAll => "keep-all",
        _ => "normal"
    };

    public static string ToCss(this Overflow overflow) => overflow switch
    {
        Overflow.Hidden => "hidden",
        Overflow.Auto => "auto",
        Overflow.Scroll => "scroll",
        _ => "visible"
    };

    public static string ToCss(this BorderStyleType style) => style switch
    {
        BorderStyleType.None => "none",
        BorderStyleType.Dashed => "dashed",
        BorderStyleType.Dotted => "dotted",
        BorderStyleType.Double => "double",
        BorderStyleType.Groove => "groove",
        BorderStyleType.Ridge => "ridge",
        BorderStyleType.Inset => "inset",
        BorderStyleType.Outset => "outset",
        _ => "solid"
    };
}
