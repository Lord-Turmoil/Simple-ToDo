using DryIoc;
using Prism.Events;
using Prism.Regions;
using SimpleToDo.Extensions;
using SimpleToDo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SimpleToDo.Views
{
	/// <summary>
	/// Interaction logic for MainView.xaml
	/// </summary>
	public partial class MainView : Window
	{
		public MainView(IEventAggregator aggregator)
		{
			InitializeComponent();

			// Register loading view.
			aggregator.Register(arg => {
				DialogHost.IsOpen = arg.IsOpen;

				if (DialogHost.IsOpen)
				{
					DialogHost.DialogContent = new ProgressView();
				}
			});

			this.MaxHeight = SystemParameters.PrimaryScreenHeight;

			// No need if we use prism?
			// this.DataContext = new MainViewModel();

			_InitializeEvents();
		}

		private void _InitializeEvents()
		{
			StateChanged += _MainWindowStateChangeRaised;

			colorZone.MouseLeftButtonDown += (s, e) => { this.DragMove(); };
			colorZone.MouseDoubleClick += (s, e) => { _ChangeWindowState(); };

			btnClose.Click += (s, e) => { SystemCommands.CloseWindow(this); };
			btnMaximize.Click += (s, e) => { SystemCommands.MaximizeWindow(this); };
			btnRestore.Click += (s, e) => { SystemCommands.RestoreWindow(this); };
			btnMinimize.Click += (s, e) => { SystemCommands.MinimizeWindow(this); };

			menuBar.SelectionChanged += (s, e) => {
				drawerHost.IsLeftDrawerOpen = false;
			};
		}

		private void _MainWindowStateChangeRaised(object? sender, EventArgs e)
		{
			if (WindowState == WindowState.Maximized)
			{
				mainWindowBorder.BorderThickness = new Thickness(8);
				btnMaximize.Visibility = Visibility.Collapsed;
				btnRestore.Visibility = Visibility.Visible;
			}
			else
			{
				mainWindowBorder.BorderThickness = new Thickness(0);
				btnMaximize.Visibility = Visibility.Visible;
				btnRestore.Visibility = Visibility.Collapsed;
			}
		}

		private void _ChangeWindowState()
		{
			if (WindowState == WindowState.Maximized)
				SystemCommands.RestoreWindow(this);
			else
				SystemCommands.MaximizeWindow(this);
		}
	}
}
