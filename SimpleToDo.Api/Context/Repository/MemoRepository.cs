using Arch.EntityFrameworkCore.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace SimpleToDo.Api.Context.Repository
{
	public class MemoRepository : Repository<Memo>
	{
		public MemoRepository(DbContext dbContext) : base(dbContext)
		{
		}
	}
}
