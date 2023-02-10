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
	class MainViewModel : BindableBase
    {
        private ObservableCollection<MenuBar> _menuBars;
        public ObservableCollection<MenuBar> MenuBars
        {
            get { return _menuBars; }
            set { _menuBars = value; RaisePropertyChanged(); }
        }

        public MainViewModel()
        {
            _menuBars = new ObservableCollection<MenuBar>();
            _CreateMenuBar();
        }

        private void _CreateMenuBar()
        {
            MenuBars.Add(new MenuBar("HomeOutline",      "Home",     "IndexView"));
            MenuBars.Add(new MenuBar("FormatListChecks", "ToDo",     "ToDoView"));
            MenuBars.Add(new MenuBar("NotebookOutline",  "Memo",     "MemoView"));
            MenuBars.Add(new MenuBar("CogOutline",       "Settings", "SettingsView"));
		}
    }
}
