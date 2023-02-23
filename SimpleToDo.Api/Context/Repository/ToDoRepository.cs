using Microsoft.EntityFrameworkCore;
using SimpleToDo.Api.Context.UnitOfWork;

namespace SimpleToDo.Api.Context.Repository
{
	public class ToDoRepository : Repository<ToDo>
	{
		public ToDoRepository(DbContext dbContext) : base(dbContext)
		{
		}
	}
}
