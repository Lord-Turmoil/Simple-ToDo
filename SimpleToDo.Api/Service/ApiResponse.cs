namespace SimpleToDo.Api.Service
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
