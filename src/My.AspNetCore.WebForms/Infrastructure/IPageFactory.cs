using System;

namespace My.AspNetCore.WebForms.Infrastructure
{
    public interface IPageFactory
    {
        object CreatePage(string type);
    }
}
