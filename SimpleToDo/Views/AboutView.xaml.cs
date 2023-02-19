using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
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

namespace SimpleToDo.Views
{
	/// <summary>
	/// Interaction logic for AboutView.xaml
	/// </summary>
	public partial class AboutView : UserControl
	{
		public AboutView()
		{
			InitializeComponent();
		}

		private void OnHyperlinkClicked(object sender, RoutedEventArgs e)
		{
			Hyperlink link = sender as Hyperlink;
			var psi = new ProcessStartInfo
			{
				FileName = link.NavigateUri.AbsoluteUri,
				UseShellExecute = true
			};
			Process.Start(psi);
		}
	}
}
