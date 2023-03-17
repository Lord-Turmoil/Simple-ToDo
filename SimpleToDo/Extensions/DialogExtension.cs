using Prism.Events;
using SimpleToDo.Common.Events;
using SimpleToDo.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * For 'this' keyword in parameter, it means extension method.
 * More information, please refer to:
 * https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods
 */
namespace SimpleToDo.Extensions
{
	public static class DialogExtension
	{
		public static void UpdateLoading(this IEventAggregator aggregator, UpdateModel model)
		{
			aggregator.GetEvent<UpdateLoadingEvent>().Publish(model);
		}


		public static void Register(this IEventAggregator aggregator, Action<UpdateModel> action)
		{
			aggregator.GetEvent<UpdateLoadingEvent>().Subscribe(action);
		}
	}
}
