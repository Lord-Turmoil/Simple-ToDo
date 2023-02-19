using Prism.Mvvm;
using SimpleToDo.Common.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleToDo.ViewModels
{
	public class AboutViewModel : BindableBase
	{
		public string Cowsay { get; private set; }

		private ObservableCollection<UrlBar> _urlBars;
		public ObservableCollection<UrlBar> UrlBars
		{
			get { return _urlBars; }
			set { _urlBars = value; RaisePropertyChanged(); }
		}

		public AboutViewModel()
		{
			_urlBars = new ObservableCollection<UrlBar>();
			_CreateUrlBars();

			Cowsay = 
			" _____________________________\n" +
			"/ Hello there! Come and visit \\\n" +
			"\\ www.tonys-studio.top        /\n" +
			" -----------------------------\n" +
			"        \\   ^__^\n" +
			"         \\  (oo)\\_______\n" +
			"            (__)\\       )\\/\\\n" +
			"                ||----w |\n" +
			"                ||     ||\n";
		}

		private void _CreateUrlBars()
		{
			UrlBars.Add(new UrlBar("Github", "https://github.com/Lord-Turmoil/Simple-ToDo"));
			UrlBars.Add(new UrlBar("Gitee", "https://gitee.com/tonys-studio/simple-to-do"));
			UrlBars.Add(new UrlBar("Tony's Studio", "http://www.tonys-studio.top"));
		}
	}
}
