﻿using Microsoft.EntityFrameworkCore;

namespace SimpleToDo.Api.Context.Repository
{
	public class MemoRepository : Repository<Memo>, IRepository<Memo>
	{
		public MemoRepository(DbContext dbContext) : base(dbContext)
		{
		}
	}
}
