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

		public IndexViewModel()
		{
			_CreateTaskBars();
		}

		private void _CreateTaskBars()
		{
			TaskBars = new ObservableCollection<TaskBar>
			{
				new TaskBar("ClockFast", "Total", "9", "#FF0CA0FF", "ToDoView"),
				new TaskBar("ClockCheckOutline", "Completed", "9", "#FF1ECA3A", "ToDoView"),
				new TaskBar("ChartLineVariant", "Completion Rates", "100%", "#FF02C6DC", ""),
				new TaskBar("PlaylistStar", "Memo", "3", "#FFFFA000", "MemoView")
			};
		}
	}
}
