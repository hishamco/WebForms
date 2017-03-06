using My.AspNetCore.WebForms.Rendering;
using System;
using System.IO;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace My.AspNetCore.WebForms.Controls
{
    public class Button : Control
    {
        public event EventHandler Click;

        public event CommandEventHandler Command;

        public string Text { get; set; }

        public int BorderWidth { get; set; }

        public BorderStyle BorderStyle { get; set; } = BorderStyle.None;

        public string BorderColor { get; set; }

        public string BackColor { get; set; }

        public string ForeColor { get; set; }

        public string CssClass { get; set; }

        public bool Enabled { get; set; } = true;

        public int Height { get; set; }

        public int Width { get; set; }

        public string ToolTip { get; set; }

        public Font Font { get; set; }

        public string CommandName { get; set; }

        public string CommandArgument { get; set; }

        protected virtual void OnClick(EventArgs e)
        {
            Click?.Invoke(this, e);
            OnCommand(new CommandEventArgs(CommandName, CommandArgument));
        }

        protected virtual void OnCommand(CommandEventArgs e)
        {
            Command?.Invoke(this, e);
        }

        public async override Task RenderAsync(TextWriter writer)
        {
            var tagBuilder = new TagBuilder("input")
            {
                TagRenderMode = TagRenderMode.SelfClosing
            };

            tagBuilder.Attributes.Add("name", Name);
            tagBuilder.Attributes.Add("type", "submit");
            tagBuilder.Attributes.Add("value", Text);

            if (!Visible)
            {
                tagBuilder.AddStyle(
                    new Style { Attribute = "display", Value = "none" });
            }

            if (BorderWidth > 0)
            {
                tagBuilder.AddStyle(
                    new Style { Attribute = "border-width", Value = $"{BorderWidth}px" });
            }

            if (BorderStyle > BorderStyle.None)
            {
                tagBuilder.AddStyle(
                    new Style { Attribute = "border-style",
                        Value = BorderStyle.ToString().ToLower() });
            }

            if (!string.IsNullOrEmpty(BorderColor))
            {
                tagBuilder.AddStyle(
                    new Style { Attribute = "border-color", Value = BorderColor });
            }

            if (!string.IsNullOrEmpty(BackColor))
            {
                tagBuilder.AddStyle(
                    new Style { Attribute = "background-color", Value = BackColor });
            }

            if (!string.IsNullOrEmpty(ForeColor))
            {
                tagBuilder.AddStyle(
                    new Style { Attribute = "color", Value = ForeColor });
            }

            if (!string.IsNullOrEmpty(CssClass))
            {
                tagBuilder.AddCssClass(CssClass);
            }

            if (!Enabled)
            {
                tagBuilder.Attributes.Add("disabled", "disabled");
            }

            if (Height > 0)
            {
                tagBuilder.AddStyle(
                    new Style { Attribute = "hidth", Value = $"{Height}px" });
            }

            if (Width > 0)
            {
                tagBuilder.AddStyle(
                    new Style { Attribute = "width", Value = $"{Width}px" });
            }

            if (!string.IsNullOrEmpty(ToolTip))
            {
                tagBuilder.Attributes.Add("title", ToolTip);
            }

            if (Font != null)
            {
                if (!string.IsNullOrEmpty(Font.Name))
                {
                    tagBuilder.AddStyle(
                        new Style { Attribute = "font-family", Value = Font.Name });
                }

                if (Font.Size > 0)
                {
                    tagBuilder.AddStyle(
                        new Style { Attribute = "font-size", Value = $"{Font.Size}px" });
                }

                if (Font.Bold)
                {
                    tagBuilder.AddStyle(
                        new Style { Attribute = "font-weight", Value = "bold" });
                }

                if (Font.Italic)
                {
                    tagBuilder.AddStyle(
                        new Style { Attribute = "font-style", Value = "italic" });
                }

                if (Font.Underline)
                {
                    tagBuilder.AddStyle(
                        new Style { Attribute = "text-decoration", Value = "underline" });
                }

                if (Font.Stirkeout)
                {
                    tagBuilder.AddStyle(
                        new Style { Attribute = "text-decoration", Value = "line-throug" });
                }
            }

            if (!string.IsNullOrEmpty(CommandName))
            {
                tagBuilder.Attributes.Add("data-commandName", CommandName);
            }

            if (!string.IsNullOrEmpty(CommandArgument))
            {
                tagBuilder.Attributes.Add("data-commandArgument", CommandArgument);
            }

            tagBuilder.WriteTo(writer, HtmlEncoder.Default);

            await Task.CompletedTask;
        }
    }
}
