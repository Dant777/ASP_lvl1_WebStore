using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebStore.Domain1.Entities.Base;
using WebStore.Domain1.Entities.Base.Interface;

namespace WebStore.Domain1.Entities
{
    [Table("Category")]
    public class Category : NamedEntity,IOrderedEntity
    {
        public int? ParentId { get; set; }
        public int Order { get; set; }
        [ForeignKey("ParentId")]
        public virtual  Category ParentCategory { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
