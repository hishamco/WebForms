using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;

namespace My.AspNetCore.WebForms.Rendering
{
    // Refer to Microsoft.AspNetCore.Mvc.ViewFeatures/Rendering/TagBuilder.cs
    public class TagBuilder : IHtmlContent
    {
        public TagBuilder(string tagName)
        {
            if (string.IsNullOrEmpty(tagName))
            {
                throw new ArgumentException(nameof(tagName));
            }

            TagName = tagName;
        }

        public string TagName { get; }

        public IDictionary<string, string> Attributes { get; } = new Dictionary<string, string>();

        public IHtmlContentBuilder InnerHtml { get; } = new HtmlContentBuilder();

        public TagRenderMode TagRenderMode { get; set; } = TagRenderMode.Normal;

        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            if (encoder == null)
            {
                throw new ArgumentNullException(nameof(encoder));
            }

            switch (TagRenderMode)
            {
                case TagRenderMode.StartTag:
                    writer.Write('<');
                    writer.Write(TagName);
                    AppendAttributes(writer, encoder);
                    writer.Write('>');
                    break;
                case TagRenderMode.EndTag:
                    writer.Write("</");
                    writer.Write(TagName);
                    writer.Write('>');
                    break;
                case TagRenderMode.SelfClosing:
                    writer.Write('<');
                    writer.Write(TagName);
                    AppendAttributes(writer, encoder);
                    writer.Write(" />");
                    break;
                default:
                    writer.Write('<');
                    writer.Write(TagName);
                    AppendAttributes(writer, encoder);
                    writer.Write('>');
                    InnerHtml.WriteTo(writer, encoder);
                    writer.Write("</");
                    writer.Write(TagName);
                    writer.Write('>');
                    break;
            }
        }

        private void AppendAttributes(TextWriter writer, HtmlEncoder encoder)
        {
            foreach (var attribute in Attributes)
            {
                var key = attribute.Key;
                if (string.Equals(key, "id", StringComparison.OrdinalIgnoreCase) &&
                    string.IsNullOrEmpty(attribute.Value))
                {
                    continue;
                }

                writer.Write(' ');
                writer.Write(key);
                writer.Write("=\"");
                if (attribute.Value != null)
                {
                    encoder.Encode(writer, attribute.Value);
                }

                writer.Write('"');
            }
        }
    }
}
