using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using SimpleToDo.Api.Context;
using SimpleToDo.Shared.Dtos;

namespace SimpleToDo.Api.Service
{
	public class ToDoService : IToDoService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public ToDoService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<ApiResponse> AddAsync(ToDoDto model)
		{
			try
			{
				var todo = _mapper.Map<ToDo>(model);
				await _unitOfWork.GetRepository<ToDo>().InsertAsync(todo);
				if (await _unitOfWork.SaveChangesAsync() > 0)
					return new ApiResponse(model);
				return new ApiResponse("Failed to add ToDo");
			}
			catch (Exception ex)
			{
				return new ApiResponse(ex.Message);
			}
		}

		public async Task<ApiResponse> DeleteAllAsync()
		{
			try
			{
				var repo = _unitOfWork.GetRepository<ToDo>();
				var todos = await repo.GetAllAsync();
				repo.Delete(todos);
				if (await _unitOfWork.SaveChangesAsync() > 0)
					return new ApiResponse("All ToDos are deleted", true);
				return new ApiResponse("Failed to delete all ToDos");
			}
			catch (Exception ex)
			{
				return new ApiResponse(ex.Message);
			}
		}

		public async Task<ApiResponse> DeleteAsync(int id)
		{
			try
			{
				var repo = _unitOfWork.GetRepository<ToDo>();
				var todo = await repo.GetFirstOrDefaultAsync(predicate: x => x.ID.Equals(id));
				repo.Delete(todo);
				if (await _unitOfWork.SaveChangesAsync() > 0)
					return new ApiResponse("ToDo deleted", true);
				return new ApiResponse("Failed to delete ToDo");
			}
			catch (Exception ex)
			{
				return new ApiResponse(ex.Message);
			}
		}

		public async Task<ApiResponse> GetAllAsync()
		{
			try
			{
				var todos = await _unitOfWork.GetRepository<ToDo>().GetAllAsync();
				return new ApiResponse(todos);
			}
			catch (Exception ex)
			{
				return new ApiResponse(ex.Message);
			}
		}

		public async Task<ApiResponse> GetAsync(int id)
		{
			try
			{
				var todo = await _unitOfWork.GetRepository<ToDo>()
					.GetFirstOrDefaultAsync(predicate: x => x.ID.Equals(id));
				return new ApiResponse(todo);
			}
			catch (Exception ex)
			{
				return new ApiResponse(ex.Message);
			}
		}

		public async Task<ApiResponse> UpdateAsync(ToDoDto model)
		{
			try
			{
				var dbTodo = _mapper.Map<ToDo>(model);
				var repo = _unitOfWork.GetRepository<ToDo>();
				var todo = await repo.GetFirstOrDefaultAsync(
					predicate: x => x.ID.Equals(dbTodo.ID));

				todo.Title = dbTodo.Title;
				todo.Content = dbTodo.Content;
				todo.UpdatedTime = DateTime.Now;
				repo.Update(todo);

				if (await _unitOfWork.SaveChangesAsync() > 0)
					return new ApiResponse(todo);
				return new ApiResponse("Failed to update ToDo");
			}
			catch (Exception ex)
			{
				return new ApiResponse(ex.Message);
			}
		}
	}
}
