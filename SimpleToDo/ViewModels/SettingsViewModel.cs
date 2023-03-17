using Prism.Commands;
using Prism.Ioc;
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
	public class SettingsViewModel : NavigationViewModel
	{
		private ObservableCollection<MenuBar> _menuBars;
		public ObservableCollection<MenuBar> MenuBars
		{
			get { return _menuBars; }
			set { _menuBars = value; RaisePropertyChanged(); }
		}

		public DelegateCommand<MenuBar> NavigateCommand { get; private set; }
		private IRegionManager _regionManager;

		public SettingsViewModel(IContainerProvider provider, IRegionManager regionManager)
			: base(provider)
		{
			_regionManager = regionManager;

			_menuBars = new ObservableCollection<MenuBar>();
			NavigateCommand = new DelegateCommand<MenuBar>(_Navigate);

			_CreateMenuBars();
		}

		private void _CreateMenuBars()
		{
			MenuBars.Add(new MenuBar("PaletteOutline", "Personalization", "SkinView"));
			MenuBars.Add(new MenuBar("ContentSaveCogOutline", "System", "SystemView"));
			MenuBars.Add(new MenuBar("InformationOutline", "About", "AboutView"));
		}

		private void _Navigate(MenuBar obj)
		{
			if ((obj == null) || string.IsNullOrEmpty(obj.NameSpace))
				return;

			_regionManager.Regions[PrismManager.SettingsViewRegionName].RequestNavigate(obj.NameSpace);
		}
	}
}
