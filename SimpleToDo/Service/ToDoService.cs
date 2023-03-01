using SimpleToDo.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleToDo.Service
{
	public class ToDoService : BaseService<ToDoDto>, IToDoService
	{
		public ToDoService(HttpRestClient client) : base(client, "ToDo")
		{
		}
	}
}
