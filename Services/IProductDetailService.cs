using Grocery_Store.Context;
using Grocery_Store.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grocery_Store.Services
{
    public interface IProductDetailService
    {
        Task<IEnumerable<Product>> GetAllProductDetails();
        Task<bool> CreateProductDetails(Product model);
    }
}
