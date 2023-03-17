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
	public class MemoViewModel : BindableBase
	{
		public MemoViewModel(IMemoService service)
		{
			_service = service;

			_memoDtos = new ObservableCollection<MemoDto>();
			// _CreateDefaultMemoList();
			_CreateMemoList();

			AddCommand = new DelegateCommand(_Add);
			IsRightDrawerOpen = false;
		}

		private readonly IMemoService _service;

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

		private async void _CreateMemoList()
		{
			var memos = await _service.GetAllAsync(new QueryParameter()
			{
				PageIndex = 0,
				PageSize = 100
			});

			if (memos.Status)
			{
				MemoDtos.Clear();
				foreach (var item in memos.Result.Items)
				{
					MemoDtos.Add(item);
				}
			}
		}
	}
}
