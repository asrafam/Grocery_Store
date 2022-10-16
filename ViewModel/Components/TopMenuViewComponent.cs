using Grocery_Store.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grocery_Store.Context;

namespace Grocery_Store.ViewModel.Components
{
    public class TopMenuViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var model = _context.MenuItem.ToList();
            //return await Task.FromResult((IViewComponentResult)View("Default", model));
            List<MenuItemVM> model = new List<MenuItemVM>()
            {
                new MenuItemVM()
                {
                    Title = "ProductList", Url = "~/Product/ProductList"
                },
                new MenuItemVM()
                {
                    Title = "AddProduct", Url = "~/Product/CreateProduct"
                },
                new MenuItemVM()
                {
                    Title = "Browser", Url = "https://google.com", OpenInNewWindow = true
                }
            };
            
            return View("Default", model);
        }
    }
}
    