using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Infrastructure.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Infrastructure.Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly List<EmployeeView> _employees;
        public EmployeeService()
        {
            _employees = new List<EmployeeView>
            {
                new EmployeeView
                {
                    Id = 1,
                    FirstName = "Ivan",
                    LastName = "LastName1",
                    Patronymic = "Patrom1",
                    Age = 22,
                    Position = "Teacher"

                },
                new EmployeeView
                {
                    Id = 2,
                    FirstName = "Alex",
                    LastName = "LastName2",
                    Patronymic = "Patrom2",
                    Age = 32,
                    Position = "Engineer"

                },
                new EmployeeView
                {
                    Id = 3,
                    FirstName = "Karl",
                    LastName = "LastName3",
                    Patronymic = "Patrom3",
                    Age = 32,
                    Position = "NONE"

                },
                new EmployeeView
                {
                    Id = 3,
                    FirstName = "Peter",
                    LastName = "LastName4",
                    Patronymic = "Patrom4",
                    Age = 32,
                    Position = "NONE"
                }
            };

        }
        public IEnumerable<EmployeeView> GetAll()
        {
            return _employees;
        }

        public EmployeeView GetById(int id)
        {
            return _employees.FirstOrDefault(x => x.Id == id);
        }

        public void Commit()
        {
            
        }

        public void AddNew(EmployeeView model)
        {
            model.Id = _employees.Max(e => e.Id) + 1;
            _employees.Add(model);
        }

        public void Delete(int id)
        {
            var emp = GetById(id);
            if (emp == null)
            {
                return;
            }

            _employees.Remove(emp);
        }
    }
}
