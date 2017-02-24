namespace My.AspNetCore.WebForms.Controls
{
    public abstract class Control
    {
        public string Id { get; set; }

        public string InnerHtml { get; protected set; }

        public abstract void Render();
    }
}
