using System;

namespace My.AspNetCore.WebForms.Rendering
{
    public static class TagBuilderExtensions
    {
        public static void AddStyle(this TagBuilder builder, string attribute, string value)
        {
            if (string.IsNullOrEmpty(attribute))
            {
                throw new ArgumentNullException(nameof(attribute));
            }

            if (builder.Attributes.TryGetValue("style", out string currentStyle))
            {
                builder.Attributes["style"] = currentStyle + ";" + $"{attribute}:{value}";
            }
            else
            {
                builder.Attributes["style"] = $"{attribute}:{value}";
            }
        }

        public static void AddStyle(this TagBuilder builder, Style style)
        {
            builder.AddStyle(style.Attribute, style.Value);
        }
    }
}
