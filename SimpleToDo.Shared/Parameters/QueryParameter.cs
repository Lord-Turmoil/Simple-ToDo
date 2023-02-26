using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleToDo.Shared.Parameters
{
	public class QueryParameter
	{
		public int PageIndex { get; set; } = 0;
		public int PageSize { get; set; } = 20;

		public string? Search { get; set; }
	}
}
