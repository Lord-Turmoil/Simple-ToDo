using SimpleToDo.Api.Context;
using SimpleToDo.Api.Context.UnitOfWork;

namespace SimpleToDo.Api.Service
{
	public class ToDoService : IToDoService
	{
		private readonly IUnitOfWork _unitOfWork;

		public ToDoService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<ApiResponse> AddAsync(ToDo model)
		{
			try
			{
				await _unitOfWork.GetRepository<ToDo>().InsertAsync(model);
				if (await _unitOfWork.SaveChangesAsync() > 0)
					return new ApiResponse(model);
				return new ApiResponse("Failed to add ToDo");
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

		public async Task<ApiResponse> UpdateAsync(ToDo model)
		{
			try
			{
				var repo = _unitOfWork.GetRepository<ToDo>();
				var todo = await repo.GetFirstOrDefaultAsync(
					predicate: x => x.ID.Equals(model.ID));

				todo.Title = model.Title;
				todo.Content = model.Content;
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
