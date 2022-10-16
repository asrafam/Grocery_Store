using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Grocery_Store.ViewModel.Components
{
    public class MenuItemVM
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public bool OpenInNewWindow { get; set; }

    }


}
