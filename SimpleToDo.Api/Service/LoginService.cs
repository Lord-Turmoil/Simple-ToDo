using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using SimpleToDo.Api.Context;
using SimpleToDo.Shared.Dtos;
using System.Security.Principal;
using System;

namespace SimpleToDo.Api.Service
{
	public class LoginService : ILoginService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public LoginService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<ApiResponse> LoginAsync(string account, string password)
		{
			try
			{
				var user = await _unitOfWork.GetRepository<User>().GetFirstOrDefaultAsync(
					predicate: x => (x.Account.Equals(account) && x.Password.Equals(password)));
				if (user == null)
					return new ApiResponse("Sorry, your account and password did not match");
				return new ApiResponse(user);
			}
			catch (Exception ex)
			{
				return new ApiResponse("Failed to login: " + ex.Message);
			}
		}

		public async Task<ApiResponse> Register(UserDto model)
		{
			try
			{
				var mappedUser = _mapper.Map<User>(model);
				var repo = _unitOfWork.GetRepository<User>();
				var user = await repo.GetFirstOrDefaultAsync(
					predicate: x => x.Account.Equals(mappedUser.Account));
				if (user != null)
					return new ApiResponse($"Account {user.Account} already registered");

				mappedUser.CreatedTime = mappedUser.UpdatedTime = DateTime.Now;
				await repo.InsertAsync(mappedUser);

				if (await _unitOfWork.SaveChangesAsync() > 0)
					return new ApiResponse(mappedUser);
				return new ApiResponse("Failed to register");
			}
			catch (Exception ex)
			{
				return new ApiResponse("Failed to register: " + ex.Message);
			}
		}
	}
}
