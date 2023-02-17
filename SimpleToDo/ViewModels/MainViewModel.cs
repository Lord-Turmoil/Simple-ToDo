using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using SimpleToDo.Common.Models;
using SimpleToDo.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleToDo.ViewModels
{
	class MainViewModel : BindableBase
	{
		private ObservableCollection<MenuBar> _menuBars;
		public ObservableCollection<MenuBar> MenuBars
		{
			set { _menuBars = value; RaisePropertyChanged(); }
			get { return _menuBars; }
		}

		/// <summary>
		/// !!! IRegionManager! IRegionManager! IRegionManager! Interface!!!
		/// </summary>
		/// <param name="regionManager">Interface!!!</param>
		public MainViewModel(IRegionManager regionManager)
		{
			_regionManager = regionManager;

			_menuBars = new ObservableCollection<MenuBar>();
			_CreateMenuBar();

			NavigateCommand = new DelegateCommand<MenuBar>(_Navigate);
			MovePrevCommand = new DelegateCommand(() =>
			{
				if (_navigationJournal != null && _navigationJournal.CanGoBack)
					_navigationJournal.GoBack();
			});
			MoveNextCommand = new DelegateCommand(() =>
			{
				if (_navigationJournal != null && _navigationJournal.CanGoForward)
					_navigationJournal.GoForward();
			});
			HomeCommand = new DelegateCommand(() =>
			{
				_regionManager.Regions[PrismManager.MainViewRegionName]
				.RequestNavigate("IndexView", back =>
				{
					_navigationJournal = back.Context.NavigationService.Journal;
				});
			});
		}

		private void _CreateMenuBar()
		{
			MenuBars.Add(new MenuBar("HomeOutline", "Home", "IndexView"));
			MenuBars.Add(new MenuBar("FormatListChecks", "ToDo", "ToDoView"));
			MenuBars.Add(new MenuBar("NotebookOutline", "Memo", "MemoView"));
			MenuBars.Add(new MenuBar("CogOutline", "Settings", "SettingsView"));
		}

		// For navigation.
		public DelegateCommand<MenuBar> NavigateCommand { get; private set; }
		public DelegateCommand MovePrevCommand { get; private set; }
		public DelegateCommand MoveNextCommand { get; private set; }
		public DelegateCommand HomeCommand { get; private set; }

		private readonly IRegionManager _regionManager;
		private IRegionNavigationJournal? _navigationJournal;

		private void _Navigate(MenuBar obj)
		{
			if ((obj == null) || string.IsNullOrWhiteSpace(obj.NameSpace))
				return;

			_regionManager.Regions[PrismManager.MainViewRegionName]
				.RequestNavigate(obj.NameSpace, back =>
				{
					_navigationJournal = back.Context.NavigationService.Journal;
				});
		}
	}
}
