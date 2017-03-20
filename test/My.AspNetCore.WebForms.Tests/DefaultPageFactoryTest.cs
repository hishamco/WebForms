using My.AspNetCore.WebForms.Infrastructure;
using Xunit;

namespace My.AspNetCore.WebForms.Tests
{
    public class DefaultPageFactoryTest
    {
        [Fact]
        public void CreatePageWithEmptyContextReturnNull()
        {
            // Arrange
            var pageFactory = new DefaultPageFactory();
            var pageContext = new PageContext();

            // Act
            var page = pageFactory.CreatePage(pageContext);

            // Assert
            Assert.Null(page);
        }

        [Fact]
        public void CreatePage()
        {
            // Arrange
            var pageFactory = new DefaultPageFactory();
            var pageContext = new PageContext
            {
                Page = new TestPage(),
                PageDescriptor = new PageDescriptor
                {
                    PageType = typeof(TestPage),
                    RelativePath = "Test"
                }
            };

            // Act
            var page = pageFactory.CreatePage(pageContext);

            // Assert
            Assert.NotNull(page);
        }

        private class TestPage : Page
        {

        }
    }
}
