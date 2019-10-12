using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStore.Infrastructure.Interfaces;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    [Route("users")]
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        
        // GET: Home
        [Route("all")]
        [AllowAnonymous]
        public ActionResult Index()
        {
            //Получение списка всех сотрудников
            return View(_employeeService.GetAll());
        }
        [Route("{id}")]
        public ActionResult Details(int id)
        {

            return View(_employeeService.GetById(id));
        }

        [HttpGet]
        [Route("edit/{id?}")]
        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return View(new EmployeeView());

            EmployeeView model = _employeeService.GetById(id.Value);

            if (model == null)
                return NotFound();

            return View(model);

        }

        [HttpPost]
        [Route("edit/{id?}")]
        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(EmployeeView model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.Id > 0) // Если есть Id, то редактируем моель
            {
                var dbItem = _employeeService.GetById(model.Id);
                if (ReferenceEquals(dbItem, null))
                    return NotFound();
                dbItem.FirstName = model.FirstName;
                dbItem.LastName = model.LastName;
                dbItem.Age = model.Age;
                dbItem.Patronymic = model.Patronymic;
                dbItem.Position = model.Position;

            }
            else
            {
                _employeeService.AddNew(model);
            }
            _employeeService.Commit();

            return View(model);

        }

        [Route("delete/{id}")]
        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(int id)
        {
            _employeeService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}