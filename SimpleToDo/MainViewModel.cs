using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SimpleToDo
{
	public class MainViewModel : ObservableObject
	{
		public RelayCommand? OnMinimizeButtonClicked { get; }
		public RelayCommand? OnMaximizeButtonClicked { get; }
		public RelayCommand? OnRestoreButtonClicked { get; }
		public RelayCommand? OnCloseButtonClicked { get; }

		public MainViewModel()
		{
			OnMinimizeButtonClicked = new RelayCommand(() =>
			{
				SystemCommands.MinimizeWindow(Application.Current.MainWindow);
			});

			OnMaximizeButtonClicked = new RelayCommand(() =>
			{
				SystemCommands.MaximizeWindow(Application.Current.MainWindow);
			});

			OnRestoreButtonClicked = new RelayCommand(() =>
			{
				SystemCommands.RestoreWindow(Application.Current.MainWindow);
			});

			OnCloseButtonClicked = new RelayCommand(() =>
			{
				SystemCommands.CloseWindow(Application.Current.MainWindow);
			});
		}
	}
}
