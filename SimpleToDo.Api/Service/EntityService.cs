using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using SimpleToDo.Api.Context;
using SimpleToDo.Shared.Dtos;
using SimpleToDo.Shared.Parameters;

namespace SimpleToDo.Api.Service
{
	public abstract class EntityService<TEntity, TEntityDto> : IEntityService<TEntityDto> where TEntity : BaseEntity where TEntityDto : BaseDto
	{
		protected readonly IUnitOfWork _unitOfWork;
		protected readonly IMapper _mapper;

		public EntityService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<ApiResponse> AddAsync(TEntityDto model)
		{
			try
			{
				var entity = _mapper.Map<TEntity>(model);
				entity.CreatedTime = entity.UpdatedTime = DateTime.Now;
				await _unitOfWork.GetRepository<TEntity>().InsertAsync(entity);
				if (await _unitOfWork.SaveChangesAsync() > 0)
					return new ApiResponse(model);
				return new ApiResponse("Failed to add entity");
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
				var repo = _unitOfWork.GetRepository<TEntity>();
				var entities = await repo.GetAllAsync();
				repo.Delete(entities);
				if (await _unitOfWork.SaveChangesAsync() > 0)
					return new ApiResponse("All Entities are deleted", true);
				return new ApiResponse("Failed to delete all entities");
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
				var repo = _unitOfWork.GetRepository<TEntity>();
				var entity = await repo.GetFirstOrDefaultAsync(predicate: x => x.ID.Equals(id));
				repo.Delete(entity);
				if (await _unitOfWork.SaveChangesAsync() > 0)
					return new ApiResponse("Entity deleted", true);
				return new ApiResponse("Failed to delete entity");
			}
			catch (Exception ex)
			{
				return new ApiResponse(ex.Message);
			}
		}

		// LINQ cannot translate template virtual function...
		public abstract Task<ApiResponse> GetAllAsync(QueryParameter parameter);

		public async Task<ApiResponse> GetAsync(int id)
		{
			try
			{
				var repo = _unitOfWork.GetRepository<TEntity>();
				var entity = await repo.GetFirstOrDefaultAsync(predicate: x => x.ID.Equals(id));
				return new ApiResponse(entity);
			}
			catch (Exception ex)
			{
				return new ApiResponse(ex.Message);
			}
		}

		public async Task<ApiResponse> UpdateAsync(TEntityDto model)
		{
			try
			{
				var mappedEntity = _mapper.Map<TEntity>(model);
				var repo = _unitOfWork.GetRepository<TEntity>();
				var entity = await repo.GetFirstOrDefaultAsync(predicate: x => x.ID.Equals(mappedEntity.ID));

				// Repository may not contain specified data!
				if (entity == null)
					return new ApiResponse("Specified Entity doesn't exist");

				_UpdateEntity(entity, mappedEntity);
				repo.Update(entity);

				if (await _unitOfWork.SaveChangesAsync() > 0)
					return new ApiResponse(entity);
				return new ApiResponse("Failed to update Entity");
			}
			catch (Exception ex)
			{
				return new ApiResponse(ex.Message);
			}
		}
		
		protected abstract void _UpdateEntity(TEntity entity, TEntity dbEntity);
	}
}
