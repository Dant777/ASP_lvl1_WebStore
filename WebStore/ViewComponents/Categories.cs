using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Infrastructure.Interfaces;
using WebStore.ViewModels;

namespace WebStore.ViewComponents
{
    //[ViewComponent(Name = "Cats")]
    public class Categories : ViewComponent
    {
        private readonly IProductService _productService;

        public Categories(IProductService productData)
        {
            _productService = productData;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var Categorys = GetCategorys();
            return View(Categorys);
        }
        private List<CategoryViewModel> GetCategorys()
        {
            var categories = _productService.GetCategories();
            var parentCategories = categories.Where(p => !p.ParentId.HasValue == null).ToArray();
            var parentCategorys = new List<CategoryViewModel>();
            foreach (var parentCategory in parentCategories)
            {
                parentCategorys.Add(new CategoryViewModel()
                {
                    Id = parentCategory.Id,
                    Name = parentCategory.Name,
                    Order = parentCategory.Order,
                    ParentCategories = null
                });
            }
            foreach (var CategoryViewModel in parentCategorys)
            {
                var childCategories = categories
                    .Where(c => c.ParentId == CategoryViewModel.Id);
                foreach (var childCategory in childCategories)
                {
                    CategoryViewModel.ChildCategories.Add(new CategoryViewModel()
                    {
                        Id = childCategory.Id,
                        Name = childCategory.Name,
                        Order = childCategory.Order,
                        ParentCategories = CategoryViewModel
                    });
                }
                CategoryViewModel.ChildCategories = CategoryViewModel
                    .ChildCategories
                    .OrderBy(c => c.Order)
                    .ToList();
            }
            parentCategorys = parentCategorys.OrderBy(c => c.Order).ToList();
            return parentCategorys;
        }

    }

}
