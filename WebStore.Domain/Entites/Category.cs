using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Domain.Entites.Base;
using WebStore.Domain.Entites.Base.Interfaces;

namespace WebStore.Domain.Entites
{
    public class Category:NameEntity,IOrderedEntity
    {
        /// <summary>
        /// Родительская категория (при наличии)
        /// </summary>
        public int? ParentId { get; set; }
        public int Order { get; set; }
    }
}
