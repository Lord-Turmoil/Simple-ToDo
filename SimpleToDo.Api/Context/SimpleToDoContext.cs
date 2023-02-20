using Microsoft.EntityFrameworkCore;

namespace SimpleToDo.Api.Context
{
	public class SimpleToDoContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<ToDo> ToDos { get; set; }
		public DbSet<Memo> Memos { get; set; }

		public SimpleToDoContext(DbContextOptions<SimpleToDoContext> options) : base(options)
		{
		}
	}
}
