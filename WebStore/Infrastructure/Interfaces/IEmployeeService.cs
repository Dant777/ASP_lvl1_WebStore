using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.ViewModels;

namespace WebStore.Infrastructure.Interfaces
{
    public interface IEmployeeService
    {
        /// <summary>
        /// Получение списка сотрудников
        /// </summary>
        /// <returns></returns>
        IEnumerable<EmployeeView> GetAll();

        /// <summary>
        /// Получение сотрудника по Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        EmployeeView GetById(int id);

        /// <summary>
        /// Сохранить изменения
        /// </summary>
        void Commit();

        /// <summary>
        /// Добавить новго сотрудника
        /// </summary>
        /// <param name="model"></param>
       
        void AddNew(EmployeeView model);
        /// <summary>
        /// Удаление сотрудника из списка по Id
        /// </summary>
        /// <param name="id">Id</param>
        void Delete(int id);
    }
}
