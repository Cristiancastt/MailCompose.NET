namespace MailCompose;

/// <summary>
/// Escalas y presets de Tailwind CSS mapeados a valores concretos
/// para uso directo en emails (px en lugar de rem).
/// Base: 1rem = 16px, 1 unidad spacing = 4px.
/// </summary>
public static class TailwindPresets
{
    // ═══════════════════════════════════════════════════════════════
    //  Spacing Scale (px) — Tailwind: 0, 0.5, 1, 1.5 ... 96
    //  Cada unidad = 4px. Ej: Space4 = 16px (Tailwind "4")
    // ═══════════════════════════════════════════════════════════════

    public const int Space0 = 0;       // 0
    public const int SpacePx = 1;      // 1px
    public const int Space05 = 2;      // 0.5 → 2px
    public const int Space1 = 4;       // 1 → 4px
    public const int Space15 = 6;      // 1.5 → 6px
    public const int Space2 = 8;       // 2 → 8px
    public const int Space25 = 10;     // 2.5 → 10px
    public const int Space3 = 12;      // 3 → 12px
    public const int Space35 = 14;     // 3.5 → 14px
    public const int Space4 = 16;      // 4 → 16px
    public const int Space5 = 20;      // 5 → 20px
    public const int Space6 = 24;      // 6 → 24px
    public const int Space7 = 28;      // 7 → 28px
    public const int Space8 = 32;      // 8 → 32px
    public const int Space9 = 36;      // 9 → 36px
    public const int Space10 = 40;     // 10 → 40px
    public const int Space11 = 44;     // 11 → 44px
    public const int Space12 = 48;     // 12 → 48px
    public const int Space14 = 56;     // 14 → 56px
    public const int Space16 = 64;     // 16 → 64px
    public const int Space20 = 80;     // 20 → 80px
    public const int Space24 = 96;     // 24 → 96px
    public const int Space28 = 112;    // 28 → 112px
    public const int Space32 = 128;    // 32 → 128px
    public const int Space36 = 144;    // 36 → 144px
    public const int Space40 = 160;    // 40 → 160px
    public const int Space44 = 176;    // 44 → 176px
    public const int Space48 = 192;    // 48 → 192px
    public const int Space52 = 208;    // 52 → 208px
    public const int Space56 = 224;    // 56 → 224px
    public const int Space60 = 240;    // 60 → 240px
    public const int Space64 = 256;    // 64 → 256px
    public const int Space72 = 288;    // 72 → 288px
    public const int Space80 = 320;    // 80 → 320px
    public const int Space96 = 384;    // 96 → 384px

    // ═══════════════════════════════════════════════════════════════
    //  Font Size Scale (px) — text-xs, text-sm ... text-9xl
    // ═══════════════════════════════════════════════════════════════

    public const int TextXs = 12;      // 0.75rem
    public const int TextSm = 14;      // 0.875rem
    public const int TextBase = 16;    // 1rem
    public const int TextLg = 18;      // 1.125rem
    public const int TextXl = 20;      // 1.25rem
    public const int Text2Xl = 24;     // 1.5rem
    public const int Text3Xl = 30;     // 1.875rem
    public const int Text4Xl = 36;     // 2.25rem
    public const int Text5Xl = 48;     // 3rem
    public const int Text6Xl = 60;     // 3.75rem
    public const int Text7Xl = 72;     // 4.5rem
    public const int Text8Xl = 96;     // 6rem
    public const int Text9Xl = 128;    // 8rem

    // Line height correspondiente a cada text size (Tailwind defaults)
    public const int TextXsLh = 16;
    public const int TextSmLh = 20;
    public const int TextBaseLh = 24;
    public const int TextLgLh = 28;
    public const int TextXlLh = 28;
    public const int Text2XlLh = 32;
    public const int Text3XlLh = 36;
    public const int Text4XlLh = 40;
    public const int Text5XlLh = 48;    // 1
    public const int Text6XlLh = 60;    // 1
    public const int Text7XlLh = 72;    // 1
    public const int Text8XlLh = 96;    // 1
    public const int Text9XlLh = 128;   // 1

    // ═══════════════════════════════════════════════════════════════
    //  Border Radius Scale (px) — rounded-none ... rounded-full
    // ═══════════════════════════════════════════════════════════════

    public const int RoundedNone = 0;
    public const int RoundedSm = 2;      // 0.125rem
    public const int Rounded = 4;        // 0.25rem  (rounded)
    public const int RoundedMd = 6;      // 0.375rem
    public const int RoundedLg = 8;      // 0.5rem
    public const int RoundedXl = 12;     // 0.75rem
    public const int Rounded2Xl = 16;    // 1rem
    public const int Rounded3Xl = 24;    // 1.5rem
    public const int RoundedFull = 9999; // pill/circle

    // ═══════════════════════════════════════════════════════════════
    //  Box Shadow Presets — shadow-sm ... shadow-2xl
    //  Nota: box-shadow no funciona en Outlook pero sí en
    //  Gmail, Apple Mail, Yahoo, etc.
    // ═══════════════════════════════════════════════════════════════

    public const string ShadowSm = "0 1px 2px 0 rgba(0,0,0,0.05)";
    public const string Shadow = "0 1px 3px 0 rgba(0,0,0,0.1),0 1px 2px -1px rgba(0,0,0,0.1)";
    public const string ShadowMd = "0 4px 6px -1px rgba(0,0,0,0.1),0 2px 4px -2px rgba(0,0,0,0.1)";
    public const string ShadowLg = "0 10px 15px -3px rgba(0,0,0,0.1),0 4px 6px -4px rgba(0,0,0,0.1)";
    public const string ShadowXl = "0 20px 25px -5px rgba(0,0,0,0.1),0 8px 10px -6px rgba(0,0,0,0.1)";
    public const string Shadow2Xl = "0 25px 50px -12px rgba(0,0,0,0.25)";
    public const string ShadowInner = "inset 0 2px 4px 0 rgba(0,0,0,0.05)";
    public const string ShadowNone = "none";

    // ═══════════════════════════════════════════════════════════════
    //  Font Family Stacks — Tailwind default
    // ═══════════════════════════════════════════════════════════════

    public const string FontSans =
        "-apple-system,BlinkMacSystemFont,'Segoe UI',Roboto,'Helvetica Neue',Arial,'Noto Sans',sans-serif";
    public const string FontSerif =
        "ui-serif,Georgia,Cambria,'Times New Roman',Times,serif";
    public const string FontMono =
        "ui-monospace,SFMono-Regular,Menlo,Monaco,Consolas,'Liberation Mono','Courier New',monospace";

    // ═══════════════════════════════════════════════════════════════
    //  Max Width Presets — max-w-xs ... max-w-7xl (px)
    // ═══════════════════════════════════════════════════════════════

    public const int MaxWXs = 320;
    public const int MaxWSm = 384;
    public const int MaxWMd = 448;
    public const int MaxWLg = 512;
    public const int MaxWXl = 576;
    public const int MaxW2Xl = 672;
    public const int MaxW3Xl = 768;
    public const int MaxW4Xl = 896;
    public const int MaxW5Xl = 1024;
    public const int MaxW6Xl = 1152;
    public const int MaxW7Xl = 1280;
    public const int MaxWFull = -1;      // sentinel → "100%"
    public const int MaxWProse = 640;    // max-w-prose (65ch ≈ 640px)

    // ═══════════════════════════════════════════════════════════════
    //  Line Height Presets (multiplicadores)
    // ═══════════════════════════════════════════════════════════════

    public const double LeadingNone = 1.0;
    public const double LeadingTight = 1.25;
    public const double LeadingSnug = 1.375;
    public const double LeadingNormal = 1.5;
    public const double LeadingRelaxed = 1.625;
    public const double LeadingLoose = 2.0;

    // ═══════════════════════════════════════════════════════════════
    //  Letter Spacing Presets (em)
    // ═══════════════════════════════════════════════════════════════

    public const double TrackingTighter = -0.05;
    public const double TrackingTight = -0.025;
    public const double TrackingNormal = 0.0;
    public const double TrackingWide = 0.025;
    public const double TrackingWider = 0.05;
    public const double TrackingWidest = 0.1;

    // ═══════════════════════════════════════════════════════════════
    //  Opacity Scale — opacity-0 ... opacity-100
    // ═══════════════════════════════════════════════════════════════

    public const double Opacity0 = 0.0;
    public const double Opacity5 = 0.05;
    public const double Opacity10 = 0.10;
    public const double Opacity15 = 0.15;
    public const double Opacity20 = 0.20;
    public const double Opacity25 = 0.25;
    public const double Opacity30 = 0.30;
    public const double Opacity40 = 0.40;
    public const double Opacity50 = 0.50;
    public const double Opacity60 = 0.60;
    public const double Opacity70 = 0.70;
    public const double Opacity75 = 0.75;
    public const double Opacity80 = 0.80;
    public const double Opacity90 = 0.90;
    public const double Opacity95 = 0.95;
    public const double Opacity100 = 1.0;

    // ═══════════════════════════════════════════════════════════════
    //  Border Width Presets
    // ═══════════════════════════════════════════════════════════════

    public const int Border0 = 0;
    public const int Border = 1;
    public const int Border2 = 2;
    public const int Border4 = 4;
    public const int Border8 = 8;

    // ═══════════════════════════════════════════════════════════════
    //  Width / Height Percentages (strings)
    // ═══════════════════════════════════════════════════════════════

    public const string WFull = "100%";
    public const string WHalf = "50%";
    public const string WThird = "33.333%";
    public const string WTwoThirds = "66.667%";
    public const string WQuarter = "25%";
    public const string WThreeQuarters = "75%";
    public const string WFifth = "20%";
    public const string WAuto = "auto";
    public const string WScreen = "100vw";
    public const string WMin = "min-content";
    public const string WMax = "max-content";
    public const string WFit = "fit-content";

    public const string HFull = "100%";
    public const string HAuto = "auto";
    public const string HScreen = "100vh";

    /// <summary>
    /// Convierte un valor Tailwind spacing (1-96) a px.
    /// Ej: SpacingToPx(4) = 16
    /// </summary>
    public static int SpacingToPx(double tailwindUnits) => (int)(tailwindUnits * 4);

    /// <summary>
    /// Genera un string de width en px. Ej: WidthPx(200) → "200px"
    /// </summary>
    public static string WidthPx(int px) => $"{px}px";

    /// <summary>
    /// Genera un string de height en px.
    /// </summary>
    public static string HeightPx(int px) => $"{px}px";
}
