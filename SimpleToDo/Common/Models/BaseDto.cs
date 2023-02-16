using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleToDo.Common.Models
{
	public class BaseDto
	{
		public int ID { get; set; }
		public DateTime CreatedTime { get; set; }
		public DateTime UpdatedTime { get; set; }
	}
}
