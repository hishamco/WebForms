using System;

namespace My.AspNetCore.WebForms
{
    public class PageLoadEventArgs : EventArgs
    {
        private readonly PageContext _context;

        internal PageLoadEventArgs(PageContext context)
        {
            _context = context;
        }

        public bool IsPostBack => _context.HttpContext.Request.Method == "POST";
    }
}
