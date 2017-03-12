namespace Microsoft.Extensions.DependencyInjection
{
    public class WebFormsOptions
    {
        public const string DefaultPagesLocation = "Pages";

        public string PagesLocation { get; set; } = DefaultPagesLocation;
    }
}
