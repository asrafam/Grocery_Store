using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Grocery_Store.Entity
{
    public class Product
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public int Qty { get; set; }

        public string FileName { get; set; }

        public string Category { get; set; }
      
    }
  
}
