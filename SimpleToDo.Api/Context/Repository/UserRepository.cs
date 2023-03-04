using SimpleToDo.Api.Context.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace SimpleToDo.Api.Context.Repository
{
	public class UserRepository : Repository<User>
	{
		public UserRepository(SimpleToDoContext dbContext) : base(dbContext)
		{
		}
	}
}
