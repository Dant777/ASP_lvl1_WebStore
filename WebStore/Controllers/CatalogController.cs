using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain.Filters;
using WebStore.Infrastructure.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Controllers
{

    public class CatalogController : Controller
    {
        private readonly IProductService _productService;
        public CatalogController(IProductService productService)
        {
            
        }
        public IActionResult Shop(int? cartegoryId, int? brandId)
        {
            var products = _productService.GetProducts(new ProductFilter { BrandId = brandId, CategoryId = cartegoryId });

            var model = new CatalogViewModel()
            {
                BrandId = brandId,
                CategoryId = cartegoryId,
                Products = products.Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    ImageUrl = p.ImageUrl,
                    Name = p.Name,
                    Order = p.Order,
                    Price = p.Price
                }).OrderBy(p => p.Order).ToList()
            };

            return View(model);
        }

        public IActionResult ProductDetaling()
        {
            return View();
        }
    }
}