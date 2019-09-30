using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Domain1.Entities.Base;
using WebStore.Domain1.Entities.Base.Interface;

namespace WebStore.Domain1.Entities
{
    public class Brand:NamedEntity,IOrderedEntity
    {
        public int Order { get; set; }
    }
}
