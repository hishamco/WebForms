using Microsoft.AspNetCore.Hosting;

namespace My.AspNetCore.WebForms.Tests
{
    public class ServicePage : Page
    {
        public ServicePage(IHostingEnvironment env)
        {
            HostingEnvironment = env;
        }

        public IHostingEnvironment HostingEnvironment { get; }
    }
}
