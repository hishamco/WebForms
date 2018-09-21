using My.AspNetCore.WebForms.Rendering;
using System;
using System.IO;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace My.AspNetCore.WebForms.Controls
{
    public class HyperLink : Control
    {
        public event EventHandler Click;

        public event CommandEventHandler Command;

        public int ImageHeight { get; set; }

        public string ImageUrl { get; set; }

        public int ImageWidth { get; set; }

        public string NavigationUrl { get; set; }

        public string Target { get; set; }

        public string Text { get; set; }

        public async override Task RenderAsync(TextWriter writer)
        {
            var tagBuilder = new TagBuilder("a")
            {
                TagRenderMode = TagRenderMode.Normal
            };

            tagBuilder.Attributes.Add("href", NavigationUrl);

            if (!string.IsNullOrEmpty(ImageUrl))
            {
                var imgTagBuilder = new TagBuilder("img")
                {
                    TagRenderMode = TagRenderMode.SelfClosing
                };

                imgTagBuilder.Attributes.Add("src", ImageUrl);
                imgTagBuilder.Attributes.Add("height", $"{ImageHeight}px");
                imgTagBuilder.Attributes.Add("width", $"{ImageWidth}px");
                tagBuilder.InnerHtml.AppendHtml(imgTagBuilder.ToString());
            }
            else
            {
                tagBuilder.InnerHtml.Append(Text);
            }

            tagBuilder.WriteTo(writer, HtmlEncoder.Default);

            await Task.CompletedTask;
        }
    }
}
