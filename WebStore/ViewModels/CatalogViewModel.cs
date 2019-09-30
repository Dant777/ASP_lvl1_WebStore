using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.ViewModels
{
    public class CatalogViewModel
    {
        /// <summary>
        /// Секция, к которой принадлежит товар
        /// </summary>
        public int? CategoryId { get; set; }

        /// <summary>
        /// Бренд товара
        /// </summary>
        public int? BrandId { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; }

    }
}
