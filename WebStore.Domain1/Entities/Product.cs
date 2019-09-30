using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Domain1.Entities.Base;
using WebStore.Domain1.Entities.Base.Interface;

namespace WebStore.Domain1.Entities
{
    public class Product :NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
        /// <summary>
        /// Секция, к которой принадлежит товар
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Бренд товара
        /// </summary>
        public int? BrandId { get; set; }

        /// <summary>
        /// Ссылка на картинку
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price { get; set; }
    }
}
