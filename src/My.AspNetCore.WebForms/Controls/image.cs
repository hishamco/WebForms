using My.AspNetCore.WebForms.Rendering;
using System;
using System.IO;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace My.AspNetCore.WebForms.Controls
{
    public class Image : Control
    {
        public string AlternateText { get; set; }

        public string DescriptionUrl { get; set; }

        public ImageAlign ImageAlign { get; set; }

        public string ImageUrl { get; set; }

        public async override Task RenderAsync(TextWriter writer)
        {
            var tagBuilder = new TagBuilder("img")
            {
                TagRenderMode = TagRenderMode.Normal
            };

            tagBuilder.Attributes.Add("alt", AlternateText);
            tagBuilder.Attributes.Add("src", ImageUrl);
            if (!String.IsNullOrEmpty(DescriptionUrl))
            {
                tagBuilder.Attributes.Add("longdesc", DescriptionUrl);
            }

            if (ImageAlign != ImageAlign.NotSet)
            {
                tagBuilder.Attributes.Add("align", ImageAlign.ToString().ToLower());
            }

            tagBuilder.WriteTo(writer, HtmlEncoder.Default);

            await Task.CompletedTask;
        }
    }
}
