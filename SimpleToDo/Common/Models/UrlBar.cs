using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleToDo.Common.Models
{
	public class UrlBar
	{
		public string Title { get; set; }
		public string Url { get; set; }

		public UrlBar(string title, string url)
		{
			Title = title;
			Url = url;
		}
	}
}
