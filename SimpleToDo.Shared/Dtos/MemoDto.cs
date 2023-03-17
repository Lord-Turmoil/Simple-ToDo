using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleToDo.Shared.Dtos
{
	public class MemoDto : BaseDto
	{
		private string _title;
		public string Title
		{
			get { return _title; }
			set { _title = value; RaisePropertyChanged(); }
		}

		private string _content;
		public string Content
		{
			get { return _content; }
			set { _content = value; RaisePropertyChanged(); }
		}

		private int _status;
		public int Status
		{
			get { return _status; }
			set { _status = value; RaisePropertyChanged(); }
		}
	}
}
