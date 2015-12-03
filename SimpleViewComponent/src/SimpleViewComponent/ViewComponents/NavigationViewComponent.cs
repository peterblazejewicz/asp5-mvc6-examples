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
				new ItemViewModel("Home", Url.RouteUrl(RouteNames.Home)),
				new ItemViewModel("Contact", Url.RouteUrl(RouteNames.Contact)),
				new ItemViewModel("About", Url.RouteUrl(RouteNames.About))
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
        public string TargetUrl { get; }

        public ItemViewModel(string name, string targetUrl)
        {
            Name = name;
            TargetUrl = targetUrl;
        }
    }
}
