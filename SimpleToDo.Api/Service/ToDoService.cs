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

		protected override bool MatchSearch(ToDo entity, string search)
		{
			return entity.Title.Contains(search) || entity.Content.Contains(search);
		}

		protected override void UpdateEntity(ToDo entity, ToDo mappedEntity)
		{
			entity.Title = mappedEntity.Title;
			entity.Content = mappedEntity.Content;
			entity.Status = mappedEntity.Status;
			entity.UpdatedTime = DateTime.Now;
		}
	}
}
