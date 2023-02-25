using Microsoft.AspNetCore.Mvc;
using SimpleToDo.Api.Service;

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
		public async Task<ApiResponse> GetAll() => await _service.GetAllAsync();

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
