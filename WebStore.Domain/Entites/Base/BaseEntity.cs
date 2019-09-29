using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Domain.Entites.Base.Interfaces;

namespace WebStore.Domain.Entites.Base
{
    public class BaseEntity:IBaseEntity
    {
        public int Id { get; set; }
    }
}
