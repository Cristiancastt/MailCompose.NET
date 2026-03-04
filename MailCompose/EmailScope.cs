using MailCompose.Nodes;

namespace MailCompose;

/// <summary>
/// Scope de composición que expone las funciones de construcción del email.
/// El usuario interactúa con este objeto dentro de Email.Compose().
/// </summary>
public sealed class EmailScope
{
    private readonly ComposeContext _ctx;

    internal EmailScope(ComposeContext ctx)
    {
        _ctx = ctx;
    }

    // ── Contenedores ──────────────────────────────────────────────

    /// <summary>
    /// Contenedor vertical (columna). Los hijos se apilan uno debajo del otro.
    /// </summary>
    public ColumnNode Column(Action content)
        => Column(0, 0, content);

    /// <summary>
    /// Contenedor vertical con espaciado.
    /// </summary>
    public ColumnNode Column(int spacing, Action content)
        => Column(spacing, 0, content);

    /// <summary>
    /// Contenedor vertical con espaciado y padding.
    /// </summary>
    public ColumnNode Column(int spacing, int padding, Action content)
    {
        var node = new ColumnNode(spacing, padding);
        return _ctx.Open(node, content);
    }

    /// <summary>
    /// Contenedor horizontal (fila). Los hijos van lado a lado.
    /// </summary>
    public RowNode Row(Action content)
        => Row(0, 0, content);

    /// <summary>
    /// Contenedor horizontal con espaciado.
    /// </summary>
    public RowNode Row(int spacing, Action content)
        => Row(spacing, 0, content);

    /// <summary>
    /// Contenedor horizontal con espaciado y padding.
    /// </summary>
    public RowNode Row(int spacing, int padding, Action content)
    {
        var node = new RowNode(spacing, padding);
        return _ctx.Open(node, content);
    }

    /// <summary>
    /// Contenedor genérico (card, section, wrapper).
    /// </summary>
    public ContainerNode Container(Action content)
    {
        var node = new ContainerNode();
        return _ctx.Open(node, content);
    }

    // ── Elementos leaf ────────────────────────────────────────────

    /// <summary>
    /// Texto simple.
    /// </summary>
    public TextNode Text(string content)
    {
        var node = new TextNode(content);
        return _ctx.Add(node);
    }

    /// <summary>
    /// Encabezado (h1-h4).
    /// </summary>
    public TextNode Heading(string content, int level = 1)
    {
        var node = new TextNode(content);
        node.Style.IsHeading = true;
        node.Style.HeadingLevel = Math.Clamp(level, 1, 4);
        node.Style.FontWeight = level <= 2 ? MailCompose.FontWeight.Bold : MailCompose.FontWeight.SemiBold;
        node.Style.FontSize = level switch
        {
            1 => 28,
            2 => 24,
            3 => 20,
            4 => 16,
            _ => 28
        };
        return _ctx.Add(node);
    }

    /// <summary>
    /// Botón de acción (CTA).
    /// </summary>
    public ButtonNode Button(string label, string? href = null)
    {
        var node = new ButtonNode(label) { Href = href };
        return _ctx.Add(node);
    }

    /// <summary>
    /// Imagen.
    /// </summary>
    public ImageNode Image(string src, string alt = "", int? width = null, int? height = null)
    {
        var node = new ImageNode(src, alt) { Width = width, Height = height };
        return _ctx.Add(node);
    }

    /// <summary>
    /// Enlace de texto.
    /// </summary>
    public LinkNode Link(string href, string text)
    {
        var node = new LinkNode(href, text);
        return _ctx.Add(node);
    }

    /// <summary>
    /// Línea divisora horizontal.
    /// </summary>
    public DividerNode Divider(string? color = null, int thickness = 1, int marginVertical = 16)
    {
        var node = new DividerNode();
        if (color != null) node.Color = color;
        node.Thickness = thickness;
        node.MarginVertical = marginVertical;
        return _ctx.Add(node);
    }

    /// <summary>
    /// Espaciador vertical.
    /// </summary>
    public SpacerNode Spacer(int height = 16)
    {
        var node = new SpacerNode(height);
        return _ctx.Add(node);
    }

    // ── Iteración (ForEach) ───────────────────────────────────────

    /// <summary>
    /// Itera sobre una colección y compone cada elemento.
    /// </summary>
    public void ForEach<T>(IEnumerable<T> items, Action<T> builder)
    {
        foreach (var item in items)
            builder(item);
    }

    // ── Condicional ───────────────────────────────────────────────

    /// <summary>
    /// Agrega contenido condicionalmente.
    /// </summary>
    public void When(bool condition, Action content)
    {
        if (condition)
            content();
    }

    /// <summary>
    /// Agrega contenido condicionalmente con else.
    /// </summary>
    public void When(bool condition, Action ifTrue, Action ifFalse)
    {
        if (condition)
            ifTrue();
        else
            ifFalse();
    }
}
