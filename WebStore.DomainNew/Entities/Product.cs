using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        //public string Manufacturer { get; set; }    

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; }
    }
}
