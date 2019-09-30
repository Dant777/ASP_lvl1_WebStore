using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Infrastructure.Interfaces;
using WebStore.ViewModels;

namespace WebStore.ViewComponents
{
    public class Categories:ViewComponent
    {
        private readonly IProductService _productService;

        public Categories(IProductService productData)
        {
            _productService = productData;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var Categories = GetCategories();
            return View(Categories);
        }
        private List<CategoryViewModel> GetCategories()
        {
            var categories = _productService.GetCategories();
            var parentCategories = categories.Where(p => !p.ParentId.HasValue).ToArray();
            var parentSections = new List<CategoryViewModel>();
            foreach (var parentCategory in parentCategories)
            {
                parentSections.Add(new CategoryViewModel()
                {
                    Id = parentCategory.Id,
                    Name = parentCategory.Name,
                    Order = parentCategory.Order,
                    ParentCategory = null
                });
            }
            foreach (var CategoryViewModel in parentSections)
            {
                var childCategories = categories
                    .Where(c => c.ParentId == CategoryViewModel.Id);
                foreach (var childCategory in childCategories)
                {
                    CategoryViewModel.ChildCategory.Add(new CategoryViewModel()
                    {
                        Id = childCategory.Id,
                        Name = childCategory.Name,
                        Order = childCategory.Order,
                        ParentCategory = CategoryViewModel
                    });
                }
                CategoryViewModel.ChildCategory = CategoryViewModel
                    .ChildCategory
                    .OrderBy(c => c.Order)
                    .ToList();
            }
            parentSections = parentSections.OrderBy(c => c.Order).ToList();
            return parentSections;
        }


    }
}
