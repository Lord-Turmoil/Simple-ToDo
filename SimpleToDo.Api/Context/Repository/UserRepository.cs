using Microsoft.EntityFrameworkCore;

using SimpleToDo.Api.Context.UnitOfWork;
namespace SimpleToDo.Api.Context.Repository
{
	public class UserRepository : Repository<User>
	{
		public UserRepository(DbContext dbContext) : base(dbContext)
		{
		}
	}
}
