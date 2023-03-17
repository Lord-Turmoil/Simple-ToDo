using Prism.Commands;
using Prism.Mvvm;
using SimpleToDo.Service;
using SimpleToDo.Shared.Dtos;
using SimpleToDo.Shared.Parameters;
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
		public ToDoViewModel(IToDoService service)
		{
			_service = service;

			_toDoDtos = new ObservableCollection<ToDoDto>();
			// _CreateDefaultToDoList();
			_CreateToDoList();

			AddCommand = new DelegateCommand(_Add);
			IsRightDrawerOpen = false;
		}

		private readonly IToDoService _service;

		private ObservableCollection<ToDoDto> _toDoDtos;
		public ObservableCollection<ToDoDto> ToDoDtos
		{
			set { _toDoDtos = value; RaisePropertyChanged(); }
			get { return _toDoDtos; }
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
				ToDoDtos.Add(new ToDoDto
				{
					Title = "Todo " + i,
					Content = i.ToString() + " is not completed."
				});
			}
		}

		private async void _CreateToDoList()
		{
			var todos = await _service.GetAllAsync(new QueryParameter()
			{
				PageIndex = 0,
				PageSize = 100
			});

			if (todos.Status)
			{
				ToDoDtos.Clear();
				foreach (var item in todos.Result.Items)
				{
					ToDoDtos.Add(item);
				}
			}
		}
	}
}
