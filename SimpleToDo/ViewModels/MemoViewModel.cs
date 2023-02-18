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
	public class MemoViewModel : BindableBase
	{
		private ObservableCollection<MemoDto> _memoDtos;
		public ObservableCollection<MemoDto> MemoDtos
		{
			set { _memoDtos = value; RaisePropertyChanged(); }
			get { return _memoDtos; }
		}

		public DelegateCommand AddCommand { get; private set; }
		private bool _isRightDrawerOpen;
		public bool IsRightDrawerOpen
		{
			set { _isRightDrawerOpen = value; RaisePropertyChanged(); }
			get { return _isRightDrawerOpen; }
		}

		public MemoViewModel()
		{
			_memoDtos = new ObservableCollection<MemoDto>();
			_CreateDefaultMemoList();
			AddCommand = new DelegateCommand(_Add);
			IsRightDrawerOpen = false;
		}

		private void _Add()
		{
			IsRightDrawerOpen = !IsRightDrawerOpen;
		}

		private void _CreateDefaultMemoList()
		{
			for (int i = 1; i <= 20; i++)
			{
				MemoDtos.Add(new MemoDto
				{
					Title = "Memo " + i,
					Content = i.ToString() + " is a memo."
				});
			}
		}
	}
}
