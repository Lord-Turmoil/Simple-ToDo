using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using SimpleToDo.Common.Models;
using SimpleToDo.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleToDo.ViewModels
{
	public class NavigationViewModel : BindableBase, INavigationAware
	{
		public NavigationViewModel(IContainerProvider provider)
		{
			_containerProvider = provider;
			_eventAggregator = _containerProvider.Resolve<IEventAggregator>();
		}

		private readonly IContainerProvider _containerProvider;
		public readonly IEventAggregator _eventAggregator;

		public virtual bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		public virtual void OnNavigatedFrom(NavigationContext navigationContext)
		{
			
		}

		public virtual void OnNavigatedTo(NavigationContext navigationContext)
		{
			
		}

		public void UpdateLoading(bool isOpen)
		{
			_eventAggregator.UpdateLoading(new UpdateModel()
			{
				IsOpen = isOpen
			});
		}
	}
}
