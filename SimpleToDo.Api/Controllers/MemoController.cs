using SimpleToDo.Api.Service;
using SimpleToDo.Shared.Dtos;

namespace SimpleToDo.Api.Controllers
{
	public class MemoController : EntityController<MemoDto>
	{
		public MemoController(IEntityService<MemoDto> service) : base(service)
		{
		}
	}
}
