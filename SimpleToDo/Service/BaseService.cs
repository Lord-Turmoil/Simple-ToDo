using SimpleToDo.Shared;
using SimpleToDo.Shared.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleToDo.Service
{
	public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
	{
		private readonly HttpRestClient _client;
		private readonly string _serviceName;

		public BaseService(HttpRestClient client, string serviceName)
		{
			_client = client;
			_serviceName = serviceName;
		}

		public async Task<ApiResponse<TEntity>> AddAsync(TEntity entity)
		{
			BaseRequest request = new BaseRequest();
			request.Method = RestSharp.Method.Post;
			request.Route = $"api/{_serviceName}/Add";
			request.Parameter = entity;

			return await _client.ExecuteAsync<TEntity>(request);
		}

		public async Task<ApiResponse> DeleteAsync(int id)
		{
			BaseRequest request = new BaseRequest();
			request.Method= RestSharp.Method.Delete;
			request.Route = $"api/{_serviceName}/Delete?id={id}";
			
			return await _client.ExecuteAsync(request);
		}

		private string _BuildGetAllRoute(QueryParameter parameter)
		{
			return new StringBuilder()
				.Append($"api/{_serviceName}/GetAll?")
				.Append($"pageIndex={parameter.PageIndex}")
				.Append($"pageSize={parameter.PageSize}")
				.Append($"search={parameter.Search}").ToString();
		}

		public async Task<ApiResponse<PagedList<TEntity>>> GetAllAsync(QueryParameter parameter)
		{
			BaseRequest request = new BaseRequest();
			request.Method = RestSharp.Method.Get;
			request.Route = _BuildGetAllRoute(parameter);

			return await _client.ExecuteAsync<PagedList<TEntity>>(request);
		}

		public async Task<ApiResponse<TEntity>> GetFirstOrDefaultAsync(int id)
		{
			BaseRequest request = new BaseRequest();
			request.Method = RestSharp.Method.Get;
			request.Route = $"api/{_serviceName}/Get?id={id}";

			return await _client.ExecuteAsync<TEntity>(request);
		}

		public async Task<ApiResponse<TEntity>> UpdateAsync(TEntity entity)
		{
			BaseRequest request = new BaseRequest();
			request.Method = RestSharp.Method.Post;
			request.Route = $"api/{_serviceName}/Update";
			request.Parameter = entity;

			return await _client.ExecuteAsync<TEntity>(request);
		}
	}
}
