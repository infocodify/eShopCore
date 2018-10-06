using eShopCore2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopCore2.ViewModels
{
    public class AppViewModel
    {
        public string Title { get; set; }

        public List<Product> Products { get; set; }
    }
}
