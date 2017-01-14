using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCSharpProject.Models;
using MVCCSharpProject.ViewModels;


namespace MVCCSharpProject.Controllers
{
    public class MainController : Controller
    {

        Repository _repository  = new Repository();


        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Customers customerForm)
        {
            if (ModelState.IsValid)
            {
                _repository.Create(customerForm);
                TempData["Success"] = "Seccussfully Saved";
            }
            return View();
        }

        public ActionResult CustomersList()
        {
            var customers = _repository.GetCustomers();
            return View(customers);
        }


        public ActionResult CustomersReport()
        {
            var customersReport = _repository.GetCustomerReport();
            return View(customersReport);
        }
    }
}