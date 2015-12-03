using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using SimpleViewComponent.Data;

namespace SimpleViewComponent.ViewComponents
{
    [ViewComponent(Name = "Navigation")]
    public class NavigationViewComponent: ViewComponent
    {
		public IViewComponentResult Invoke()
		{
			var navigationItems = new[]
			{
				new ItemViewModel("Home", "Home", "Index"),
				new ItemViewModel("Contact", "Home", "Contact"),
				new ItemViewModel("About", "Home", "About")
			};
		
			var viewModel = new ViewModel(navigationItems);
		
			return View(viewModel);
		}
    }
	
	public class ViewModel
    {
        public IList<ItemViewModel> NavigationItems { get; }

        public ViewModel(IList<ItemViewModel> navigationItems)
        {
            NavigationItems = navigationItems;
        }
    }

    public class ItemViewModel
    {
        public string Name { get; }
        public string Action { get; }
        
        public string Controller { get; }

        public ItemViewModel(string name, string controller, string action)
        {
            Name = name;
            Controller = controller;
            Action = action;
        }
    }
}
