using Microsoft.AspNetCore.Http;
using My.AspNetCore.WebForms.Infrastructure;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using My.AspNetCore.WebForms.Tests.Pages;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;

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

        [Fact]
        public void CreatePageWithInjectedService()
        {
            // Arrange
            var pageFactory = new DefaultPageFactory();
            var pageContext = new PageContext()
            {
                HttpContext = BuildHttpContext(),
                PageDescriptor = new PageDescriptor
                {
                    PageType = typeof(ServicePage),
                    RelativePath = "ServicePage"
                }
            };

            // Act
            var page = (ServicePage)pageFactory.CreatePage(pageContext);

            // Assert
            Assert.NotNull(page.HostingEnvironment);

            HttpContext BuildHttpContext()
            {
                var context = new DefaultHttpContext();
                var services = new ServiceCollection();
                services.AddSingleton<IHostingEnvironment, HostingEnvironment>();
                context.RequestServices = new DefaultServiceProviderFactory()
                    .CreateServiceProvider(services);

                return context;
            }
        }
    }
}
