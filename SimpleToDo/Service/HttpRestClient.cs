using Newtonsoft.Json;
using RestSharp;
using SimpleToDo.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleToDo.Service
{
	public class HttpRestClient
	{
		private readonly string _apiUrl;
		private readonly RestClient _client;

		public HttpRestClient(string apiUrl)
		{
			_apiUrl = apiUrl;
			var options = new RestClientOptions("")
			{
				MaxTimeout = -1
			};
			_client = new RestClient(options);
		}

		public async Task<ApiResponse> ExecuteAsync(BaseRequest request)
		{
			var restRequest = new RestRequest(_apiUrl + request.Route, request.Method);
			restRequest.AddHeader("ContentType", request.ContentType);

			if (request.Parameter != null)
				restRequest.AddParameter("param", JsonConvert.SerializeObject(request.Parameter));

			RestResponse response = await _client.ExecuteAsync(restRequest);
			
			return JsonConvert.DeserializeObject<ApiResponse>(response.Content);
		}

		public async Task<ApiResponse<TResult>> ExecuteAsync<TResult>(BaseRequest request) where TResult : class
		{
			var restRequest = new RestRequest(_apiUrl + request.Route, request.Method);
			restRequest.AddHeader("ContentType", request.ContentType);

			if (request.Parameter != null)
				restRequest.AddParameter("param", JsonConvert.SerializeObject(request.Parameter));

			RestResponse response = await _client.ExecuteAsync<TResult>(restRequest);
			
			return JsonConvert.DeserializeObject<ApiResponse<TResult>>(response.Content);
		}
	}
}
