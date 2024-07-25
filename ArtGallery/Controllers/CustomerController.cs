using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArtGallery.Data;
using ArtGallery.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace ArtGallery.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CustomerController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            var customers = await _context.Customers.Include(c => c.Account).ToListAsync();
            
            var customerViews = _mapper.Map<List<CustomerView>>(customers);
            return View(customerViews);
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.Account)
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            
            if (customer == null)
            {
                return NotFound();
            }

            var customerView = _mapper.Map<CustomerView>(customer);

            return View(customerView);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerCreate customerCreate)
        {
            if (ModelState.IsValid)
            {
                var account = _mapper.Map<Account>(customerCreate);
                account.Role = "Customer";
                _context.Add(account);
                await _context.SaveChangesAsync();

                var customer = _mapper.Map<Customer>(customerCreate);
                customer.AccountId = account.AccountId;
                _context.Add(customer);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            
            return View(customerCreate);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.Include(c => c.Account).FirstOrDefaultAsync(x => x.CustomerId == id);

            if (customer == null)
            {
                return NotFound();
            }

            var customerView = _mapper.Map<CustomerView>(customer);

            return View(customerView);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CustomerEdit customerEdit)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (ModelState.IsValid)
            {
                _mapper.Map(customerEdit, customer);
                _context.Update(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.Account)
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            var customerView = _mapper.Map<CustomerView>(customer);

            return View(customerView);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts.FindAsync(customer.AccountId);

            _context.Customers.Remove(customer);
            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }
    }
}
