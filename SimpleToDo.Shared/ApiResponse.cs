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
		public object? Result { get; set; }
		public string? Message { get; set; }

		public ApiResponse(string message, bool status = false)
		{
			Status = status;
			Result = null;
			Message = message;
		}

		public ApiResponse(object result, bool status = true)
		{
			Status = status;
			Result = result;
			Message = null;
		}
	}
}

