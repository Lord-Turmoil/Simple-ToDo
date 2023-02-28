using Microsoft.AspNetCore.Mvc;
using SimpleToDo.Api.Service;
using SimpleToDo.Shared;
using SimpleToDo.Shared.Parameters;

namespace SimpleToDo.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]/[action]")]
	public class EntityController<TEntityDto> : ControllerBase
	{
		protected readonly IEntityService<TEntityDto> _service;

		public EntityController(IEntityService<TEntityDto> service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<ApiResponse> Get(int id) => await _service.GetAsync(id);

		[HttpGet]
		public async Task<ApiResponse> GetAll([FromQuery] QueryParameter parameter) => await _service.GetAllAsync(parameter);

		[HttpPost]
		public async Task<ApiResponse> Add([FromBody] TEntityDto model) => await _service.AddAsync(model);

		[HttpPost]
		public async Task<ApiResponse> Update([FromBody] TEntityDto model) => await _service.UpdateAsync(model);

		[HttpDelete]
		public async Task<ApiResponse> Delete(int id) => await _service.DeleteAsync(id);

		[HttpDelete]
		public async Task<ApiResponse> DeleteAll() => await _service.DeleteAllAsync();
	}
}
