using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        List<Customer> _customers = new List<Customer>()
        {
            new Customer { Id = 0, Name = "John Smith"},
            new Customer { Id = 1, Name = "Mary Williams"},
            new Customer { Id = 2, Name = "Ryan Johnson"},
        };

        // GET: Customers
        public ActionResult Index()
        {

            var customersViewModel = new CustomersViewModel()
            {
                Items = _customers
            };

            return View(customersViewModel);
        }

        public ActionResult Details(int id)
        {
            var customer = _customers.SingleOrDefault(c => c.Id == id);
            if (customer != null)
                return View(customer);
            return HttpNotFound();
        }
    }
}