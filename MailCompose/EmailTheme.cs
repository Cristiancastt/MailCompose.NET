namespace MailCompose;

/// <summary>
/// Tema visual del email. Define colores base, fuentes y layout.
/// Presets inspirados en Tailwind CSS.
/// </summary>
public sealed class EmailTheme
{
    /// <summary>Título del documento HTML (tag title).</summary>
    public string Title { get; set; } = "";

    /// <summary>Familia de fuentes base.</summary>
    public string FontFamily { get; set; } =
        "-apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, 'Helvetica Neue', Arial, sans-serif";

    /// <summary>Tamaño de fuente base en px.</summary>
    public int BaseFontSize { get; set; } = 16;

    /// <summary>Color de texto base.</summary>
    public string BaseTextColor { get; set; } = TailwindColors.Gray800;

    /// <summary>Altura de línea base.</summary>
    public string BaseLineHeight { get; set; } = "1.5";

    /// <summary>Color de fondo del body exterior.</summary>
    public string BodyBackground { get; set; } = TailwindColors.Gray100;

    /// <summary>Color de fondo del contenedor principal.</summary>
    public string ContentBackground { get; set; } = TailwindColors.White;

    /// <summary>Ancho máximo del contenido en px.</summary>
    public int ContentMaxWidth { get; set; } = 600;

    /// <summary>Padding del contenedor principal.</summary>
    public int ContentPadding { get; set; } = 32;

    /// <summary>Border radius del contenedor principal.</summary>
    public int ContentBorderRadius { get; set; } = 8;

    /// <summary>Texto del footer (null para omitir).</summary>
    public string? FooterText { get; set; }

    /// <summary>Tema por defecto: limpio, Tailwind-inspired.</summary>
    public static EmailTheme Default => new();

    /// <summary>Tema oscuro.</summary>
    public static EmailTheme Dark => new()
    {
        BodyBackground = TailwindColors.Gray900,
        ContentBackground = TailwindColors.Gray800,
        BaseTextColor = TailwindColors.Gray100,
    };

    /// <summary>Tema minimal sin fondo exterior.</summary>
    public static EmailTheme Minimal => new()
    {
        BodyBackground = TailwindColors.White,
        ContentBackground = TailwindColors.White,
        ContentBorderRadius = 0,
        ContentPadding = 24,
    };

    /// <summary>Tema con estilo de marca / branding.</summary>
    public static EmailTheme Brand(string primaryColor, string bgColor = "#ffffff") => new()
    {
        BodyBackground = bgColor,
        ContentBackground = TailwindColors.White,
        BaseTextColor = TailwindColors.Gray800,
    };
}
