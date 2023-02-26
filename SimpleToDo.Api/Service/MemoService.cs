using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using SimpleToDo.Api.Context;
using SimpleToDo.Shared.Dtos;

namespace SimpleToDo.Api.Service
{
	public class MemoService : EntityService<Memo, MemoDto>
	{
		public MemoService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
		{
		}

		protected override bool MatchSearch(Memo entity, string search)
		{
			return entity.Title.Contains(search) || entity.Content.Contains(search);
		}

		protected override void UpdateEntity(Memo entity, Memo mappedEntity)
		{
			entity.Title = mappedEntity.Title;
			entity.Content = mappedEntity.Content;
			entity.UpdatedTime = DateTime.Now;
		}
	}
}
