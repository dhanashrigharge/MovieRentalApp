using Microsoft.Ajax.Utilities;
using MovieRentalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MovieRentalApp.ViewModels;
using System.Web.Http.Results;

namespace MovieRentalApp.Controllers
{
   
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context ;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult ViewCustomers()
        {           
            return View();
        }

        public ActionResult CustomerForm()
        {
            var viewmodel = new CustomerViewModel
            {
                Customer=new Customer(),
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View(viewmodel);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewmodel = new CustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewmodel = new CustomerViewModel
                {
                    Customer= customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewmodel);
            }
            if (customer.Id == 0)           
                _context.Customers.Add(customer);        
            else
            {
                var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.DateOfBirth = customer.DateOfBirth;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                
            }
            _context.SaveChanges();
            return RedirectToAction("ViewCustomers", "Customers");
        }
    }
}