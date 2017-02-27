using System;
using System.Collections.Generic;
using System.Text;

namespace My.AspNetCore.WebForms.Controls
{
    public class Font
    {
        public Font(string name)
            : this(name, 0, FontStyle.Regular)
        {

        }

        public Font(string name, int size)
            : this(name, size, FontStyle.Regular)
        {

        }

        public Font(string name, FontStyle style)
            : this(name, 0, style)
        {

        }

        public Font(string name, int size, FontStyle style)
        {
            Name = name;
            Size = size;
            Style = style;
        }

        public string Name { get; }

        public FontStyle Style { get; }

        public int Size { get; }

        public bool Bold => (Style & FontStyle.Bold) != 0;

        public bool Italic => (Style & FontStyle.Italic) != 0;

        public bool Underline => (Style & FontStyle.Underline) != 0;

        public bool Stirkeout => (Style & FontStyle.Strikeout) != 0;
    }
}
