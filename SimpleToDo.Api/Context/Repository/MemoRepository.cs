using Microsoft.EntityFrameworkCore;
using SimpleToDo.Api.Context.UnitOfWork;

namespace SimpleToDo.Api.Context.Repository
{
	public class MemoRepository : Repository<Memo>
	{
		public MemoRepository(DbContext dbContext) : base(dbContext)
		{
		}
	}
}
