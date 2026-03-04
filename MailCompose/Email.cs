using MailCompose.Nodes;

namespace MailCompose;

/// <summary>
/// Punto de entrada principal de la librería.
/// API declarativa estilo Compose para construir emails.
/// </summary>
public static class Email
{
    [ThreadStatic]
    private static ComposeContext? _current;

    /// <summary>
    /// Contexto actual de composición (solo válido dentro de Compose).
    /// </summary>
    internal static ComposeContext Current =>
        _current ?? throw new InvalidOperationException(
            "Las funciones de composición solo pueden usarse dentro de Email.Compose().");

    /// <summary>
    /// Compone un email declarativamente y devuelve un EmailDocument.
    /// </summary>
    /// <example>
    /// var doc = Email.Compose(ctx =>
    /// {
    ///     ctx.Column(spacing: 12, padding: 16, () =>
    ///     {
    ///         ctx.Text("Hola Juan").Bold().FontSize(20);
    ///         ctx.Text("Gracias por tu compra");
    ///         ctx.Button("Ver pedido", "https://example.com")
    ///             .Background(TailwindColors.Blue600);
    ///     });
    /// });
    /// string html = doc.Render();
    /// </example>
    public static EmailDocument Compose(Action<EmailScope> builder)
    {
        var ctx = new ComposeContext();
        _current = ctx;
        try
        {
            var scope = new EmailScope(ctx);
            builder(scope);
            return new EmailDocument(ctx.Root
                ?? throw new InvalidOperationException("El email no contiene ningún nodo."));
        }
        finally
        {
            _current = null;
        }
    }
}
