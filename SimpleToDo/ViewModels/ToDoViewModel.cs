using Prism.Commands;
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
	public class ToDoViewModel : BindableBase
	{
		private ObservableCollection<ToDoDto> _toDoDtos;
		public ObservableCollection<ToDoDto> ToDoDtos
		{
			set { _toDoDtos = value; RaisePropertyChanged(); }
			get { return _toDoDtos; }
		}

		public ToDoViewModel()
		{
			_toDoDtos = new ObservableCollection<ToDoDto>();
			_CreateDefaultToDoList();
			AddCommand = new DelegateCommand(_Add);
		}

		/// <summary>
		/// Properties related to right drawer.
		/// </summary>
		public DelegateCommand AddCommand { get; private set; }
		private bool _isRightDrawerOpen;
		public bool IsRightDrawerOpen
		{
			set { _isRightDrawerOpen = value; RaisePropertyChanged(); }
			get { return _isRightDrawerOpen; }
		}

		private void _Add()
		{
			IsRightDrawerOpen = !IsRightDrawerOpen;
		}

		private void _CreateDefaultToDoList()
		{
			for (int i = 1; i <= 10; i++)
			{
				_toDoDtos.Add(new ToDoDto
				{
					Title = "Todo " + i,
					Content = i.ToString() + " is not completed."
				});
			}
		}
	}
}
