using Microsoft.Ajax.Utilities;
using MovieRentalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MovieRentalApp.ViewModels;

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
            var customers = _context.Customers.Include(m => m.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult CustomerForm()
        {
            var viewmodel = new CustomerViewModel
            {
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View(viewmodel);
        }
    }
}