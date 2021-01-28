using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Wypozyczalnia_sprzetu_budowlanego.Models;

namespace Wypozyczalnia_sprzetu_budowlanego.Controllers
{
    public class RentingsController : Controller
    {
        private readonly baza_sprzetContext _context;

        public RentingsController(baza_sprzetContext context)
        {
            _context = context;
        }

        // GET: Rentings
        public async Task<IActionResult> Index()
        {
            var baza_sprzetContext = _context.Renting.Include(r => r.Customer).Include(r => r.Tool);
            return View(await baza_sprzetContext.ToListAsync());
        }

        // GET: Rentings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var renting = await _context.Renting
                .Include(r => r.Customer)
                .Include(r => r.Tool)
                .FirstOrDefaultAsync(m => m.IdRenting == id);
            if (renting == null)
            {
                return NotFound();
            }

            return View(renting);
        }

        // GET: Rentings/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "IdCustomer", "Email");
            ViewData["ToolId"] = new SelectList(_context.Tool, "IdTool", "Model");
            return View();
        }

        // POST: Rentings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRenting,CustomerId,ToolId,Data")] Renting renting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(renting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "IdCustomer", "Email", renting.CustomerId);
            ViewData["ToolId"] = new SelectList(_context.Tool, "IdTool", "Model", renting.ToolId);
            return View(renting);
        }

        // GET: Rentings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var renting = await _context.Renting.FindAsync(id);
            if (renting == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "IdCustomer", "Email", renting.CustomerId);
            ViewData["ToolId"] = new SelectList(_context.Tool, "IdTool", "Model", renting.ToolId);
            return View(renting);
        }

        // POST: Rentings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRenting,CustomerId,ToolId,Data")] Renting renting)
        {
            if (id != renting.IdRenting)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(renting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentingExists(renting.IdRenting))
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
            ViewData["CustomerId"] = new SelectList(_context.Customer, "IdCustomer", "Email", renting.CustomerId);
            ViewData["ToolId"] = new SelectList(_context.Tool, "IdTool", "Model", renting.ToolId);
            return View(renting);
        }

        // GET: Rentings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var renting = await _context.Renting
                .Include(r => r.Customer)
                .Include(r => r.Tool)
                .FirstOrDefaultAsync(m => m.IdRenting == id);
            if (renting == null)
            {
                return NotFound();
            }

            return View(renting);
        }

        // POST: Rentings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var renting = await _context.Renting.FindAsync(id);
            _context.Renting.Remove(renting);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentingExists(int id)
        {
            return _context.Renting.Any(e => e.IdRenting == id);
        }
    }
}
