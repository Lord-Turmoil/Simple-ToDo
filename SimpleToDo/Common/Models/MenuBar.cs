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
			Icon = icon;
			Title = title; 
			NameSpace = nameSpace;
		}

		/// <summary>
		/// Menu icon.
		/// </summary>
		public string Icon { get; private set; }
		public string Title { get; private set; }
		public string NameSpace { get; private set; }
	}
}
