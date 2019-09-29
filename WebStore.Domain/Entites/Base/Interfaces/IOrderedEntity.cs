using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.Domain.Entites.Base.Interfaces
{
    public interface IOrderedEntity
    {
        /// <summary>
        /// Порядок
        /// </summary>
        int Order { get; set; }
    }
}
