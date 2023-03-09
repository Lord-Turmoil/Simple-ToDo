using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleToDo.Shared
{
	public class ApiResponse
	{
		public bool Status { get; set; }
		public string? Message { get; set; }
		public object? Result { get; set; }

		public ApiResponse(string message, bool status = false)
		{
			Status = status;
			Message = message;
			Result = null;
		}

		public ApiResponse(object result, bool status = true)
		{
			Status = status;
			Message = null;
			Result = result;
		}
	}

	public class ApiResponse<TResult> where TResult : class
	{
		public bool Status { get; set; }
		public string? Message { get; set; }
		public TResult? Result { get; set; }

		public ApiResponse() { }

		public ApiResponse(string message, bool status = false)
		{
			Status = status;
			Message = message;
			Result = null;
		}

		public ApiResponse(TResult result, bool status = true)
		{
			Status = status;
			Message = null;
			Result = result;
		}
	}
}

