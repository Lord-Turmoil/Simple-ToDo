using SimpleToDo.Api.Context.UnitOfWork;
using AutoMapper;
using SimpleToDo.Api.Context;
using SimpleToDo.Shared;
using SimpleToDo.Shared.Dtos;
using SimpleToDo.Shared.Parameters;

namespace SimpleToDo.Api.Service
{
	public class MemoService : EntityService<Memo, MemoDto>
	{
		public MemoService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
		{
		}

		public override async Task<ApiResponse> GetAllAsync(QueryParameter parameter)
		{
			try
			{
				var repo = _unitOfWork.GetRepository<Memo>();
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

		protected override void _UpdateEntity(Memo entity, Memo mappedEntity)
		{
			entity.Title = mappedEntity.Title;
			entity.Content = mappedEntity.Content;
			entity.UpdatedTime = DateTime.Now;
		}
	}
}
