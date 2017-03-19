using Microsoft.AspNetCore.Http;
using System;

namespace My.AspNetCore.WebForms
{
    public class PageLoadEventArgs : EventArgs
    {
        private readonly HttpContext _context;

        internal PageLoadEventArgs(HttpContext context)
        {
            _context = context;
        }

        public bool IsPostBack => _context.Request.Method == "POST";
    }
}
