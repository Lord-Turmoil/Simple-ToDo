using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SimpleToDo.Api.Context;
using SimpleToDo.Api.Context.Repository;
using SimpleToDo.Api.Context.UnitOfWork;
using SimpleToDo.Api.Service;

namespace SimpleToDo.Api
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<SimpleToDoContext>(option =>
			{
				option.UseSqlite(Configuration.GetConnectionString("ToDoConnection"));
			}).AddUnitOfWork<SimpleToDoContext>()
			.AddCustomRepository<ToDo, ToDoRepository>()
			.AddCustomRepository<Memo, MemoRepository>()
			.AddCustomRepository<User, UserRepository>();

			services.AddTransient<IToDoService, ToDoService>();

			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo() { Title = "SimpleToDo.Api", Version = "v1" });
			});
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
				app.UseDeveloperExceptionPage();

			app.UseSwagger();
			app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SimpleToDo.Api v1"));
			app.UseRouting();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
				endpoints.MapSwagger();
			});
		}
	}
}