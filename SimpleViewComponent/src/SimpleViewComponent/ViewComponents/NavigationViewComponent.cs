using System.Collections.Generic;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Mvc;

namespace SimpleViewComponent.ViewComponents
{
    [ViewComponent(Name = "Navigation")]
    public class NavigationViewComponent : ViewComponent
    {
        private IHostingEnvironment environment;

        public NavigationViewComponent(IHostingEnvironment environment)
        {
            this.environment = environment;
        }

        public IViewComponentResult Invoke()
        {
            var navigationItems = new List<ItemViewModel>()
            {
                new ItemViewModel("Home", "Index", "Home"),
                new ItemViewModel("Contact", "Contact", "Home"),
                new ItemViewModel("About", "About", "Home")
            };
            if (environment.IsDevelopment())
            {
                var debugItem = new ItemViewModel("Debug", "Debug", "Home");
                navigationItems.Add(debugItem);
            }
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
        public ItemViewModel(string link, string action, string controller)
        {
            ActionName = action;
            ControllerName = controller;
            LinkName = link;
        }
        public string ActionName { get; }
        public string ControllerName { get; }
        public string LinkName { get; }
    }
}
