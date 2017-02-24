using My.AspNetCore.WebForms.Infrastructure;
using Xunit;

namespace My.AspNetCore.WebForms.Tests
{
    public class PageFactoryTest
    {
        [Fact]
        public void CreateInvalidPageReturnNull()
        {
            var pageFactory = new PageFactory();
            var page = pageFactory.CreatePage("InvalidPage");

            Assert.Equal(null, page);
        }
    }
}
