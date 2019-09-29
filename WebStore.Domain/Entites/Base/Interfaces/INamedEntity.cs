using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.Domain.Entites.Base.Interfaces
{
    public interface INamedEntity:IBaseEntity
    {
        string Name { get; set; }
    }
}
