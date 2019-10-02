using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Domain1.Entities.Base.Interface;

namespace WebStore.Domain1.Entities.Base
{
    public class NamedEntity:INamedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
