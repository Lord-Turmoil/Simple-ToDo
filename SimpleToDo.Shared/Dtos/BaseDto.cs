using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SimpleToDo.Shared.Dtos
{
	/// <summary>
	/// For client, data should support notify, while backend doesn't need.
	/// So we wrap raw data to make it more flexible.
	/// </summary>
	public class BaseDto : INotifyPropertyChanged
	{
		public int ID { get; set; }

		public event PropertyChangedEventHandler? PropertyChanged;

		public void RaisePropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
