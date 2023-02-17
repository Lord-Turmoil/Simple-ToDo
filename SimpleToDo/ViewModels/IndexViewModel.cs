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
	public class IndexViewModel : BindableBase
	{
		private ObservableCollection<TaskBar> _taskBars;
		public ObservableCollection<TaskBar> TaskBars
		{
			set { _taskBars = value; RaisePropertyChanged(); }
			get { return _taskBars; }
		}

		private ObservableCollection<ToDoDto> _toDoDtos;
		public ObservableCollection<ToDoDto> ToDoDtos
		{
			set { _toDoDtos = value; RaisePropertyChanged(); }
			get { return _toDoDtos; }
		}


		private ObservableCollection<MemoDto> _memoDtos;
		public ObservableCollection<MemoDto> MemoDtos
		{
			set { _memoDtos = value; RaisePropertyChanged(); }
			get { return _memoDtos; }
		}

		public IndexViewModel()
		{
			_taskBars = new ObservableCollection<TaskBar>();
			_CreateTaskBars();

			_toDoDtos = new ObservableCollection<ToDoDto>();
			_CreateDefaultToDos();
			_memoDtos = new ObservableCollection<MemoDto>();
			_CreateDefaultMemos();
		}

		private void _CreateTaskBars()
		{
			TaskBars.Add(new TaskBar("ClockFast", "Total", "9", "#FF0CA0FF", "ToDoView"));
			TaskBars.Add(new TaskBar("ClockCheckOutline", "Completed", "9", "#FF1ECA3A", "ToDoView"));
			TaskBars.Add(new TaskBar("ChartLineVariant", "Completion Rates", "100%", "#FF02C6DC", ""));
			TaskBars.Add(new TaskBar("PlaylistStar", "Memo", "3", "#FFFFA000", "MemoView"));
		}

		private void _CreateDefaultToDos()
		{
			for (int i = 1; i <= 5; i++)
				ToDoDtos.Add(new ToDoDto() { Title = "ToDo " + i, Content = i.ToString() });
		}

		private void _CreateDefaultMemos()
		{
			for (int i = 1; i <= 5; i++)
				MemoDtos.Add(new MemoDto() { Title = "Memo " + i, Content = "Remember " + i.ToString() });
		}
	}
}
