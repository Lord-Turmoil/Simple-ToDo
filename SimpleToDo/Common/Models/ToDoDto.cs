﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleToDo.Common.Models
{
	/// <summary>
	/// Todo Data Transfer Object
	/// </summary>
	public class ToDoDto : BaseDto
	{
		public string? Title { get; set; }
		public string? Content { get; set; }
		public string? Status { get; set; }
    }
}
