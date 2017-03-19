using My.AspNetCore.WebForms.Controls;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace My.AspNetCore.WebForms
{
    public sealed class ControlCollection : IEnumerable<Control>
    {
        private readonly List<Control> _controls;

        public ControlCollection()
        {
            _controls = new List<Control>();
        }

        public int Count => _controls.Count;

        public void Add(Control control)
        {
            _controls.Add(control);
        }

        public void Remove(Control control)
        {
            _controls.RemoveAll(c => c.Name == control.Name);
        }

        public void Clear()
        {
            _controls.Clear();
        }

        public bool Contains(Control control) =>
            _controls.Any(c => c.Name == control.Name);

        public IEnumerator<Control> GetEnumerator() =>
            _controls.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator();
    }
}
