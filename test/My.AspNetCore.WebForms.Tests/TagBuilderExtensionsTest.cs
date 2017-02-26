using My.AspNetCore.WebForms.Rendering;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using Xunit;

namespace My.AspNetCore.WebForms.Tests
{
    public class TagBuilderExtensionsTest
    {
        [Fact]
        public void AddMultipleStylesShouldConcatenatedByComma()
        {
            // Arrange
            var builder = new TagBuilder("p");
            var writer = new StringWriter(new StringBuilder());

            // Act
            builder.InnerHtml.Append("This is paragraph");
            builder.AddStyle(new Style { Attribute = "color", Value = "#f00" });
            builder.AddStyle(new Style { Attribute = "font-size", Value = "14px" });
            builder.WriteTo(writer, HtmlEncoder.Default);

            // Assert
            Assert.Equal("<p style=\"color:#f00;font-size:14px\">This is paragraph</p>",
                writer.GetStringBuilder().ToString());
        }

        [Fact]
        public void AddMultipleCssClassesShouldConcatenatedBySpace()
        {
            // Arrange
            var builder = new TagBuilder("p");
            var writer = new StringWriter(new StringBuilder());

            // Act
            builder.InnerHtml.Append("This is paragraph");
            builder.AddCssClass("alert");
            builder.AddCssClass("alert-info");
            builder.WriteTo(writer, HtmlEncoder.Default);

            // Assert
            Assert.Equal("<p class=\"alert alert-info\">This is paragraph</p>",
                writer.GetStringBuilder().ToString());
        }
    }
}
