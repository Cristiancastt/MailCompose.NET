using MailCompose;

// ══════════════════════════════════════════════════════════════
// MailCompose.NET — Ejemplos de uso
// Declarative Email UI for .NET
// ══════════════════════════════════════════════════════════════

Directory.CreateDirectory("Output");

// ╔═══════════════════════════════════════════════════════════╗
// ║  BÁSICOS (1-7): plantillas esenciales                    ║
// ╚═══════════════════════════════════════════════════════════╝

// ── 1. Confirmación de email ────────────────────────────────
var confirmEmail = Email.Compose(ctx =>
{
    ctx.Column(spacing: 16, padding: 0, () =>
    {
        ctx.Heading("Confirma tu email", level: 2)
            .TextColor(TailwindColors.Gray900);

        ctx.Text("Por favor confirma tu dirección de correo haciendo clic en el botón de abajo.")
            .TextColor(TailwindColors.Gray600);

        ctx.Text("Necesitamos enviar información importante sobre tu servicio y es crucial tener un email válido.")
            .TextColor(TailwindColors.Gray600);

        ctx.Button("Confirmar Email", "https://example.com/confirm")
            .Background(TailwindColors.Blue600);

        ctx.Text("— El equipo de Example")
            .TextColor(TailwindColors.Gray400)
            .FontSize(14)
            .Italic();
    });
});

confirmEmail.WithTheme(t =>
{
    t.Title = "Confirma tu email";
    t.FooterText = "Si no solicitaste esto, puedes ignorar este mensaje.";
});

File.WriteAllText("Output/ConfirmEmail.html", confirmEmail.Render());
Console.WriteLine("✔ ConfirmEmail.html");

// ── 2. Reset de contraseña ──────────────────────────────────
var passwordReset = Email.Compose(ctx =>
{
    ctx.Column(spacing: 16, () =>
    {
        ctx.Heading("Restablecer contraseña", level: 2)
            .TextColor(TailwindColors.Gray900);

        ctx.Text("Recibimos una solicitud para restablecer la contraseña de tu cuenta.")
            .TextColor(TailwindColors.Gray600);

        ctx.Text("Haz clic en el botón para crear una nueva contraseña:");

        ctx.Button("Restablecer contraseña", "https://example.com/reset?token=abc123")
            .Background(TailwindColors.Red600);

        ctx.Divider();

        ctx.Text("Si no solicitaste esto, ignora este correo. Tu contraseña no cambiará.")
            .FontSize(13)
            .TextColor(TailwindColors.Gray400)
            .Italic();
    });
});

passwordReset.WithTheme(t => t.Title = "Restablecer contraseña");
File.WriteAllText("Output/PasswordReset.html", passwordReset.Render());
Console.WriteLine("✔ PasswordReset.html");

// ── 3. Confirmación de pedido ───────────────────────────────
var products = new[]
{
    ("Camiseta Negra", 2, 29.99m),
    ("Zapatillas Running", 1, 89.50m),
    ("Gorra Deportiva", 3, 15.00m)
};

var orderEmail = Email.Compose(ctx =>
{
    ctx.Column(spacing: 16, () =>
    {
        ctx.Heading("¡Pedido confirmado!", level: 1)
            .TextColor(TailwindColors.Green700);

        ctx.Text("Gracias por tu compra. Aquí tienes el resumen:")
            .TextColor(TailwindColors.Gray600);

        ctx.Divider(TailwindColors.Green200);

        ctx.ForEach(products, product =>
        {
            ctx.Row(spacing: 8, () =>
            {
                ctx.Text($"{product.Item2}x {product.Item1}")
                    .Bold();
                ctx.Text($"${product.Item2 * product.Item3:F2}")
                    .Align(TextAlign.Right)
                    .TextColor(TailwindColors.Gray600);
            });
        });

        ctx.Divider(TailwindColors.Green200);

        var total = products.Sum(p => p.Item2 * p.Item3);
        ctx.Row(spacing: 8, () =>
        {
            ctx.Text("Total").Bold().FontSize(18);
            ctx.Text($"${total:F2}")
                .Bold()
                .FontSize(18)
                .Align(TextAlign.Right)
                .TextColor(TailwindColors.Green700);
        });

        ctx.Spacer(8);

        ctx.Button("Ver pedido", "https://example.com/order/12345")
            .Background(TailwindColors.Green600);
    });
});

orderEmail.WithTheme(t =>
{
    t.Title = "Pedido Confirmado";
    t.FooterText = "Example Store — Tu tienda de confianza";
});

File.WriteAllText("Output/OrderConfirmation.html", orderEmail.Render());
Console.WriteLine("✔ OrderConfirmation.html");

// ── 4. Notificación simple ──────────────────────────────────
var notification = Email.Compose(ctx =>
{
    ctx.Column(spacing: 12, () =>
    {
        ctx.Text("🔔 Nueva actividad en tu cuenta")
            .Bold()
            .FontSize(18);

        ctx.Text("Juan García ha comentado en tu publicación.")
            .TextColor(TailwindColors.Gray600);

        ctx.Container(() =>
        {
            ctx.Text("\"Excelente artículo, muy bien explicado. Gracias por compartir.\"")
                .Italic()
                .TextColor(TailwindColors.Gray500);
        }).Background(TailwindColors.Gray50).Padding(16).Rounded(8);

        ctx.Button("Ver comentario", "https://example.com/post/42#comment")
            .Background(TailwindColors.Indigo600);
    });
});

File.WriteAllText("Output/Notification.html", notification.Render());
Console.WriteLine("✔ Notification.html");

// ── 5. Bienvenida con imagen ────────────────────────────────
var welcomeEmail = Email.Compose(ctx =>
{
    ctx.Column(spacing: 20, () =>
    {
        ctx.Image("https://via.placeholder.com/600x200/2563eb/ffffff?text=Bienvenido",
                   "Banner de bienvenida", width: 600)
            .Rounded(8);

        ctx.Heading("¡Bienvenido a Example!", level: 1)
            .TextColor(TailwindColors.Blue700)
            .Center();

        ctx.Text("Estamos encantados de tenerte aquí. Aquí tienes algunos pasos para empezar:")
            .TextColor(TailwindColors.Gray600)
            .Center();

        ctx.Spacer(8);

        ctx.Row(spacing: 16, () =>
        {
            ctx.Column(spacing: 8, padding: 16, () =>
            {
                ctx.Text("📋").FontSize(28).Center();
                ctx.Text("Completa tu perfil").Bold().Center();
                ctx.Text("Añade tu foto y bio").FontSize(13).TextColor(TailwindColors.Gray500).Center();
            });

            ctx.Column(spacing: 8, padding: 16, () =>
            {
                ctx.Text("👥").FontSize(28).Center();
                ctx.Text("Conecta con otros").Bold().Center();
                ctx.Text("Busca amigos y colegas").FontSize(13).TextColor(TailwindColors.Gray500).Center();
            });

            ctx.Column(spacing: 8, padding: 16, () =>
            {
                ctx.Text("🚀").FontSize(28).Center();
                ctx.Text("Explora funciones").Bold().Center();
                ctx.Text("Descubre lo que puedes hacer").FontSize(13).TextColor(TailwindColors.Gray500).Center();
            });
        });

        ctx.Spacer(8);

        ctx.Button("Ir al Dashboard", "https://example.com/dashboard")
            .Background(TailwindColors.Blue600);
    });
});

welcomeEmail.WithTheme(t =>
{
    t.Title = "Bienvenido a Example";
    t.FooterText = "© 2026 Example. Todos los derechos reservados.";
});

File.WriteAllText("Output/Welcome.html", welcomeEmail.Render());
Console.WriteLine("✔ Welcome.html");

// ── 6. Tema oscuro ──────────────────────────────────────────
var darkEmail = Email.Compose(ctx =>
{
    ctx.Column(spacing: 16, () =>
    {
        ctx.Heading("Modo Oscuro 🌙", level: 2)
            .TextColor(TailwindColors.White);

        ctx.Text("Este email usa el tema oscuro de MailCompose.")
            .TextColor(TailwindColors.Gray300);

        ctx.Divider(TailwindColors.Gray600);

        ctx.Text("Perfecto para notificaciones nocturnas.")
            .TextColor(TailwindColors.Gray400);

        ctx.Button("Ver más", "https://example.com")
            .Background(TailwindColors.Indigo500);
    });
}).WithTheme(EmailTheme.Dark);

File.WriteAllText("Output/DarkTheme.html", darkEmail.Render());
Console.WriteLine("✔ DarkTheme.html");

// ── 7. Condicional y ForEach ────────────────────────────────
var isPremium = true;
var features = new[] { "Almacenamiento ilimitado", "Soporte prioritario", "Sin anuncios" };

var conditionalEmail = Email.Compose(ctx =>
{
    ctx.Column(spacing: 12, () =>
    {
        ctx.When(isPremium,
            () => ctx.Heading("¡Eres Premium! ⭐", level: 2)
                      .TextColor(TailwindColors.Amber600),
            () => ctx.Heading("Actualiza a Premium", level: 2)
                      .TextColor(TailwindColors.Gray700)
        );

        ctx.Text("Tus beneficios incluyen:")
            .TextColor(TailwindColors.Gray600);

        ctx.ForEach(features, feature =>
        {
            ctx.Text($"✓ {feature}")
                .TextColor(TailwindColors.Green600)
                .FontSize(14);
        });

        ctx.When(!isPremium, () =>
        {
            ctx.Spacer(8);
            ctx.Button("Actualizar ahora", "https://example.com/upgrade")
                .Background(TailwindColors.Amber500);
        });
    });
});

File.WriteAllText("Output/Conditional.html", conditionalEmail.Render());
Console.WriteLine("✔ Conditional.html");

// ╔═══════════════════════════════════════════════════════════╗
// ║  AVANZADOS (8-15): uso completo de la librería           ║
// ╚═══════════════════════════════════════════════════════════╝

// ── 8. E-Commerce completo — Envío + productos + tracking ──
var orderItems = new[]
{
    (Name: "MacBook Pro 14\"", Sku: "MBP-14-M3", Qty: 1, Price: 1999.00m, Img: "https://via.placeholder.com/80x80/e5e7eb/374151?text=MBP"),
    (Name: "Magic Mouse", Sku: "MM-2023", Qty: 1, Price: 99.00m, Img: "https://via.placeholder.com/80x80/e5e7eb/374151?text=MM"),
    (Name: "USB-C Hub 7-in-1", Sku: "HUB-7C", Qty: 2, Price: 45.00m, Img: "https://via.placeholder.com/80x80/e5e7eb/374151?text=HUB"),
};

var ecommerceEmail = Email.Compose(ctx =>
{
    ctx.Column(spacing: 0, () =>
    {
        // Header con gradiente simulado
        ctx.Container(() =>
        {
            ctx.Heading("Pedido enviado 📦", level: 1)
                .TextColor(TailwindColors.White).Center();
            ctx.Text("Tu pedido #ORD-2026-4872 está en camino")
                .TextColor(TailwindColors.Emerald100).Center().TextSm();
        }).Bg(TailwindColors.Emerald700).P(32).RoundedT(8);

        ctx.Spacer(24);

        // Tracking
        ctx.Container(() =>
        {
            ctx.Column(spacing: 12, () =>
            {
                ctx.Text("Seguimiento del envío").Bold().TextLg().TextColor(TailwindColors.Gray800);
                ctx.Row(spacing: 0, () =>
                {
                    ctx.Container(() =>
                    {
                        ctx.Text("✅").FontSize(20).Center();
                        ctx.Text("Confirmado").TextXs().Center().TextColor(TailwindColors.Green600).Bold();
                    }).P(8);
                    ctx.Container(() =>
                    {
                        ctx.Text("✅").FontSize(20).Center();
                        ctx.Text("Preparado").TextXs().Center().TextColor(TailwindColors.Green600).Bold();
                    }).P(8);
                    ctx.Container(() =>
                    {
                        ctx.Text("📦").FontSize(20).Center();
                        ctx.Text("Enviado").TextXs().Center().TextColor(TailwindColors.Blue600).Bold();
                    }).P(8);
                    ctx.Container(() =>
                    {
                        ctx.Text("🏠").FontSize(20).Center();
                        ctx.Text("Entregado").TextXs().Center().TextColor(TailwindColors.Gray400);
                    }).P(8);
                });
            });
        }).Bg(TailwindColors.Gray50).P(20).RoundedLg().Border(1, TailwindColors.Gray200);

        ctx.Spacer(20);

        // Productos con imagen
        ctx.Text("Artículos en tu pedido").Bold().TextColor(TailwindColors.Gray800);
        ctx.Spacer(12);

        ctx.ForEach(orderItems, item =>
        {
            ctx.Container(() =>
            {
                ctx.Row(spacing: 16, () =>
                {
                    ctx.Image(item.Img, item.Name, width: 80, height: 80).RoundedMd();
                    ctx.Column(spacing: 4, () =>
                    {
                        ctx.Text(item.Name).Bold().TextColor(TailwindColors.Gray900);
                        ctx.Text($"SKU: {item.Sku}").TextXs().TextColor(TailwindColors.Gray400);
                        ctx.Text($"Cantidad: {item.Qty}").TextSm().TextColor(TailwindColors.Gray500);
                    });
                    ctx.Text($"${item.Price * item.Qty:F2}")
                        .Bold().TextColor(TailwindColors.Gray900).Align(TextAlign.Right);
                });
            }).Py(12).BorderB(1, TailwindColors.Gray100);
        });

        ctx.Spacer(16);

        // Resumen de costos
        ctx.Container(() =>
        {
            ctx.Column(spacing: 8, () =>
            {
                var subtotal = orderItems.Sum(i => i.Price * i.Qty);
                ctx.Row(spacing: 8, () =>
                {
                    ctx.Text("Subtotal").TextColor(TailwindColors.Gray600);
                    ctx.Text($"${subtotal:F2}").Align(TextAlign.Right).TextColor(TailwindColors.Gray600);
                });
                ctx.Row(spacing: 8, () =>
                {
                    ctx.Text("Envío").TextColor(TailwindColors.Gray600);
                    ctx.Text("Gratis").Align(TextAlign.Right).TextColor(TailwindColors.Green600).Bold();
                });
                ctx.Row(spacing: 8, () =>
                {
                    ctx.Text("Impuestos").TextColor(TailwindColors.Gray600);
                    ctx.Text($"${subtotal * 0.08m:F2}").Align(TextAlign.Right).TextColor(TailwindColors.Gray600);
                });
                ctx.Divider(TailwindColors.Gray200, thickness: 2);
                ctx.Row(spacing: 8, () =>
                {
                    ctx.Text("Total").Bold().TextLg().TextColor(TailwindColors.Gray900);
                    ctx.Text($"${subtotal * 1.08m:F2}").Bold().TextLg()
                        .Align(TextAlign.Right).TextColor(TailwindColors.Emerald700);
                });
            });
        }).Bg(TailwindColors.Gray50).P(20).RoundedLg();

        ctx.Spacer(20);

        // Dirección de envío
        ctx.Container(() =>
        {
            ctx.Column(spacing: 4, () =>
            {
                ctx.Text("Dirección de envío").Bold().TextSm().Uppercase()
                    .TrackingWide().TextColor(TailwindColors.Gray500);
                ctx.Spacer(4);
                ctx.Text("Juan Pérez").TextColor(TailwindColors.Gray800);
                ctx.Text("Calle Principal 123, Apt 4B").TextColor(TailwindColors.Gray600).TextSm();
                ctx.Text("Madrid, 28001, España").TextColor(TailwindColors.Gray600).TextSm();
            });
        }).P(16).BorderL(4, TailwindColors.Emerald500);

        ctx.Spacer(24);

        ctx.Button("Rastrear envío", "https://example.com/track/TRK-2026-ABC")
            .Bg(TailwindColors.Emerald600).RoundedLg();

        ctx.Spacer(12);
        ctx.Text("¿Necesitas ayuda? Contáctanos en soporte@example.com")
            .TextXs().TextColor(TailwindColors.Gray400).Center();
    });
});

ecommerceEmail.WithTheme(t =>
{
    t.Title = "Tu pedido ha sido enviado";
    t.ContentPadding = 24;
    t.FooterText = "Example Store · Madrid, España · Cancelar suscripción";
});

File.WriteAllText("Output/EcommerceShipment.html", ecommerceEmail.Render());
Console.WriteLine("✔ EcommerceShipment.html");

// ── 9. Newsletter / Blog Digest ─────────────────────────────
var articles = new[]
{
    (Title: "Cómo construir APIs REST modernas en .NET 10", Category: "Tutorial", ReadTime: "8 min",
     Excerpt: "Aprende a crear APIs robustas con minimal APIs, source generators y AOT compilation.",
     Img: "https://via.placeholder.com/260x150/3b82f6/ffffff?text=API+REST", Color: TailwindColors.Blue600),
    (Title: "El futuro de Blazor: Server + WASM unificados", Category: "Análisis", ReadTime: "12 min",
     Excerpt: "Blazor United cambia las reglas del juego. Analizamos qué significa para tus proyectos.",
     Img: "https://via.placeholder.com/260x150/8b5cf6/ffffff?text=Blazor", Color: TailwindColors.Violet600),
    (Title: "5 patrones de diseño que todo dev C# debería conocer", Category: "Guía", ReadTime: "6 min",
     Excerpt: "From Mediator a Result Pattern, estos patrones elevarán la calidad de tu código.",
     Img: "https://via.placeholder.com/260x150/059669/ffffff?text=Patterns", Color: TailwindColors.Emerald600),
};

var newsletterEmail = Email.Compose(ctx =>
{
    ctx.Column(spacing: 0, () =>
    {
        // Header branding
        ctx.Container(() =>
        {
            ctx.Row(spacing: 12, () =>
            {
                ctx.Text("⚡").FontSize(32);
                ctx.Column(spacing: 2, () =>
                {
                    ctx.Text("DevWeekly").Bold().Text2Xl().TextColor(TailwindColors.White).LeadingTight();
                    ctx.Text("Tu dosis semanal de .NET").TextSm().TextColor(TailwindColors.Indigo200);
                });
            });
        }).Bg(TailwindColors.Indigo700).P(24).RoundedT(8);

        ctx.Spacer(24);

        ctx.Text("Edición #47 — Marzo 2026").TextSm().TextColor(TailwindColors.Gray400).Uppercase().TrackingWidest();
        ctx.Spacer(16);

        // Artículo destacado
        ctx.Container(() =>
        {
            ctx.Column(spacing: 16, () =>
            {
                ctx.Image(articles[0].Img, articles[0].Title, width: 536).RoundedLg();
                ctx.Container(() =>
                {
                    ctx.Text(articles[0].Category).Uppercase().TextXs().Bold()
                        .TrackingWidest().TextColor(TailwindColors.White);
                }).Bg(articles[0].Color).Px(10).Py(4).RoundedFull();
                ctx.Text(articles[0].Title).Bold().TextXl().TextColor(TailwindColors.Gray900).LeadingTight();
                ctx.Text(articles[0].Excerpt).TextColor(TailwindColors.Gray600).LeadingRelaxed();
                ctx.Row(spacing: 12, () =>
                {
                    ctx.Link("https://example.com/blog/1", "Leer artículo →")
                        .TextColor(articles[0].Color).Bold();
                    ctx.Text($"· {articles[0].ReadTime}").TextSm().TextColor(TailwindColors.Gray400);
                });
            });
        }).P(20).Bg(TailwindColors.Gray50).RoundedLg().ShadowSm();

        ctx.Spacer(24);

        // Grid de artículos (2 columnas simuladas con Row)
        ctx.Row(spacing: 16, () =>
        {
            ctx.ForEach(articles.Skip(1), article =>
            {
                ctx.Container(() =>
                {
                    ctx.Column(spacing: 12, () =>
                    {
                        ctx.Image(article.Img, article.Title, width: 260).RoundedMd();
                        ctx.Container(() =>
                        {
                            ctx.Text(article.Category).Uppercase().TextXs().Bold()
                                .TrackingWidest().TextColor(TailwindColors.White);
                        }).Bg(article.Color).Px(8).Py(3).RoundedFull();
                        ctx.Text(article.Title).Bold().TextBase().TextColor(TailwindColors.Gray900).LeadingSnug();
                        ctx.Text(article.Excerpt).TextSm().TextColor(TailwindColors.Gray500).LeadingRelaxed();
                        ctx.Link("https://example.com/blog", "Leer más →")
                            .TextColor(article.Color).Bold().TextSm();
                    });
                }).P(16).Bg(TailwindColors.White).RoundedLg().Border(1, TailwindColors.Gray200);
            });
        });

        ctx.Spacer(24);

        // CTA de suscripción
        ctx.Container(() =>
        {
            ctx.Column(spacing: 12, () =>
            {
                ctx.Text("¿Te gusta DevWeekly?").Bold().TextLg().Center().TextColor(TailwindColors.Indigo900);
                ctx.Text("Comparte con un colega y ambos ganan acceso a contenido exclusivo.")
                    .TextSm().Center().TextColor(TailwindColors.Indigo700);
                ctx.Button("Compartir DevWeekly", "https://example.com/share")
                    .Bg(TailwindColors.Indigo600).RoundedFull();
            });
        }).Bg(TailwindColors.Indigo50).P(24).RoundedLg().Border(1, TailwindColors.Indigo200);
    });
});

newsletterEmail.WithTheme(t =>
{
    t.Title = "DevWeekly #47 — Tu dosis semanal de .NET";
    t.ContentPadding = 24;
    t.FooterText = "DevWeekly · Cancelar suscripción · Ver en navegador";
});

File.WriteAllText("Output/Newsletter.html", newsletterEmail.Render());
Console.WriteLine("✔ Newsletter.html");

// ── 10. Dashboard / Reporte con métricas ────────────────────
var dashboardEmail = Email.Compose(ctx =>
{
    ctx.Column(spacing: 0, () =>
    {
        // Header
        ctx.Container(() =>
        {
            ctx.Text("📊 Reporte Semanal").Bold().Text2Xl().TextColor(TailwindColors.White).Center();
            ctx.Text("1 — 7 de Marzo, 2026").TextSm().TextColor(TailwindColors.Sky200).Center();
        }).Bg(TailwindColors.Sky700).P(28).RoundedT(8);

        ctx.Spacer(24);

        // KPIs principales (4 columnas)
        ctx.Row(spacing: 12, () =>
        {
            var kpis = new[]
            {
                (Label: "Ingresos", Value: "$12,450", Change: "+14.2%", Up: true, Color: TailwindColors.Green600, Bg: TailwindColors.Green50),
                (Label: "Usuarios", Value: "3,287", Change: "+8.5%", Up: true, Color: TailwindColors.Blue600, Bg: TailwindColors.Blue50),
                (Label: "Conversión", Value: "4.2%", Change: "-0.8%", Up: false, Color: TailwindColors.Red600, Bg: TailwindColors.Red50),
                (Label: "Retención", Value: "92%", Change: "+2.1%", Up: true, Color: TailwindColors.Purple600, Bg: TailwindColors.Purple50),
            };

            ctx.ForEach(kpis, kpi =>
            {
                ctx.Container(() =>
                {
                    ctx.Column(spacing: 4, () =>
                    {
                        ctx.Text(kpi.Label).TextXs().Uppercase().TrackingWide()
                            .TextColor(TailwindColors.Gray500).Center();
                        ctx.Text(kpi.Value).Bold().TextXl().TextColor(TailwindColors.Gray900).Center();
                        ctx.Text($"{(kpi.Up ? "↑" : "↓")} {kpi.Change}")
                            .TextXs().Bold().TextColor(kpi.Color).Center();
                    });
                }).Bg(kpi.Bg).P(16).RoundedLg();
            });
        });

        ctx.Spacer(24);

        // Top 5 productos
        ctx.Text("Top Productos").Bold().TextLg().TextColor(TailwindColors.Gray900);
        ctx.Spacer(8);

        ctx.Container(() =>
        {
            // Header de tabla
            ctx.Container(() =>
            {
                ctx.Row(spacing: 0, () =>
                {
                    ctx.Text("Producto").Bold().TextXs().Uppercase().TrackingWide()
                        .TextColor(TailwindColors.Gray500).W("40%");
                    ctx.Text("Ventas").Bold().TextXs().Uppercase().TrackingWide()
                        .TextColor(TailwindColors.Gray500).Center().W("20%");
                    ctx.Text("Ingresos").Bold().TextXs().Uppercase().TrackingWide()
                        .TextColor(TailwindColors.Gray500).Align(TextAlign.Right).W("20%");
                    ctx.Text("Trend").Bold().TextXs().Uppercase().TrackingWide()
                        .TextColor(TailwindColors.Gray500).Align(TextAlign.Right).W("20%");
                });
            }).Bg(TailwindColors.Gray50).Px(16).Py(10);

            var topProducts = new[]
            {
                (Name: "Plan Premium", Sales: 156, Revenue: "$7,800", Trend: "+23%", TrendUp: true),
                (Name: "Plan Starter", Sales: 89, Revenue: "$2,670", Trend: "+12%", TrendUp: true),
                (Name: "API Credits", Sales: 234, Revenue: "$1,170", Trend: "+45%", TrendUp: true),
                (Name: "Storage Extra", Sales: 45, Revenue: "$675", Trend: "-5%", TrendUp: false),
                (Name: "Support+", Sales: 12, Revenue: "$420", Trend: "+8%", TrendUp: true),
            };

            ctx.ForEach(topProducts, p =>
            {
                ctx.Container(() =>
                {
                    ctx.Row(spacing: 0, () =>
                    {
                        ctx.Text(p.Name).TextSm().TextColor(TailwindColors.Gray800).W("40%");
                        ctx.Text(p.Sales.ToString()).TextSm().TextColor(TailwindColors.Gray600).Center().W("20%");
                        ctx.Text(p.Revenue).TextSm().Bold().TextColor(TailwindColors.Gray800)
                            .Align(TextAlign.Right).W("20%");
                        ctx.Text($"{(p.TrendUp ? "↑" : "↓")} {p.Trend}")
                            .TextXs().Bold()
                            .TextColor(p.TrendUp ? TailwindColors.Green600 : TailwindColors.Red500)
                            .Align(TextAlign.Right).W("20%");
                    });
                }).Px(16).Py(10).BorderB(1, TailwindColors.Gray100);
            });
        }).RoundedLg().Border(1, TailwindColors.Gray200).OverflowHidden();

        ctx.Spacer(24);

        // Resumen y acciones
        ctx.Container(() =>
        {
            ctx.Column(spacing: 12, () =>
            {
                ctx.Text("💡 Insights de la semana").Bold().TextColor(TailwindColors.Amber800);
                ctx.Text("• Los ingresos subieron un 14.2% respecto a la semana pasada")
                    .TextSm().TextColor(TailwindColors.Amber700);
                ctx.Text("• API Credits es el producto con mayor crecimiento (+45%)")
                    .TextSm().TextColor(TailwindColors.Amber700);
                ctx.Text("• La conversión bajó ligeramente — revisar landing page")
                    .TextSm().TextColor(TailwindColors.Amber700);
            });
        }).Bg(TailwindColors.Amber50).P(20).RoundedLg().BorderL(4, TailwindColors.Amber400);

        ctx.Spacer(20);

        ctx.Button("Ver Dashboard Completo", "https://example.com/dashboard")
            .Bg(TailwindColors.Sky600).RoundedLg();
    });
});

dashboardEmail.WithTheme(t =>
{
    t.Title = "Reporte Semanal — Marzo 2026";
    t.ContentPadding = 24;
    t.FooterText = "Analytics · Generado automáticamente cada lunes a las 9:00 AM";
});

File.WriteAllText("Output/Dashboard.html", dashboardEmail.Render());
Console.WriteLine("✔ Dashboard.html");

// ── 11. Factura profesional ─────────────────────────────────
var invoiceEmail = Email.Compose(ctx =>
{
    ctx.Column(spacing: 0, () =>
    {
        // Header con logo y datos de empresa
        ctx.Row(spacing: 0, () =>
        {
            ctx.Column(spacing: 4, () =>
            {
                ctx.Text("ACME Corp").Bold().Text2Xl().TextColor(TailwindColors.Gray900);
                ctx.Text("Soluciones Tecnológicas").TextSm().TextColor(TailwindColors.Gray500);
            });
            ctx.Column(spacing: 4, () =>
            {
                ctx.Text("FACTURA").Bold().Text3Xl().TextColor(TailwindColors.Blue600)
                    .Align(TextAlign.Right);
                ctx.Text("#INV-2026-0342").TextSm().TextColor(TailwindColors.Gray500)
                    .Align(TextAlign.Right);
            });
        });

        ctx.Spacer(24);

        // Datos del cliente y fecha
        ctx.Row(spacing: 24, () =>
        {
            ctx.Container(() =>
            {
                ctx.Column(spacing: 4, () =>
                {
                    ctx.Text("FACTURAR A").TextXs().Uppercase().TrackingWidest()
                        .Bold().TextColor(TailwindColors.Gray400);
                    ctx.Spacer(4);
                    ctx.Text("Empresa XYZ S.L.").Bold().TextColor(TailwindColors.Gray800);
                    ctx.Text("CIF: B-12345678").TextSm().TextColor(TailwindColors.Gray600);
                    ctx.Text("Av. de la Tecnología 45").TextSm().TextColor(TailwindColors.Gray600);
                    ctx.Text("28034 Madrid, España").TextSm().TextColor(TailwindColors.Gray600);
                });
            });
            ctx.Container(() =>
            {
                ctx.Column(spacing: 6, () =>
                {
                    ctx.Row(spacing: 8, () =>
                    {
                        ctx.Text("Fecha:").TextSm().Bold().TextColor(TailwindColors.Gray500);
                        ctx.Text("04/03/2026").TextSm().TextColor(TailwindColors.Gray700).Align(TextAlign.Right);
                    });
                    ctx.Row(spacing: 8, () =>
                    {
                        ctx.Text("Vencimiento:").TextSm().Bold().TextColor(TailwindColors.Gray500);
                        ctx.Text("04/04/2026").TextSm().TextColor(TailwindColors.Gray700).Align(TextAlign.Right);
                    });
                    ctx.Row(spacing: 8, () =>
                    {
                        ctx.Text("Estado:").TextSm().Bold().TextColor(TailwindColors.Gray500);
                        ctx.Container(() =>
                        {
                            ctx.Text("Pendiente").TextXs().Bold().TextColor(TailwindColors.Amber700);
                        }).Bg(TailwindColors.Amber100).Px(8).Py(2).RoundedFull();
                    });
                });
            });
        });

        ctx.Spacer(24);

        // Tabla de servicios
        ctx.Container(() =>
        {
            // Cabecera
            ctx.Container(() =>
            {
                ctx.Row(spacing: 0, () =>
                {
                    ctx.Text("Concepto").Bold().TextXs().Uppercase().TrackingWide()
                        .TextColor(TailwindColors.White).W("45%");
                    ctx.Text("Horas").Bold().TextXs().Uppercase().TrackingWide()
                        .TextColor(TailwindColors.White).Center().W("15%");
                    ctx.Text("Tarifa").Bold().TextXs().Uppercase().TrackingWide()
                        .TextColor(TailwindColors.White).Align(TextAlign.Right).W("20%");
                    ctx.Text("Total").Bold().TextXs().Uppercase().TrackingWide()
                        .TextColor(TailwindColors.White).Align(TextAlign.Right).W("20%");
                });
            }).Bg(TailwindColors.Gray800).Px(16).Py(10).RoundedT(8);

            var services = new[]
            {
                (Desc: "Desarrollo web frontend", Hours: 40, Rate: 85.00m),
                (Desc: "Desarrollo API backend", Hours: 32, Rate: 95.00m),
                (Desc: "Diseño UI/UX", Hours: 16, Rate: 75.00m),
                (Desc: "QA y testing", Hours: 12, Rate: 65.00m),
            };

            ctx.ForEach(services, svc =>
            {
                ctx.Container(() =>
                {
                    ctx.Row(spacing: 0, () =>
                    {
                        ctx.Text(svc.Desc).TextSm().TextColor(TailwindColors.Gray800).W("45%");
                        ctx.Text(svc.Hours.ToString()).TextSm().TextColor(TailwindColors.Gray600).Center().W("15%");
                        ctx.Text($"${svc.Rate:F2}/h").TextSm().TextColor(TailwindColors.Gray600)
                            .Align(TextAlign.Right).W("20%");
                        ctx.Text($"${svc.Hours * svc.Rate:F2}").TextSm().Bold()
                            .TextColor(TailwindColors.Gray800).Align(TextAlign.Right).W("20%");
                    });
                }).Px(16).Py(10).BorderB(1, TailwindColors.Gray100);
            });

            // Totales
            var subtotal = services.Sum(s => s.Hours * s.Rate);
            var iva = subtotal * 0.21m;
            ctx.Container(() =>
            {
                ctx.Column(spacing: 6, () =>
                {
                    ctx.Row(spacing: 0, () =>
                    {
                        ctx.Text("Subtotal").TextSm().TextColor(TailwindColors.Gray600).W("70%")
                            .Align(TextAlign.Right);
                        ctx.Text($"${subtotal:F2}").TextSm().TextColor(TailwindColors.Gray800)
                            .Align(TextAlign.Right).W("30%");
                    });
                    ctx.Row(spacing: 0, () =>
                    {
                        ctx.Text("IVA (21%)").TextSm().TextColor(TailwindColors.Gray600).W("70%")
                            .Align(TextAlign.Right);
                        ctx.Text($"${iva:F2}").TextSm().TextColor(TailwindColors.Gray800)
                            .Align(TextAlign.Right).W("30%");
                    });
                    ctx.Divider(TailwindColors.Gray200, thickness: 2);
                    ctx.Row(spacing: 0, () =>
                    {
                        ctx.Text("TOTAL").Bold().TextLg().TextColor(TailwindColors.Gray900).W("70%")
                            .Align(TextAlign.Right);
                        ctx.Text($"${subtotal + iva:F2}").Bold().TextLg()
                            .TextColor(TailwindColors.Blue600).Align(TextAlign.Right).W("30%");
                    });
                });
            }).Px(16).Py(16).Bg(TailwindColors.Gray50).RoundedB(8);
        }).RoundedLg().Border(1, TailwindColors.Gray200).OverflowHidden();

        ctx.Spacer(24);

        // Nota de pago
        ctx.Container(() =>
        {
            ctx.Column(spacing: 8, () =>
            {
                ctx.Text("Datos de pago").Bold().TextSm().TextColor(TailwindColors.Gray700);
                ctx.Text("IBAN: ES12 3456 7890 1234 5678 9012").FontMono().TextSm().TextColor(TailwindColors.Gray600);
                ctx.Text("BIC/SWIFT: ABCDESMMXXX").FontMono().TextSm().TextColor(TailwindColors.Gray600);
                ctx.Text("Referencia: INV-2026-0342").FontMono().TextSm().TextColor(TailwindColors.Gray600);
            });
        }).P(16).Bg(TailwindColors.Blue50).RoundedLg().BorderL(4, TailwindColors.Blue400);

        ctx.Spacer(20);

        ctx.Button("Pagar ahora", "https://example.com/pay/INV-2026-0342")
            .Bg(TailwindColors.Blue600).RoundedLg();

        ctx.Spacer(8);
        ctx.Text("El pago debe realizarse dentro de los 30 días siguientes a la fecha de emisión.")
            .TextXs().TextColor(TailwindColors.Gray400).Center().Italic();
    });
});

invoiceEmail.WithTheme(t =>
{
    t.Title = "Factura #INV-2026-0342";
    t.ContentPadding = 32;
    t.FooterText = "ACME Corp · CIF: A-98765432 · Calle de la Innovación 7, Madrid";
});

File.WriteAllText("Output/Invoice.html", invoiceEmail.Render());
Console.WriteLine("✔ Invoice.html");

// ── 12. SaaS — Resumen de actividad del usuario ────────────
var activityEmail = Email.Compose(ctx =>
{
    ctx.Column(spacing: 0, () =>
    {
        // Avatar + saludo
        ctx.Row(spacing: 16, () =>
        {
            ctx.Image("https://via.placeholder.com/56x56/6366f1/ffffff?text=JP", "Avatar", width: 56, height: 56)
                .RoundedFull();
            ctx.Column(spacing: 2, () =>
            {
                ctx.Text("¡Hola, Juan! 👋").Bold().TextXl().TextColor(TailwindColors.Gray900);
                ctx.Text("Aquí tienes tu resumen de actividad de esta semana")
                    .TextSm().TextColor(TailwindColors.Gray500);
            });
        });

        ctx.Spacer(24);

        // Cards de actividad en fila
        ctx.Row(spacing: 12, () =>
        {
            ctx.Container(() =>
            {
                ctx.Text("📝").FontSize(24).Center();
                ctx.Text("12").Bold().Text2Xl().Center().TextColor(TailwindColors.Blue700);
                ctx.Text("Tareas completadas").TextXs().Center().TextColor(TailwindColors.Blue600);
            }).Bg(TailwindColors.Blue50).P(16).RoundedXl().Border(1, TailwindColors.Blue200);

            ctx.Container(() =>
            {
                ctx.Text("💬").FontSize(24).Center();
                ctx.Text("28").Bold().Text2Xl().Center().TextColor(TailwindColors.Purple700);
                ctx.Text("Mensajes enviados").TextXs().Center().TextColor(TailwindColors.Purple600);
            }).Bg(TailwindColors.Purple50).P(16).RoundedXl().Border(1, TailwindColors.Purple200);

            ctx.Container(() =>
            {
                ctx.Text("⏱️").FontSize(24).Center();
                ctx.Text("34h").Bold().Text2Xl().Center().TextColor(TailwindColors.Teal700);
                ctx.Text("Tiempo registrado").TextXs().Center().TextColor(TailwindColors.Teal600);
            }).Bg(TailwindColors.Teal50).P(16).RoundedXl().Border(1, TailwindColors.Teal200);
        });

        ctx.Spacer(24);

        // Timeline de actividad reciente
        ctx.Text("Actividad reciente").Bold().TextLg().TextColor(TailwindColors.Gray900);
        ctx.Spacer(12);

        var activities = new[]
        {
            (Time: "Hoy, 10:30 AM", Action: "Completaste la tarea \"Rediseñar página de pricing\"",
             Icon: "✅", Color: TailwindColors.Green100, TextC: TailwindColors.Green700),
            (Time: "Ayer, 3:15 PM", Action: "Comentaste en el proyecto \"App Móvil v2\"",
             Icon: "💬", Color: TailwindColors.Blue100, TextC: TailwindColors.Blue700),
            (Time: "Ayer, 11:00 AM", Action: "Subiste 3 archivos al repositorio",
             Icon: "📎", Color: TailwindColors.Orange100, TextC: TailwindColors.Orange700),
            (Time: "Lun, 9:45 AM", Action: "Creaste el sprint \"Sprint 14 — Q1 Final\"",
             Icon: "🚀", Color: TailwindColors.Purple100, TextC: TailwindColors.Purple700),
        };

        ctx.ForEach(activities, act =>
        {
            ctx.Container(() =>
            {
                ctx.Row(spacing: 12, () =>
                {
                    ctx.Container(() =>
                    {
                        ctx.Text(act.Icon).FontSize(16).Center();
                    }).Bg(act.Color).Size(36).RoundedFull().P(6);

                    ctx.Column(spacing: 2, () =>
                    {
                        ctx.Text(act.Action).TextSm().TextColor(TailwindColors.Gray800);
                        ctx.Text(act.Time).TextXs().TextColor(TailwindColors.Gray400);
                    });
                });
            }).Py(8).BorderB(1, TailwindColors.Gray100);
        });

        ctx.Spacer(24);

        // Racha y motivación
        ctx.Container(() =>
        {
            ctx.Row(spacing: 16, () =>
            {
                ctx.Text("🔥").FontSize(36);
                ctx.Column(spacing: 4, () =>
                {
                    ctx.Text("¡Racha de 14 días!").Bold().TextLg().TextColor(TailwindColors.Orange700);
                    ctx.Text("Llevas 14 días consecutivos completando tareas. ¡Sigue así!")
                        .TextSm().TextColor(TailwindColors.Orange600);
                });
            });
        }).Bg(TailwindColors.Orange50).P(20).RoundedXl().Border(1, TailwindColors.Orange200);

        ctx.Spacer(20);

        ctx.Button("Abrir Workspace", "https://example.com/workspace")
            .Bg(TailwindColors.Indigo600).RoundedLg();
    });
});

activityEmail.WithTheme(t =>
{
    t.Title = "Tu actividad semanal — ProjectHub";
    t.ContentPadding = 28;
    t.FooterText = "ProjectHub · Ajustar notificaciones · Ayuda";
});

File.WriteAllText("Output/ActivitySummary.html", activityEmail.Render());
Console.WriteLine("✔ ActivitySummary.html");

// ── 13. Invitación a evento premium ─────────────────────────
var eventEmail = Email.Compose(ctx =>
{
    ctx.Column(spacing: 0, () =>
    {
        // Hero visual
        ctx.Container(() =>
        {
            ctx.Column(spacing: 12, () =>
            {
                ctx.Text("EXCLUSIVO").Uppercase().TextXs().Bold().TrackingWidest()
                    .TextColor(TailwindColors.Amber300).Center();
                ctx.Heading("DevConf 2026", level: 1)
                    .TextColor(TailwindColors.White).Center().Text4Xl().LeadingTight();
                ctx.Text("La conferencia de desarrollo más importante del año")
                    .TextLg().TextColor(TailwindColors.Violet200).Center();
                ctx.Spacer(8);
                ctx.Text("15 — 17 de Abril · Madrid, España")
                    .Bold().TextColor(TailwindColors.White).Center();
            });
        }).Bg(TailwindColors.Violet900).P(40).RoundedT(8);

        ctx.Spacer(24);

        // Puntos clave
        ctx.Text("¿Qué te espera?").Bold().TextXl().TextColor(TailwindColors.Gray900).Center();
        ctx.Spacer(16);

        ctx.Row(spacing: 16, () =>
        {
            var highlights = new[]
            {
                (Icon: "🎤", Title: "50+ Speakers", Desc: "Expertos de Microsoft, Google y más"),
                (Icon: "🛠️", Title: "Workshops", Desc: "Talleres prácticos de 4 horas"),
                (Icon: "🤝", Title: "Networking", Desc: "Conecta con +2000 developers"),
            };

            ctx.ForEach(highlights, h =>
            {
                ctx.Container(() =>
                {
                    ctx.Column(spacing: 8, () =>
                    {
                        ctx.Text(h.Icon).FontSize(32).Center();
                        ctx.Text(h.Title).Bold().Center().TextColor(TailwindColors.Gray900);
                        ctx.Text(h.Desc).TextSm().Center().TextColor(TailwindColors.Gray500);
                    });
                }).P(20).Bg(TailwindColors.Violet50).RoundedXl();
            });
        });

        ctx.Spacer(24);

        // Speakers destacados
        ctx.Text("Speakers destacados").Bold().TextXl().TextColor(TailwindColors.Gray900).Center();
        ctx.Spacer(16);

        ctx.Row(spacing: 16, () =>
        {
            var speakers = new[]
            {
                (Name: "Ana García", Role: "Principal Engineer @ Microsoft", Img: "https://via.placeholder.com/80x80/8b5cf6/ffffff?text=AG"),
                (Name: "Carlos Ruiz", Role: "CTO @ TechStartup", Img: "https://via.placeholder.com/80x80/6366f1/ffffff?text=CR"),
                (Name: "María López", Role: "Staff Engineer @ Google", Img: "https://via.placeholder.com/80x80/a855f7/ffffff?text=ML"),
            };

            ctx.ForEach(speakers, speaker =>
            {
                ctx.Column(spacing: 8, () =>
                {
                    ctx.Image(speaker.Img, speaker.Name, width: 80, height: 80).RoundedFull();
                    ctx.Text(speaker.Name).Bold().TextSm().Center().TextColor(TailwindColors.Gray900);
                    ctx.Text(speaker.Role).TextXs().Center().TextColor(TailwindColors.Gray500);
                });
            });
        });

        ctx.Spacer(24);

        // Pricing
        ctx.Container(() =>
        {
            ctx.Column(spacing: 16, () =>
            {
                ctx.Text("🎟️ Tu entrada especial").Bold().TextLg().Center()
                    .TextColor(TailwindColors.Violet800);
                ctx.Row(spacing: 16, () =>
                {
                    ctx.Container(() =>
                    {
                        ctx.Column(spacing: 8, () =>
                        {
                            ctx.Text("Early Bird").Bold().Center().TextColor(TailwindColors.Gray700);
                            ctx.Text("$299").Bold().Text3Xl().Center().TextColor(TailwindColors.Violet600);
                            ctx.Text("$499").LineThrough().TextSm().Center().TextColor(TailwindColors.Gray400);
                            ctx.Text("Ahorra $200").TextXs().Bold().Center().TextColor(TailwindColors.Green600);
                        });
                    }).P(20).Border(2, TailwindColors.Violet300).RoundedXl().Bg(TailwindColors.White);

                    ctx.Container(() =>
                    {
                        ctx.Column(spacing: 8, () =>
                        {
                            ctx.Text("VIP").Bold().Center().TextColor(TailwindColors.White);
                            ctx.Text("$599").Bold().Text3Xl().Center().TextColor(TailwindColors.White);
                            ctx.Text("$899").LineThrough().TextSm().Center().TextColor(TailwindColors.Violet300);
                            ctx.Text("+ Cena de gala").TextXs().Bold().Center().TextColor(TailwindColors.Amber300);
                        });
                    }).P(20).Bg(TailwindColors.Violet700).RoundedXl();
                });
            });
        }).Bg(TailwindColors.Violet50).P(24).RoundedXl().Border(1, TailwindColors.Violet200);

        ctx.Spacer(24);

        ctx.Button("Reservar mi entrada", "https://example.com/devconf/register")
            .Bg(TailwindColors.Violet600).RoundedFull().FontSize(16).P(16);

        ctx.Spacer(8);
        ctx.Text("Plazas limitadas — Precio early bird hasta el 20 de marzo")
            .TextXs().TextColor(TailwindColors.Gray400).Center().Italic();
    });
});

eventEmail.WithTheme(t =>
{
    t.Title = "DevConf 2026 — Estás invitado";
    t.ContentPadding = 24;
    t.FooterText = "DevConf · Cancelar suscripción · Política de privacidad";
});

File.WriteAllText("Output/EventPremium.html", eventEmail.Render());
Console.WriteLine("✔ EventPremium.html");

// ── 14. Alerta de seguridad ─────────────────────────────────
var securityEmail = Email.Compose(ctx =>
{
    ctx.Column(spacing: 0, () =>
    {
        // Banner de alerta
        ctx.Container(() =>
        {
            ctx.Row(spacing: 12, () =>
            {
                ctx.Text("⚠️").FontSize(28);
                ctx.Column(spacing: 4, () =>
                {
                    ctx.Text("Alerta de Seguridad").Bold().TextXl().TextColor(TailwindColors.White);
                    ctx.Text("Nuevo inicio de sesión detectado").TextSm().TextColor(TailwindColors.Red200);
                });
            });
        }).Bg(TailwindColors.Red600).P(24).RoundedT(8);

        ctx.Spacer(24);

        ctx.Text("Hemos detectado un inicio de sesión en tu cuenta desde un dispositivo o ubicación nuevos.")
            .TextColor(TailwindColors.Gray700).LeadingRelaxed();

        ctx.Spacer(16);

        // Detalles del inicio de sesión
        ctx.Container(() =>
        {
            ctx.Column(spacing: 10, () =>
            {
                ctx.Text("Detalles del acceso").Bold().TextSm().Uppercase().TrackingWide()
                    .TextColor(TailwindColors.Gray500);
                ctx.Spacer(4);
                ctx.Row(spacing: 0, () =>
                {
                    ctx.Text("📅 Fecha:").Bold().TextSm().TextColor(TailwindColors.Gray600).W("35%");
                    ctx.Text("4 de marzo, 2026 a las 14:23 UTC").TextSm().TextColor(TailwindColors.Gray800);
                });
                ctx.Divider(TailwindColors.Gray100);
                ctx.Row(spacing: 0, () =>
                {
                    ctx.Text("💻 Dispositivo:").Bold().TextSm().TextColor(TailwindColors.Gray600).W("35%");
                    ctx.Text("Chrome 122 en Windows 11").TextSm().TextColor(TailwindColors.Gray800);
                });
                ctx.Divider(TailwindColors.Gray100);
                ctx.Row(spacing: 0, () =>
                {
                    ctx.Text("📍 Ubicación:").Bold().TextSm().TextColor(TailwindColors.Gray600).W("35%");
                    ctx.Text("Madrid, España (IP: 85.123.x.x)").TextSm().TextColor(TailwindColors.Gray800);
                });
            });
        }).P(20).Bg(TailwindColors.Gray50).RoundedLg().Border(1, TailwindColors.Gray200);

        ctx.Spacer(20);

        ctx.When(true, () =>
        {
            ctx.Row(spacing: 12, () =>
            {
                ctx.Button("Fui yo ✓", "https://example.com/security/confirm")
                    .Bg(TailwindColors.Green600).RoundedLg();
                ctx.Button("No fui yo ✗", "https://example.com/security/block")
                    .Bg(TailwindColors.Red600).RoundedLg();
            });
        });

        ctx.Spacer(20);

        ctx.Container(() =>
        {
            ctx.Column(spacing: 8, () =>
            {
                ctx.Text("🛡️ Recomendaciones de seguridad").Bold().TextSm().TextColor(TailwindColors.Gray700);
                ctx.Text("• Activa la autenticación de dos factores (2FA)").TextSm().TextColor(TailwindColors.Gray600);
                ctx.Text("• Usa una contraseña única y de al menos 12 caracteres").TextSm().TextColor(TailwindColors.Gray600);
                ctx.Text("• Revisa tus sesiones activas regularmente").TextSm().TextColor(TailwindColors.Gray600);
            });
        }).P(16).Bg(TailwindColors.Blue50).RoundedLg().BorderL(4, TailwindColors.Blue400);
    });
});

securityEmail.WithTheme(t =>
{
    t.Title = "Alerta de Seguridad — Nuevo inicio de sesión";
    t.ContentPadding = 28;
    t.FooterText = "Este es un mensaje automático de seguridad. No respondas a este email.";
});

File.WriteAllText("Output/SecurityAlert.html", securityEmail.Render());
Console.WriteLine("✔ SecurityAlert.html");

// ── 15. Email multicanal — Tema Minimal ─────────────────────
var minimalEmail = Email.Compose(ctx =>
{
    ctx.Column(spacing: 20, () =>
    {
        ctx.Text("example").FontSerif().Text2Xl().TextColor(TailwindColors.Gray900)
            .LeadingTight().Center();

        ctx.Divider(TailwindColors.Gray900, thickness: 2, marginVertical: 8);

        ctx.Heading("Tu suscripción ha sido renovada", level: 2)
            .TextColor(TailwindColors.Gray900).Center().FontSerif().LeadingTight();

        ctx.Text("Hola Juan,").TextColor(TailwindColors.Gray700);

        ctx.Text("Te confirmamos que tu suscripción al Plan Profesional ha sido renovada exitosamente por un año más. A continuación encontrarás los detalles:")
            .TextColor(TailwindColors.Gray600).LeadingRelaxed();

        ctx.Container(() =>
        {
            ctx.Column(spacing: 10, () =>
            {
                ctx.Row(spacing: 0, () =>
                {
                    ctx.Text("Plan").TextSm().TextColor(TailwindColors.Gray500).W("40%");
                    ctx.Text("Profesional").TextSm().Bold().TextColor(TailwindColors.Gray800)
                        .Align(TextAlign.Right).W("60%");
                });
                ctx.Divider(TailwindColors.Gray200);
                ctx.Row(spacing: 0, () =>
                {
                    ctx.Text("Periodo").TextSm().TextColor(TailwindColors.Gray500).W("40%");
                    ctx.Text("Mar 2026 — Mar 2027").TextSm().Bold().TextColor(TailwindColors.Gray800)
                        .Align(TextAlign.Right).W("60%");
                });
                ctx.Divider(TailwindColors.Gray200);
                ctx.Row(spacing: 0, () =>
                {
                    ctx.Text("Monto").TextSm().TextColor(TailwindColors.Gray500).W("40%");
                    ctx.Text("$149.00 / año").TextSm().Bold().TextColor(TailwindColors.Gray800)
                        .Align(TextAlign.Right).W("60%");
                });
                ctx.Divider(TailwindColors.Gray200);
                ctx.Row(spacing: 0, () =>
                {
                    ctx.Text("Próxima renovación").TextSm().TextColor(TailwindColors.Gray500).W("40%");
                    ctx.Text("4 de marzo, 2027").TextSm().Bold().TextColor(TailwindColors.Gray800)
                        .Align(TextAlign.Right).W("60%");
                });
            });
        }).P(20).Border(1, TailwindColors.Gray200).RoundedLg();

        ctx.Text("Si tienes alguna pregunta sobre tu suscripción, no dudes en contactarnos.")
            .TextColor(TailwindColors.Gray600);

        ctx.Text("Atentamente,").TextColor(TailwindColors.Gray600);
        ctx.Text("El equipo de Example").Bold().TextColor(TailwindColors.Gray800);

        ctx.Spacer(8);

        ctx.Row(spacing: 16, () =>
        {
            ctx.Link("https://example.com/account", "Mi cuenta")
                .TextColor(TailwindColors.Gray600).TextSm().Underline();
            ctx.Link("https://example.com/billing", "Facturación")
                .TextColor(TailwindColors.Gray600).TextSm().Underline();
            ctx.Link("https://example.com/help", "Centro de ayuda")
                .TextColor(TailwindColors.Gray600).TextSm().Underline();
        });
    });
}).WithTheme(EmailTheme.Minimal);

minimalEmail.WithTheme(t =>
{
    t.Title = "Suscripción renovada";
    t.FooterText = null;
});

File.WriteAllText("Output/SubscriptionRenewal.html", minimalEmail.Render());
Console.WriteLine("✔ SubscriptionRenewal.html");

// ── Debug: dump del árbol ───────────────────────────────────
Console.WriteLine();
Console.WriteLine("═══ Árbol del email de E-Commerce ═══");
Console.WriteLine(ecommerceEmail.DumpTree());

Console.WriteLine();
Console.WriteLine($"Total: {Directory.GetFiles("Output", "*.html").Length} emails generados en la carpeta Output/");
