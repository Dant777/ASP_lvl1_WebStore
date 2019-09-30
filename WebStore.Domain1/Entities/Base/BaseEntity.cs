using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Domain1.Entities.Base.Interface;

namespace WebStore.Domain1.Entities.Base
{
    public class BaseEntity:IBaseEntity
    {
        public int Id { get; set; }
    }
}
