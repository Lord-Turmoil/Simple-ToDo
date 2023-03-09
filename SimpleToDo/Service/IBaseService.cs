using SimpleToDo.Shared;
using SimpleToDo.Shared.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleToDo.Service
{
	public interface IBaseService<TEntity> where TEntity : class
	{
		Task<ApiResponse<TEntity>> AddAsync(TEntity entity);
		Task<ApiResponse<TEntity>> UpdateAsync(TEntity entity);
		Task<ApiResponse> DeleteAsync(int id);
		Task<ApiResponse> DeleteAllAsync();
		Task<ApiResponse<TEntity>> GetFirstOrDefaultAsync(int id);
		Task<ApiResponse<PagedList<TEntity>>> GetAllAsync(QueryParameter parameter);
	}
}
