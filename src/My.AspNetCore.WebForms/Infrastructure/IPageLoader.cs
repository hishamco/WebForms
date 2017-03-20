using System;

namespace My.AspNetCore.WebForms.Infrastructure
{
    public interface IPageLoader
    {
        Type Load(string relativePath);
    }
}
