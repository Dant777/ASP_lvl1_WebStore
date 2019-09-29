using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Domain.Entites.Base.Interfaces;

namespace WebStore.Domain.Entites.Base
{
    public class NameEntity:INamedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
