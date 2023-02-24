using Microsoft.AspNetCore.Mvc;
using SimpleToDo.Api.Context;
using SimpleToDo.Api.Service;
using SimpleToDo.Shared.Dtos;

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
		public async Task<ApiResponse> Add([FromBody] ToDoDto model) => await _service.AddAsync(model);

		[HttpPost]
		public async Task<ApiResponse> Update([FromBody] ToDoDto model) => await _service.UpdateAsync(model);

		[HttpDelete]
		public async Task<ApiResponse> Delete(int id) => await _service.DeleteAsync(id);

		[HttpDelete]
		public async Task<ApiResponse> DeleteAll() => await _service.DeleteAllAsync();
	}
}
