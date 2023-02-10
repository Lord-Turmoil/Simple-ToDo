using Prism.DryIoc;
using Prism.Ioc;
using SimpleToDo.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SimpleToDo
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : PrismApplication
	{
		protected override Window CreateShell()
		{
			return Container.Resolve<MainView>();
		}

		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
			// Nothing for now.
		}
	}
}
