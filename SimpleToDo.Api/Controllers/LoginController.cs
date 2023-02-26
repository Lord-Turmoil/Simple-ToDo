using Microsoft.AspNetCore.Mvc;
using SimpleToDo.Api.Service;
using SimpleToDo.Shared.Dtos;

namespace SimpleToDo.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]/[action]")]
	public class LoginController : ControllerBase
	{
		private readonly ILoginService _service;

		public LoginController(ILoginService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<ApiResponse> Login(string username, string password) => await _service.LoginAsync(username, password);

		[HttpPost]
		public async Task<ApiResponse> Register([FromBody] UserDto model) => await _service.Register(model);
	}
}
