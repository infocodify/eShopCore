using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShopCore2.Models;
using eShopCore2.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eShopCore2.Controllers
{
    public class AppController : Controller
    {
        //local repository
        private readonly IProductRepository _productRepository;

        //Constructor, initialize the virtual object
        public AppController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var product = _productRepository.GetAllProducts().OrderBy(p => p.Name);

            var appViewModel = new AppViewModel
            {
                Title = "Welcome to eShop Core",
                Products = product.ToList()
            };

            return View(appViewModel);
        }

        public IActionResult Details(int id)
        {
            var product = _productRepository.GetProductById(id);
            if (product == null)
                return NotFound();

            return View(product);
        }
    }
}