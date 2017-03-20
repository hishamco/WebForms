using System;

namespace My.AspNetCore.WebForms
{
    public class PageDescriptor
    {
        private Type _pageType;

        public string Name => PageType.Name;

        public Type PageType
        {
            get => _pageType;

            set => _pageType = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string RelativePath { get; set; }
    }
}
