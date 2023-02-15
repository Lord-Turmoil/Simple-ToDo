using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleToDo.Common.Models
{
	public class TaskBar : BindableBase
	{
        public TaskBar(string icon, string title, string content, string color, string target)
        {
			Icon = icon;
			Title = title;
			Content = content;
			Color = color;
			Target = target;
        }

        public string Icon { get; private set; }
		public string Title { get; private set; }
		public string Content { get; private set; }
		public string Color { get; private set; }
		public string Target { get; private set; }
	}
}
