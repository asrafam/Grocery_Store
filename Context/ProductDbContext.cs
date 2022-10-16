using Grocery_Store.ViewModel.Components;
using Grocery_Store.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grocery_Store.Context
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Product> Product { get; set; }
        
    }
}