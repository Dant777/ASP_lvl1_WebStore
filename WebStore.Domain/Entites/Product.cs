using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Domain.Entites.Base;
using WebStore.Domain.Entites.Base.Interfaces;

namespace WebStore.Domain.Entites
{
    public class Product:NameEntity, IOrderedEntity
    {
        public int Order { get; set; }
        public int CategoryId { get; set; }

        public int? BrandId { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
    }
}
