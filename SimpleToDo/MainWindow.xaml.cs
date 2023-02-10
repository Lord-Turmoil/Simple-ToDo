using MaterialDesignThemes.Wpf;
using Prism.Services.Dialogs;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleToDo
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			this.MaxHeight = SystemParameters.PrimaryScreenHeight;
			this.DataContext = new MainViewModel();

			StateChanged += _MainWindowStateChangeRaised;

			colorZone.MouseLeftButtonDown += (s, e) => { this.DragMove(); };
			colorZone.MouseDoubleClick += (s, e) => { _ChangeWindowState(); };
		}

		private void _MainWindowStateChangeRaised(object? sender, EventArgs e)
		{
			_ChangeCaptionButton();
		}

		private void _ChangeCaptionButton()
		{
			if (WindowState == WindowState.Maximized)
			{
				btnMaximize.Visibility = Visibility.Collapsed;
				btnRestore.Visibility = Visibility.Visible;
			}
			else
			{
				btnMaximize.Visibility = Visibility.Visible;
				btnRestore.Visibility = Visibility.Collapsed;
			}
		}

		private void _ChangeWindowState()
		{
			if (WindowState == WindowState.Maximized)
			{
				SystemCommands.RestoreWindow(this);
			}
			else
			{
				SystemCommands.MaximizeWindow(this);
			}
		}
	}
}
