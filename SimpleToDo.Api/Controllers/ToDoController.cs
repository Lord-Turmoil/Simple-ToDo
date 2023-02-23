using Microsoft.AspNetCore.Mvc;
using SimpleToDo.Api.Context;
using SimpleToDo.Api.Service;

namespace SimpleToDo.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]/[action]")]
	public class ToDoController : ControllerBase
	{
		private readonly IToDoService _service;

		public ToDoController(IToDoService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<ApiResponse> Get(int id) => await _service.GetAsync(id);

		[HttpGet]
		public async Task<ApiResponse> GetAll() => await _service.GetAllAsync();

		[HttpPost]
		public async Task<ApiResponse> Add([FromBody] ToDo model) => await _service.AddAsync(model);

		[HttpDelete]
		public async Task<ApiResponse> Delete(int id) => await _service.DeleteAsync(id);

		[HttpPost]
		public async Task<ApiResponse> Update([FromBody] ToDo model) => await _service.UpdateAsync(model);
	}
}
