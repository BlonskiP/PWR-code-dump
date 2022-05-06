using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DbManager.CORE;
using DbManager.CORE.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace MVC.Controllers
{
    public class EventsTablesController : Controller
    {
        private readonly DbCharacterContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        private  IdentityUser user;

        public EventsTablesController(DbCharacterContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            
        }
        private Task<IdentityUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        // GET: EventsTables
        public async Task<IActionResult> Index()
        {
            return View(await _context.EventsTable.ToListAsync());
        }

        // GET: EventsTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventsTable = await _context.EventsTable
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (eventsTable == null)
            {
                return NotFound();
            }

            return View(eventsTable);
        }

        // GET: EventsTables/Create
        [Authorize(Roles = "Admin, Org")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: EventsTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Org")]
        public async Task<IActionResult> Create([Bind("EventId,EventTitle,EventDate,Place,EventDescription")] EventsTable eventsTable)
        {
            eventsTable.EventId = _context.EventsTable.Count();
            if (ModelState.IsValid)
            {
                user = await GetCurrentUserAsync();
                ApiKeys newKey = new ApiKeys(eventsTable,_context,user);
                _context.Add(newKey);
                _context.Add(eventsTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventsTable);
        }

        // GET: EventsTables/Edit/5
        [Authorize(Roles = "Admin, Org")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventsTable = await _context.EventsTable.FindAsync(id);
            if (eventsTable == null)
            {
                return NotFound();
            }
            return View(eventsTable);
        }

        // POST: EventsTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Org")]
        public async Task<IActionResult> Edit(int id, [Bind("EventId,EventTitle,EventDate,Place,EventDescription")] EventsTable eventsTable)
        {
            if (id != eventsTable.EventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventsTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventsTableExists(eventsTable.EventId))
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
            return View(eventsTable);
        }

        // GET: EventsTables/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventsTable = await _context.EventsTable
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (eventsTable == null)
            {
                return NotFound();
            }

            return View(eventsTable);
        }

        // POST: EventsTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventsTable = await _context.EventsTable.FindAsync(id);
            foreach(var character in _context.CharactersSheets)
            {
                if(character.EventIdFkNavigation==eventsTable)
                {
                    character.EventIdFk = null;
                    character.EventIdFkNavigation = null;
                }
            }
            foreach (var item in _context.ApiKeys)
            {
                if (item.Event == eventsTable)
                    _context.Remove(item);
            }
            _context.EventsTable.Remove(eventsTable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventsTableExists(int id)
        {
            return _context.EventsTable.Any(e => e.EventId == id);
        }

        public async Task<IActionResult> CreateCharacter(int eventId)
        {
            var Event = await _context.EventsTable.FindAsync(eventId);
            var Players = await _context.Players.ToListAsync();
            user = await GetCurrentUserAsync();

            var Player =  _context.Players.Where(us => us.AspUserIdFkNavigation == user).First();
            CharactersSheets sheet;
            try { sheet = _context.CharactersSheets.Where(ch => ch.PlayerIdFkNavigation == Player).First();
            }
            catch {
                sheet = null;
            }
            if (sheet == null)
            {
                ViewBag.EventId = eventId;
                return View();
            }
            else
                return View("Już masz postać na ten event");


        }
    }
}
