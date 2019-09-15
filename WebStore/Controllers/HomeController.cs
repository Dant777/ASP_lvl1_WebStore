﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly List<EmployeeView> _employee = new List<EmployeeView>
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

            }
        };
        // GET: Home
        public ActionResult Index()
        {
            
            return View(_employee);
        }

        public ActionResult Details(int id)
        {

            return View(_employee.FirstOrDefault(x => x.Id == id));
        }
    }
}