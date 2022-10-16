using Grocery_Store.Context;
using Grocery_Store.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grocery_Store.Services
{
    
    public class ProductDetailService : IProductDetailService
    {
        private readonly ProductDbContext _context;

        public ProductDetailService(ProductDbContext context)
        {
            _context = context;
        }

        //[Authorize(Policy = "writepolicy")]

        public async Task<IEnumerable<Product>> GetAllProductDetails()
        {
            List<Product> prodList = new List<Product>();
            var productQry = await _context.Product.ToListAsync();

            foreach (var prod in productQry)
            {
                prodList.Add(new Product
                {
                    Id = prod.Id,
                    Name = prod.Name,
                    Qty = prod.Qty,
                    Price = prod.Price,
                    FileName = prod.FileName,
                    Category = prod.Category


                });
            }
            return prodList.OrderByDescending(d => d.Id).ToList();
            //return prodList;
        }

        

        public async Task<bool> CreateProductDetails(Product model)
        {
                Product result = new Product();
                result.Id = model.Id;
                result.Name = model.Name;
                result.Price = model.Price;
                result.Qty = model.Qty;
                result.Category = model.Category;
                result.FileName = model.FileName;
                _context.Product.Add(result);
                _context.SaveChanges();
                return true;
            
        }
    }
}
