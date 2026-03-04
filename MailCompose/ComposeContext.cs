using MailCompose.Nodes;

namespace MailCompose;

/// <summary>
/// Contexto interno de composición. Usa un stack para rastrear
/// el nodo padre actual durante la construcción del árbol.
/// Patrón idéntico al de Kotlin Compose / SwiftUI.
/// </summary>
internal sealed class ComposeContext
{
    private readonly Stack<EmailNode> _stack = new();

    /// <summary>
    /// Nodo raíz del árbol.
    /// </summary>
    public EmailNode? Root { get; private set; }

    /// <summary>
    /// Agrega un nodo hijo al padre actual (top del stack).
    /// Si no hay padre, se convierte en el root.
    /// </summary>
    public T Add<T>(T node) where T : EmailNode
    {
        if (_stack.Count > 0)
        {
            _stack.Peek().Children.Add(node);
        }
        else if (Root == null)
        {
            Root = node;
        }
        else
        {
            // Si ya hay root y no hay stack, envolver en Column implícita
            var wrapper = new ColumnNode();
            wrapper.Children.Add(Root);
            wrapper.Children.Add(node);
            Root = wrapper;
        }

        return node;
    }

    /// <summary>
    /// Abre un nodo contenedor: lo agrega al padre, lo pushea al stack,
    /// ejecuta el bloque de contenido, y lo popea.
    /// </summary>
    public T Open<T>(T container, Action content) where T : EmailNode
    {
        Add(container);
        _stack.Push(container);
        content();
        _stack.Pop();
        return container;
    }
}
