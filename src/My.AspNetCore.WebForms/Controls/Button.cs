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

        public string Text { get; set; }

        protected virtual void OnClick()
        {
            Click?.Invoke(this, EventArgs.Empty);
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
            tagBuilder.WriteTo(writer, HtmlEncoder.Default);

            await Task.CompletedTask;
        }
    }
}
