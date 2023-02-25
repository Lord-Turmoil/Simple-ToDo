namespace SimpleToDo.Api.Service
{
	public interface IBaseService<TEntityDto>
	{
		Task<ApiResponse> GetAllAsync();
		Task<ApiResponse> GetAsync(int id);

		Task<ApiResponse> AddAsync(TEntityDto model);
		Task<ApiResponse> DeleteAsync(int id);
		Task<ApiResponse> DeleteAllAsync();
		
		Task<ApiResponse> UpdateAsync(TEntityDto model);
	}
}
