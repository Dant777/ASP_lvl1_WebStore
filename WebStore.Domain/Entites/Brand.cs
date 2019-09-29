using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Domain.Entites.Base;
using WebStore.Domain.Entites.Base.Interfaces;

namespace WebStore.Domain.Entites
{
    public class Brand:NameEntity, IOrderedEntity
    {
        public int Order { get; set; }
    }
}
