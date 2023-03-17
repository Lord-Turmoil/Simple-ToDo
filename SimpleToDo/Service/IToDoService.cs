using SimpleToDo.Common.Models;
using SimpleToDo.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleToDo.Service
{
	public interface IToDoService : IBaseService<ToDoDto>
	{
	}
}
