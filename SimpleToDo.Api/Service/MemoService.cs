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

		protected override void UpdateEntity(Memo entity, Memo dbEntity)
		{
			entity.Title = dbEntity.Title;
			entity.Content = dbEntity.Content;
			entity.UpdatedTime = DateTime.Now;
		}
	}
}
