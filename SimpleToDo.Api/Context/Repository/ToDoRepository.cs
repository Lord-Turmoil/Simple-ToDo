using SimpleToDo.Api.Context.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace SimpleToDo.Api.Context.Repository
{
	public class ToDoRepository : Repository<ToDo>
	{
		/// <summary>
		/// Finally found this!
		/// </summary>
		/// <param name="dbContext">Not DbContext... :(</param>
		public ToDoRepository(SimpleToDoContext dbContext) : base(dbContext)
		{
		}
	}
}
