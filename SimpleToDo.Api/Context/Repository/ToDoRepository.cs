using Arch.EntityFrameworkCore.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace SimpleToDo.Api.Context.Repository
{
	public class ToDoRepository : Repository<ToDo>
	{
		public ToDoRepository(DbContext dbContext) : base(dbContext)
		{
		}
	}
}
