using My.AspNetCore.WebForms.Rendering;
using System.IO;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace My.AspNetCore.WebForms.Controls
{
    public class TextBox : Control
    {
        public string Text { get; set; }

        public async override Task RenderAsync(TextWriter writer)
        {
            var tagBuilder = new TagBuilder("input")
            {
                TagRenderMode = TagRenderMode.SelfClosing
            };
            tagBuilder.Attributes.Add("name", Name);
            tagBuilder.Attributes.Add("type", "text");
            tagBuilder.Attributes.Add("value", Text);
            tagBuilder.WriteTo(writer, HtmlEncoder.Default);

            await Task.CompletedTask;
        }
    }
}
