using My.AspNetCore.WebForms.Controls;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace My.AspNetCore.WebForms.Tests
{
    public class LiteralTest
    {
        [Fact]
        public async Task DefaultTextShouldEncoded()
        {
            // Arrange
            var lit = new Literal
            {
                Text = "<h1>Literal</h1>"
            };
            var writer = new StringWriter(new StringBuilder());

            // Act
            await lit.RenderAsync(writer);

            // Assert
            Assert.Equal("&lt;h1&gt;Literal&lt;/h1&gt;", lit.Text);
        }
    }
}
