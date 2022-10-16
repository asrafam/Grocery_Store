using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Grocery_Store.Models;

using Grocery_Store.Entity;
using Grocery_Store.Context;
using Microsoft.EntityFrameworkCore;

namespace Grocery_Store.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Title"] = "Product Details Page";
            ViewData["Header"] = "Product Details";
            TempData["name"] = "Welcome to the grocery store";
            TempData["category"] = "We provide all sorts of grocery at your doorstep.";
            return View();
       
        }

        public IActionResult Contact()
        {
            return View();
        }

        
            //ProductModel modelVM = new ProductModel();
            //if (!ModelState.IsValid)

            //    //Product model empty
            //    modelVM.Name = "dummy";

            //    Product result = new Product();
            //    result.Id = 7;
            //    result.Name ="Brinjal";
            //    result.Price = 500;
            //    result.Qty = 7;
            //    result.Category = "Vegetables";

            //    return View(result);
            //    //return RedirectToAction("ProductList", "Product");
            //}
        

    }   

}

