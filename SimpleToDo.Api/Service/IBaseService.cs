namespace SimpleToDo.Api.Service
{
	public interface IBaseService<T>
	{
		Task<ApiResponse> GetAllAsync();
		Task<ApiResponse> GetAsync(int id);

		Task<ApiResponse> AddAsync(T model);
		Task<ApiResponse> UpdateAsync(T model);
		Task<ApiResponse> DeleteAsync(int id);
	}
}
