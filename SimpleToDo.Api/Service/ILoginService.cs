using SimpleToDo.Shared;
using SimpleToDo.Shared.Dtos;

namespace SimpleToDo.Api.Service
{
	public interface ILoginService
	{
		Task<ApiResponse> LoginAsync(string account, string password);

		Task<ApiResponse> Register(UserDto user);
	}
}
