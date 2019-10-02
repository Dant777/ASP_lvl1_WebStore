using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebStore.Domain1.Entities.Base;
using WebStore.Domain1.Entities.Base.Interface;

namespace WebStore.Domain1.Entities
{
    [Table("Brands")]
    public class Brand:NamedEntity,IOrderedEntity
    {
        public int Order { get; set; }
        public  virtual ICollection<Product> Products { get; set; }
    }
}
