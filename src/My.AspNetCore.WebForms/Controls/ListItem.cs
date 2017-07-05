using My.AspNetCore.WebForms.Rendering;
using System.IO;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace My.AspNetCore.WebForms.Controls
{
    // TODO: Use proper property ( Text or Value ), when we support data binding
    public class ListItem : Control
    {
        public ListItem()
            :this(null, null)
        {

        }

        public ListItem(string text)
            : this(text, null)
        {

        }

        public ListItem(string text, string value)
        {
            this.Text = text;
            this.Value = value;
        }

        public ListItem(string text, string value, bool enabled)
            : this(text, value)
        {
            this.Enabled = enabled;
        }

        public bool Enabled { get; set; }

        public bool Selected { get; set; }

        public string Text { get; set; }

        public string Value { get; set; }

        public async override Task RenderAsync(TextWriter writer)
        {
            var tagName = "option";
            var tagBuilder = new TagBuilder(tagName)
            {
                TagRenderMode = TagRenderMode.Normal
            };

            tagBuilder.Attributes.Add("name", Name);

            if (Text != null)
            {
                tagBuilder.Attributes.Add("value", Text);
            }

            if (Selected)
            {
                tagBuilder.Attributes.Add("selected", "selected");
            }

            tagBuilder.InnerHtml.Append(Text);
            tagBuilder.WriteTo(writer, HtmlEncoder.Default);
            await Task.CompletedTask;
        }
    }
}
