using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using SimpleToDo.Api.Context;
using SimpleToDo.Shared;
using SimpleToDo.Shared.Dtos;
using SimpleToDo.Shared.Parameters;
using System.Reflection.Metadata.Ecma335;

namespace SimpleToDo.Api.Service
{
	public class ToDoService : EntityService<ToDo, ToDoDto>
	{
		public ToDoService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
		{
		}

		public override async Task<ApiResponse> GetAllAsync(QueryParameter parameter)
		{
			try
			{
				var repo = _unitOfWork.GetRepository<ToDo>();
				var entities = await repo.GetPagedListAsync(
					predicate: x => string.IsNullOrWhiteSpace(parameter.Search) ||
						x.Title.Contains(parameter.Search) || x.Content.Contains(parameter.Search),
					pageSize: parameter.PageSize,
					pageIndex: parameter.PageIndex,
					orderBy: result => result.OrderByDescending(x => x.CreatedTime));

				return new ApiResponse(entities);
			}
			catch (Exception ex)
			{
				return new ApiResponse(ex.Message);
			}
		}

		protected override void _UpdateEntity(ToDo entity, ToDo mappedEntity)
		{
			entity.Title = mappedEntity.Title;
			entity.Content = mappedEntity.Content;
			entity.Status = mappedEntity.Status;
			entity.UpdatedTime = DateTime.Now;
		}
	}
}
