namespace MailCompose.Nodes;

/// <summary>
/// Nodo base abstracto del árbol de composición de email.
/// Cada nodo representa un elemento visual del correo.
/// </summary>
public abstract class EmailNode
{
    /// <summary>
    /// Estilos inline aplicados a este nodo.
    /// </summary>
    public NodeStyle Style { get; } = new();

    /// <summary>
    /// Hijos de este nodo (solo para nodos contenedores).
    /// </summary>
    public List<EmailNode> Children { get; } = [];

    /// <summary>
    /// Renderiza este nodo a HTML email-safe usando el writer.
    /// </summary>
    public abstract void Render(HtmlWriter writer);

    /// <summary>
    /// Representación en texto plano del árbol (debug).
    /// </summary>
    public string DumpTree(int indent = 0)
    {
        var prefix = new string(' ', indent * 2);
        var name = GetType().Name.Replace("Node", "");
        var info = GetDebugInfo();
        var line = string.IsNullOrEmpty(info) ? $"{prefix}{name}" : $"{prefix}{name}({info})";

        if (Children.Count == 0)
            return line;

        var childLines = Children.Select(c => c.DumpTree(indent + 1));
        return line + Environment.NewLine + string.Join(Environment.NewLine, childLines);
    }

    /// <summary>
    /// Info extra para debug (ej: texto del nodo).
    /// </summary>
    protected virtual string GetDebugInfo() => "";
}
