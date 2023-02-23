using Microsoft.EntityFrameworkCore;

namespace SimpleToDo.Api.Context.Repository
{
	public class UserRepository : Repository<User>, IRepository<User>
	{
		public UserRepository(DbContext dbContext) : base(dbContext)
		{
		}
	}
}
