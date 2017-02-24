namespace My.AspNetCore.WebForms.Infrastructure
{
    public interface IPageFactory
    {
        Page CreatePage(string type);
    }
}
