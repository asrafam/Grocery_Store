using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Grocery_Store.Models;
using Grocery_Store.Context;
using Microsoft.EntityFrameworkCore;
using Grocery_Store.Entity;
using Grocery_Store.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace Grocery_Store.Controllers
{
    
    public class ProductController : Controller
    {
        private readonly ProductDbContext _context;
        private readonly IProductDetailService _detailService;

        public ProductController(ProductDbContext context, IProductDetailService detailService)
        {
            _context = context;
            _detailService = detailService;
        }

        [Authorize(Policy = "writepolicy")]
        [HttpGet]
        
        public IActionResult CreateProduct()
        {
                ViewBag.SuccessMessage = "";
                return View();
        }
        //[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(Product model)
        {
            try
            {
                //ProductModel modelVM = new ProductModel();
                if (!ModelState.IsValid)
                {
                    ViewBag.SuccessMessage = "false";
                    //return View(model);
                }
                else
                {
                    //Product model empty
                    //modelVM.Name = "dummy";

                    //Product result = new Product();
                    //result.Id = model.Id;
                    //result.Name = model.Name;
                    //result.Price = model.Price;
                    //result.Qty = model.Qty;
                    //result.Category = model.Category;
                    //_context.Product.Add(result);
                    //_context.SaveChanges();

                    //   modelVM.Result = result;
                    //List<Product> prodList = new List<Product>();
                    var productQry = await _context.Product.Where(x => x.Name == model.Name ).FirstOrDefaultAsync();
                    if (productQry != null)
                    {
                        ViewBag.ErrorMessage = "Record Already Exists";
                        return View();

                    }
                    else
                    {
                        var createProd = await _detailService.CreateProductDetails(model);
                        // ViewBag.SuccessMessage = "true";
                        return RedirectToAction("ProductList", "Product");
                    }
                    // return View();
                }
                return View();
            }
            catch (Exception ex)
            {
                return View("Error");
            }

            }
        [Authorize(Policy = "writepolicy")]
        public async Task<IActionResult> ProductList()
            {
                //List<Product> prodList = new List<Product>();

                //var productQry = await _context.Product.ToListAsync();

                //foreach (var prod in productQry)
                //{
                //    prodList.Add(new Product
                //    {
                //        Id = prod.Id,
                //        Name = prod.Name,
                //        Qty = prod.Qty,
                //        Price = prod.Price,
                //        Category = prod.Category

                //    });
                //}
                //return View(prodList.OrderByDescending(d => d.Id).ToList());
                return View(await _detailService.GetAllProductDetails());
            }


        //////////////////
        //Edit Product
        [Authorize(Policy = "writepolicy")]
        [HttpGet]
        public async Task<IActionResult> EditProduct(int id)
        {
            List<Product> prodList = new List<Product>();
            var productQry = await _context.Product.ToListAsync();
            var prod = productQry.Where(item => item.Id == id).FirstOrDefault();

            return View(prod);
        }
        [HttpPost]
        public async Task<IActionResult> EditProduct(Product product)
        {

            List<Product> prodList = new List<Product>();
            var productQry = await _context.Product.ToListAsync();
            var prod = productQry.Where(item => item.Id == product.Id).FirstOrDefault();
            prod.Name = product.Name;
            prod.Qty = product.Qty;
            prod.Price = product.Price;
            prod.Category = product.Category;
            prod.FileName = product.FileName;

            _context.Product.Update(prod);
            await _context.SaveChangesAsync();

            return View(prod);
        }

        ///////////////////////////////////////////////////////
        //Delete Product


        [Authorize(Policy = "writepolicy")]
        [HttpGet]

        public async Task<IActionResult> DelProduct(Product product)
        {
            try
            {
                List<Product> prodList = new List<Product>();
                var productQry = await _context.Product.ToListAsync();
                var prod = productQry.Where(item => item.Id == product.Id).FirstOrDefault();
                //prod.Name = product.Name;
                //prod.Qty = product.Qty;
                //prod.Price = product.Price;
                //prod.Category = product.Category;
                int test = int.Parse("test");


                return View(prod);
            }
            catch (Exception ex)
            {
                List<Product> prodList = new List<Product>();
                var productQry = await _context.Product.ToListAsync();
                var prod = productQry.Where(item => item.Id == product.Id).FirstOrDefault();
                ViewBag.ErrorMessage = "Please confirm you want to delete the product?";
                return View(prod);
            }
        }
        [HttpPost]
        public async Task<IActionResult> DelProduct(int id)
        {
            //Error Handling

            List<Product> prodList = new List<Product>();
            var productQry = await _context.Product.ToListAsync();
            var prod = productQry.Where(item => item.Id == id).FirstOrDefault();

            _context.Product.Remove(prod);
            await _context.SaveChangesAsync();

            //return View();
            return RedirectToAction("ProductList", "Product");


        }

        public async Task<IActionResult> Vegetables()
        {

            List<Product> prodList = new List<Product>();
            var productQry = await _context.Product.Where(x => x.Category == "vegetables").ToListAsync();

            foreach (var prod in productQry)
            {
                prodList.Add(new Product
                {
                    Id = prod.Id,
                    Name = prod.Name,
                    Qty = prod.Qty,
                    Price = prod.Price,
                    Category = prod.Category,
                    FileName = prod.FileName

                });
            }
            return View(prodList.OrderByDescending(d => d.Id).ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
