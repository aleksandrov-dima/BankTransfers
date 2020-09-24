using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;

namespace BankTransfers.Controllers
{
    public class CustomPopUpEditorController : Controller
    {
        public static List<Person> persons = new List<Person>();

        static CustomPopUpEditorController()
        {
            persons.Add(new Person { PersonID = 1, Name = "John", BirthDate = new DateTime(1968, 6, 26) });
            persons.Add(new Person { PersonID = 2, Name = "Sara", BirthDate = new DateTime(1974, 9, 13) });
        }

        public ActionResult CustomPopUpEditor()
        {
            ViewBag.Message = "Modify this template to kick-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult GetPersons([DataSourceRequest] DataSourceRequest dsRequest)
        {
            var result = persons.ToDataSourceResult(dsRequest);
            return Json(result);
        }

        public ActionResult UpdatePerson([DataSourceRequest] DataSourceRequest dsRequest, Person person)
        {
            return Json(ModelState.ToDataSourceResult());
        }

    }


    public class Person
    {
        public int PersonID { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}