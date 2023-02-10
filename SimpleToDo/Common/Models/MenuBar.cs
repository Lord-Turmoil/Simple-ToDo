using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleToDo.Common.Models
{
    /// <summary>
    /// Navigation menu bar concrete.
    /// </summary>
    public class MenuBar : BindableBase
    {
        public MenuBar(string icon, string title, string nameSpace)
        {
            _icon = icon;
            _title = title;
            _nameSpace = nameSpace;
        }

        /// <summary>
        /// Menu icon.
        /// </summary>
        private string _icon;
        public string Icon { get { return _icon; } set { _icon = value; } }

        /// <summary>
        /// Menu name
        /// </summary>
        private string _title;
        public string Title { get { return _title; } set { _title = value; } }

        /// <summary>
        /// Menu namespace?
        /// </summary>
        private string _nameSpace;
        public string NameSpace { get { return _nameSpace; } set { _nameSpace = value; } }
    }
}
