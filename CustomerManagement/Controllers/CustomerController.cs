using CustomerManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;

namespace CustomerManagement.Controllers
{
    public class CustomerController : Controller

    {
        private readonly CustomerDBContext dBContext;

        public CustomerController(CustomerDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        // GET: CustomersController
        public async Task<ActionResult> Index()
        {

            var customerlist = await dBContext.Customers.ToListAsync();
            return View(customerlist);
        }

     

        // GET: CustomersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomersController/Create
        [HttpPost]


        public async Task<IActionResult> Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                dBContext.Add(customer);
                await dBContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }


        // GET: CustomersController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var customer = await dBContext.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: CustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Customer customer)
        {
            if (id!= customer.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    dBContext.Update(customer);
                    await dBContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExits(customer.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }



        // GET: CustomersController/Delete/5

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var customer = await dBContext.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await dBContext.Customers.FindAsync(id);
          
            dBContext.Customers.Remove(customer);
            await dBContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool CustomerExits(int id)
        {
            return dBContext.Customers.Any(e => e.ID == id);
        }
    }
}
    
