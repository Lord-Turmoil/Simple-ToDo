using MaterialDesignColors;
using MaterialDesignColors.ColorManipulation;
using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SimpleToDo.ViewModels
{
	public class SkinViewModel : BindableBase
	{
		public IEnumerable<ISwatch> Swatches { get; } = SwatchHelper.Swatches;

		public DelegateCommand<object> ChangeHueCommand { get; private set; }

		private bool _isDarkTheme;
		public bool IsDarkTheme
		{
			get { return _isDarkTheme; }
			set
			{
				if (SetProperty(ref _isDarkTheme, value))
				{
					_ModifyTheme(theme => theme.SetBaseTheme(value ? Theme.Dark : Theme.Light));
				}
			}
		}

		private readonly PaletteHelper _paletteHelper = new PaletteHelper();

		public SkinViewModel()
		{
			IsDarkTheme = true;
			ChangeHueCommand = new DelegateCommand<object>(_ChangeHue);
		}

		private void _ChangeHue(object obj)
		{
			var hue = (Color)obj;
			ITheme theme = _paletteHelper.GetTheme();
			theme.PrimaryLight = new ColorPair(hue.Lighten());
			theme.PrimaryMid = new ColorPair(hue);
			theme.PrimaryDark = new ColorPair(hue.Darken());
			_paletteHelper.SetTheme(theme);
		}

		private void _ModifyTheme(Action<ITheme> modificationAction)
		{
			ITheme theme = _paletteHelper.GetTheme();
			modificationAction?.Invoke(theme);
			_paletteHelper.SetTheme(theme);
		}
	}
}
