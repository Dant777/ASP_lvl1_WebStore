using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain1.Entities.Base.Interface;

namespace WebStore.ViewModels
{
    public class CategoryViewModel:INamedEntity,IOrderedEntity
    {
        public CategoryViewModel()
        {
            ChildCategory = new List<CategoryViewModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public List<CategoryViewModel> ChildCategory { get; set; }
        public CategoryViewModel ParentCategory { get; set; }
    }
}
