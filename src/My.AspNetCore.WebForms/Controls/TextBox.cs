using My.AspNetCore.WebForms.Rendering;
using System;
using System.IO;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace My.AspNetCore.WebForms.Controls
{
    public class TextBox : Control, IPostBackDataHandler
    {
        public event EventHandler TextChanged;

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

        public TextBoxMode TextMode { get; set; } = TextBoxMode.SingleLine;

        public int Columns { get; set; }

        public int Rows { get; set; }

        public bool ReadOnly { get; set; }

        protected virtual void OnTextChanged(EventArgs e)
        {
            TextChanged?.Invoke(this, e);
        }

        public async override Task RenderAsync(TextWriter writer)
        {
            var tagName = "input";

            if (TextMode == TextBoxMode.MultiLine)
            {
                tagName = "textarea";
            }

            var tagBuilder = new TagBuilder(tagName)
            {
                TagRenderMode = TagRenderMode.SelfClosing
            };

            tagBuilder.Attributes.Add("name", Name);
            switch (TextMode)
            {
                case TextBoxMode.SingleLine:
                    tagBuilder.Attributes.Add("type", "text");
                    break;
                case TextBoxMode.MultiLine:
                    if (Columns > 0)
                    {
                        tagBuilder.Attributes.Add("cols", Columns.ToString());
                    }
                    if (Rows > 0)
                    {
                        tagBuilder.Attributes.Add("rows", Rows.ToString());
                    }
                    break;
                case TextBoxMode.Password:
                    tagBuilder.Attributes.Add("type", "password");
                    break;
            }

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
                    new Style
                    {
                        Attribute = "border-style",
                        Value = BorderStyle.ToString().ToLower()
                    });
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

            if (ReadOnly)
            {
                tagBuilder.Attributes.Add("readonly", "readonly");
            }

            tagBuilder.WriteTo(writer, HtmlEncoder.Default);

            await Task.CompletedTask;
        }

        public void LoadPostData(IDictionary<string, string> postBackData)
        {
            var currentText = Text;
            var postData = postBackData[Name];

            if (!ReadOnly && currentText != postData)
            {
                Text = postData;
                OnTextChanged(EventArgs.Empty);
            }
        }
    }
}
