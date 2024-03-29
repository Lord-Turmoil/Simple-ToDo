﻿using DryIoc;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Regions;
using SimpleToDo.Extensions;
using SimpleToDo.Service;
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
			containerRegistry.GetContainer()
				.Register<HttpRestClient>(made: Parameters.Of.Type<string>(serviceKey: "WebUrl"));
			containerRegistry.GetContainer().RegisterInstance(@"http://localhost:16169/", serviceKey: "WebUrl");

			containerRegistry.Register<IToDoService, ToDoService>();
			containerRegistry.Register<IMemoService, MemoService>();

			containerRegistry.RegisterForNavigation<IndexView, IndexViewModel>();
			containerRegistry.RegisterForNavigation<MemoView, MemoViewModel>();
			containerRegistry.RegisterForNavigation<SettingsView, SettingsViewModel>();
			containerRegistry.RegisterForNavigation<ToDoView, ToDoViewModel>();

			containerRegistry.RegisterForNavigation<SkinView, SkinViewModel>();
			containerRegistry.RegisterForNavigation<SystemView, SystemViewModel>();
			containerRegistry.RegisterForNavigation<AboutView, AboutViewModel>();

			if (containerRegistry.IsRegistered<HttpRestClient>())
			{
				var client = containerRegistry.GetContainer().Resolve<HttpRestClient>();
			}
		}
	}
}
