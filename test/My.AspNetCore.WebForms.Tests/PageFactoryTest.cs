using Microsoft.Extensions.Options;
using Moq;
using My.AspNetCore.WebForms.Infrastructure;
using Xunit;

namespace My.AspNetCore.WebForms.Tests
{
    public class PageFactoryTest
    {
        [Fact]
        public void CreateInvalidPageReturnNull()
        {
            // Arrange
            var webFormsOptions = new Mock<IOptions<WebFormsOptions>>();
            webFormsOptions.Setup(o => o.Value).Returns(new WebFormsOptions());
            var pageFactory = new PageFactory(webFormsOptions.Object);

            // Act
            var page = pageFactory.CreatePage("InvalidPage");

            // Assert
            Assert.Equal(null, page);
        }
    }
}
