using System.Collections.Generic;
using Microsoft.AspNet.Mvc;

namespace SimpleViewComponent.ViewComponents
{
    [ViewComponent(Name = "Navigation")]
    public class NavigationViewComponent: ViewComponent
    {
		public IViewComponentResult Invoke()
		{
			var navigationItems = new[]
			{
				new ItemViewModel("Home", "Index", "Home"),
				new ItemViewModel("Contact", "Contact", "Home"),
				new ItemViewModel("About", "About", "Home")
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
        public ItemViewModel(string link, string action, string controller) {
            ActionName = action;
            ControllerName = controller;
            LinkName = link;
        }
        public string ActionName { get; }
        public string ControllerName { get; }
        public string LinkName { get; }
    }
}
