﻿using Prism.DryIoc;
using Prism.Ioc;
using Prism.Regions;
using SimpleToDo.Extensions;
using SimpleToDo.ViewModels;
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
			containerRegistry.RegisterForNavigation<IndexView, IndexViewModel>();
			containerRegistry.RegisterForNavigation<MemoView, MemoViewModel>();
			containerRegistry.RegisterForNavigation<SettingsView, SettingsViewModel>();
			containerRegistry.RegisterForNavigation<ToDoView, ToDoViewModel>();
		}
	}
}
