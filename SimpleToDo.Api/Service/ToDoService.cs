using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using SimpleToDo.Api.Context;
using SimpleToDo.Shared.Dtos;
using System.Reflection.Metadata.Ecma335;

namespace SimpleToDo.Api.Service
{
	public class ToDoService : EntityService<ToDo, ToDoDto>
	{
		public ToDoService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
		{
		}

		public override async Task<ApiResponse> UpdateAsync(ToDoDto model)
		{
			try
			{
				var dbTodo = _mapper.Map<ToDo>(model);
				var repo = _unitOfWork.GetRepository<ToDo>();
				var todo = await repo.GetFirstOrDefaultAsync(predicate: x => x.ID.Equals(dbTodo.ID));

				// Repository may not contain specified data!
				if (todo == null)
					return new ApiResponse("Specified ToDo doesn't exist");

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
