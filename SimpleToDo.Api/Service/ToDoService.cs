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

		protected override void UpdateEntity(ToDo entity, ToDo dbEntity)
		{
			entity.Title = dbEntity.Title;
			entity.Content = dbEntity.Content;
			entity.Status = dbEntity.Status;
			entity.UpdatedTime = DateTime.Now;
		}
	}
}
