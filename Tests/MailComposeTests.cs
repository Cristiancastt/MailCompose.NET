using MailCompose;
using MailCompose.Nodes;
using Xunit;

namespace MailCompose.Tests;

public class TreeBuildingTests
{
    [Fact]
    public void Text_Creates_SingleNode()
    {
        var doc = Email.Compose(ctx =>
        {
            ctx.Text("Hello");
        });

        Assert.IsType<TextNode>(doc.Root);
        Assert.Equal("Hello", ((TextNode)doc.Root).Content);
    }

    [Fact]
    public void Column_Creates_ContainerWithChildren()
    {
        var doc = Email.Compose(ctx =>
        {
            ctx.Column(() =>
            {
                ctx.Text("A");
                ctx.Text("B");
            });
        });

        Assert.IsType<ColumnNode>(doc.Root);
        Assert.Equal(2, doc.Root.Children.Count);
        Assert.Equal("A", ((TextNode)doc.Root.Children[0]).Content);
        Assert.Equal("B", ((TextNode)doc.Root.Children[1]).Content);
    }

    [Fact]
    public void Row_Creates_HorizontalContainer()
    {
        var doc = Email.Compose(ctx =>
        {
            ctx.Row(spacing: 8, content: () =>
            {
                ctx.Text("Left");
                ctx.Text("Right");
            });
        });

        Assert.IsType<RowNode>(doc.Root);
        Assert.Equal(2, doc.Root.Children.Count);
    }

    [Fact]
    public void Nested_Columns_BuildCorrectTree()
    {
        var doc = Email.Compose(ctx =>
        {
            ctx.Column(() =>
            {
                ctx.Text("Top");
                ctx.Column(() =>
                {
                    ctx.Text("Nested A");
                    ctx.Text("Nested B");
                });
                ctx.Text("Bottom");
            });
        });

        Assert.IsType<ColumnNode>(doc.Root);
        Assert.Equal(3, doc.Root.Children.Count);
        Assert.IsType<TextNode>(doc.Root.Children[0]);
        Assert.IsType<ColumnNode>(doc.Root.Children[1]);
        Assert.Equal(2, doc.Root.Children[1].Children.Count);
        Assert.IsType<TextNode>(doc.Root.Children[2]);
    }

    [Fact]
    public void DumpTree_Shows_CorrectStructure()
    {
        var doc = Email.Compose(ctx =>
        {
            ctx.Column(() =>
            {
                ctx.Text("A");
                ctx.Text("B");
            });
        });

        var tree = doc.DumpTree();
        Assert.Contains("Column", tree);
        Assert.Contains("Text(\"A\")", tree);
        Assert.Contains("Text(\"B\")", tree);
    }

    [Fact]
    public void Button_HasDefaultStyles()
    {
        var doc = Email.Compose(ctx =>
        {
            ctx.Button("Click me", "https://example.com");
        });

        var btn = Assert.IsType<ButtonNode>(doc.Root);
        Assert.Equal("Click me", btn.Label);
        Assert.Equal("https://example.com", btn.Href);
        Assert.Equal(TailwindColors.Blue600, btn.Style.BackgroundColor);
    }

    [Fact]
    public void FluentApi_AppliesStyles()
    {
        var doc = Email.Compose(ctx =>
        {
            ctx.Text("Styled")
                .Bold()
                .FontSize(20)
                .TextColor(TailwindColors.Red500)
                .Center();
        });

        var text = Assert.IsType<TextNode>(doc.Root);
        Assert.Equal(FontWeight.Bold, text.Style.FontWeight);
        Assert.Equal(20, text.Style.FontSize);
        Assert.Equal(TailwindColors.Red500, text.Style.TextColor);
        Assert.Equal(TextAlign.Center, text.Style.TextAlign);
    }

    [Fact]
    public void ForEach_AddsMultipleChildren()
    {
        var items = new[] { "A", "B", "C" };
        var doc = Email.Compose(ctx =>
        {
            ctx.Column(() =>
            {
                ctx.ForEach(items, item => ctx.Text(item));
            });
        });

        Assert.Equal(3, doc.Root.Children.Count);
    }

    [Fact]
    public void When_True_AddsContent()
    {
        var doc = Email.Compose(ctx =>
        {
            ctx.Column(() =>
            {
                ctx.When(true, () => ctx.Text("Shown"));
                ctx.When(false, () => ctx.Text("Hidden"));
            });
        });

        Assert.Single(doc.Root.Children);
        Assert.Equal("Shown", ((TextNode)doc.Root.Children[0]).Content);
    }

    [Fact]
    public void MultipleRootNodes_WrappedInColumn()
    {
        var doc = Email.Compose(ctx =>
        {
            ctx.Text("First");
            ctx.Text("Second");
        });

        Assert.IsType<ColumnNode>(doc.Root);
        Assert.Equal(2, doc.Root.Children.Count);
    }
}

public class RenderingTests
{
    [Fact]
    public void Render_ProducesValidHtml()
    {
        var doc = Email.Compose(ctx =>
        {
            ctx.Text("Hello World");
        });

        var html = doc.Render();

        Assert.Contains("<!DOCTYPE html>", html);
        Assert.Contains("<html", html);
        Assert.Contains("Hello World", html);
        Assert.Contains("</html>", html);
    }

    [Fact]
    public void Render_EscapesHtml()
    {
        var doc = Email.Compose(ctx =>
        {
            ctx.Text("<script>alert('xss')</script>");
        });

        var html = doc.Render();
        Assert.DoesNotContain("<script>", html);
        Assert.Contains("&lt;script&gt;", html);
    }

    [Fact]
    public void Button_RendersAsTable()
    {
        var doc = Email.Compose(ctx =>
        {
            ctx.Button("Click", "https://example.com");
        });

        var html = doc.RenderBody();
        Assert.Contains("<table", html);
        Assert.Contains("href=\"https://example.com\"", html);
        Assert.Contains("Click", html);
    }

    [Fact]
    public void Column_RendersWithSpacing()
    {
        var doc = Email.Compose(ctx =>
        {
            ctx.Column(spacing: 12, content: () =>
            {
                ctx.Text("A");
                ctx.Text("B");
            });
        });

        var html = doc.RenderBody();
        Assert.Contains("padding-top:12px", html);
    }

    [Fact]
    public void Image_RendersImgTag()
    {
        var doc = Email.Compose(ctx =>
        {
            ctx.Image("https://img.example.com/photo.jpg", "Foto", width: 300);
        });

        var html = doc.RenderBody();
        Assert.Contains("<img", html);
        Assert.Contains("src=\"https://img.example.com/photo.jpg\"", html);
        Assert.Contains("width=\"300\"", html);
    }

    [Fact]
    public void Divider_RendersHr()
    {
        var doc = Email.Compose(ctx =>
        {
            ctx.Divider();
        });

        var html = doc.RenderBody();
        Assert.Contains("<hr", html);
    }

    [Fact]
    public void Theme_AppliesBodyBackground()
    {
        var doc = Email.Compose(ctx =>
        {
            ctx.Text("Dark mode");
        }).WithTheme(EmailTheme.Dark);

        var html = doc.Render();
        Assert.Contains(TailwindColors.Gray900, html);
    }

    [Fact]
    public void RenderBody_NoDoctype()
    {
        var doc = Email.Compose(ctx =>
        {
            ctx.Text("Body only");
        });

        var body = doc.RenderBody();
        Assert.DoesNotContain("DOCTYPE", body);
        Assert.Contains("Body only", body);
    }

    [Fact]
    public void Heading_RendersCorrectTag()
    {
        var doc = Email.Compose(ctx =>
        {
            ctx.Heading("Title", level: 1);
        });

        var html = doc.RenderBody();
        Assert.Contains("<h1", html);
        Assert.Contains("Title", html);
        Assert.Contains("</h1>", html);
    }

    [Fact]
    public void Link_RendersAnchorTag()
    {
        var doc = Email.Compose(ctx =>
        {
            ctx.Link("https://example.com", "Click here");
        });

        var html = doc.RenderBody();
        Assert.Contains("<a href=\"https://example.com\"", html);
        Assert.Contains("Click here", html);
    }

    [Fact]
    public void Footer_RendersWhenSet()
    {
        var doc = Email.Compose(ctx =>
        {
            ctx.Text("Content");
        });

        doc.WithTheme(t => t.FooterText = "© 2026 Company");
        var html = doc.Render();
        Assert.Contains("© 2026 Company", html);
    }

    [Fact]
    public void NodeStyle_GeneratesCss()
    {
        var style = new NodeStyle
        {
            FontSize = 16,
            FontWeight = FontWeight.Bold,
            TextColor = "#333",
            BackgroundColor = "#fff",
            BorderRadius = 8,
            Padding = 12
        };

        var css = style.ToCss();
        Assert.Contains("font-size:16px", css);
        Assert.Contains("font-weight:700", css);
        Assert.Contains("color:#333", css);
        Assert.Contains("background-color:#fff", css);
        Assert.Contains("border-radius:8px", css);
        Assert.Contains("padding:12px", css);
    }
}
