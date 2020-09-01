﻿using MovieRentalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using MovieRentalApp.Dtos;
using AutoMapper;

namespace MovieRentalApp.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: api/Customers
        public IHttpActionResult GetCustomers()
        {
            var customerDtos = _context.Customers
                .Include(c => c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerDtos);
        }

        // GET: api/Customers/5
        public IHttpActionResult GetCustomer(int id)
        {          
            var customer = _context.Customers.Include(m => m.MembershipType).SingleOrDefault(c =>c.Id==id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            var customerDto = Mapper.Map<Customer,CustomerDto>(customer);
            return Ok(customerDto);
        }

        [HttpPost]
        // POST: api/Customers
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customer = Mapper.Map<CustomerDto,Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri+"/"+customer.Id),customerDto);
        }

        [HttpPut]
        // PUT: api/Customers/5
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id==id);
            if (customerInDb==null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(customerDto,customerInDb);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        // DELETE: api/Customers/5
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
