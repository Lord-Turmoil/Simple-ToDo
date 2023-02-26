using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleToDo.Shared.Dtos
{
	public class UserDto : BaseDto
	{
		private string _account;
		public string Account
		{
			get { return _account; }
			set { _account = value; RaisePropertyChanged(); }
		}

		private string _username;
		public string Username
		{
			get { return _username; }
			set { _username = value; RaisePropertyChanged(); }
		}

		private string _password;
		public string Password
		{
			get { return _password; }
			set { _password = value; RaisePropertyChanged(); }
		}
	}
}
