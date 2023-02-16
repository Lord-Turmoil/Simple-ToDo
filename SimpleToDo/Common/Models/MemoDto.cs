using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleToDo.Common.Models
{
	public class MemoDto : BaseDto
	{
		public string? Title { get; set; }
		public string? Content { get; set; }
		public string? Status { get; set; }
	}
}
