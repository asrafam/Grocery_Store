using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Grocery_Store.Context
{
    public class ProductModel
    {

        public ProductModel()
        {
            Result = new ProductVM();

        }
        [Key]


        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(24)]
        [Required]
        public string Name { get; set; }


       
        [Required]
        public int Price { get; set; }
        [Required]
        public int Qty { get; set; }
        
        public string Category { get; set; }

        public string FileName { get; set; }

        public ProductVM Result { get; set; }
    }

    public class ProductVM
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public int Qty { get; set; }

        public string FileName { get; set; }

        public string Category { get; set; }

    }
}