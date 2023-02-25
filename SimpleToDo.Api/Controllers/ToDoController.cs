using SimpleToDo.Api.Service;
using SimpleToDo.Shared.Dtos;

namespace SimpleToDo.Api.Controllers
{
	public class ToDoController : EntityController<ToDoDto>
	{
		public ToDoController(IEntityService<ToDoDto> service) : base(service)
		{
		}
	}
}
