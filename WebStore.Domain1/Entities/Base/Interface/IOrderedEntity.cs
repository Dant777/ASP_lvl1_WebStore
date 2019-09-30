using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.Domain1.Entities.Base.Interface
{
    public interface IOrderedEntity
    {
        /// <summary>
        /// Порядок
        /// </summary>
        int Order { get; set; }
    }
}
