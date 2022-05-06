using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DbManager.CORE;
using DbManager.CORE.Models;
using System.Data;
using Microsoft.AspNetCore.Authorization;


namespace MVC
{
    [Authorize(Roles = "Admin")]
    public class ApiKeysController : Controller
    {
        private readonly DbCharacterContext _context;

        public ApiKeysController(DbCharacterContext context)
        {
            _context = context;
        }

        // GET: ApiKeys
        public async Task<IActionResult> Index()
        {
            var dbCharacterContext = _context.ApiKeys.Include(a => a.Event);
            return View(await dbCharacterContext.ToListAsync());
        }

        // GET: ApiKeys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apiKeys = await _context.ApiKeys
                .Include(a => a.Event)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (apiKeys == null)
            {
                return NotFound();
            }

            return View(apiKeys);
        }

        // GET: ApiKeys/Create
        public IActionResult Create()
        {
            ViewData["EventId"] = new SelectList(_context.EventsTable, "EventId", "EventDescription");
            return View();
        }

        // POST: ApiKeys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Apikey,EventId,AspUserIdFk")] ApiKeys apiKeys)
        {
            if (ModelState.IsValid)
            {
                _context.Add(apiKeys);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventId"] = new SelectList(_context.EventsTable, "EventId", "EventDescription", apiKeys.EventId);
            return View(apiKeys);
        }

        // GET: ApiKeys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apiKeys = await _context.ApiKeys.FindAsync(id);
            if (apiKeys == null)
            {
                return NotFound();
            }
            ViewData["EventId"] = new SelectList(_context.EventsTable, "EventId", "EventDescription", apiKeys.EventId);
            return View(apiKeys);
        }

        // POST: ApiKeys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Apikey,EventId,AspUserIdFk")] ApiKeys apiKeys)
        {
            if (id != apiKeys.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apiKeys);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApiKeysExists(apiKeys.Id))
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
            ViewData["EventId"] = new SelectList(_context.EventsTable, "EventId", "EventDescription", apiKeys.EventId);
            return View(apiKeys);
        }

        // GET: ApiKeys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apiKeys = await _context.ApiKeys
                .Include(a => a.Event)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (apiKeys == null)
            {
                return NotFound();
            }

            return View(apiKeys);
        }

        // POST: ApiKeys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apiKeys = await _context.ApiKeys.FindAsync(id);
            _context.ApiKeys.Remove(apiKeys);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApiKeysExists(int id)
        {
            return _context.ApiKeys.Any(e => e.Id == id);
        }
    }
}
