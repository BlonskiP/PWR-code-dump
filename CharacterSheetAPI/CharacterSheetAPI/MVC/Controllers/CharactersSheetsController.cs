using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DbManager.CORE;
using DbManager.CORE.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace MVC.Controllers
{

    public class CharactersSheetsController : Controller
    {
        private readonly DbCharacterContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private IdentityUser user;

        public CharactersSheetsController(DbCharacterContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        private Task<IdentityUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: CharactersSheets
        [Authorize(Roles = "Admin, Org")]
        public async Task<IActionResult> Index()
        {
            var dbCharacterContext = _context.CharactersSheets.Include(c => c.EventIdFkNavigation).Include(c => c.PlayerIdFkNavigation);
            return View(await dbCharacterContext.ToListAsync());
        }
        [Authorize]
        public async Task<IActionResult> UsersCharacterSheets()
        {
            Players player;
            user = await GetCurrentUserAsync();
            player = _context.Players.Where(pl => pl.AspUserIdFkNavigation == user).First();
            var dbCharacterContext = _context.CharactersSheets.Include(c => c.EventIdFkNavigation).Include(c => c.PlayerIdFkNavigation).Where(ch => ch.PlayerIdFkNavigation == player);
            dbCharacterContext = dbCharacterContext;
            return View(await dbCharacterContext.ToListAsync());
        }
        [Authorize(Roles = "Admin, Org")]
        // GET: CharactersSheets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var charactersSheets = await _context.CharactersSheets
                .Include(c => c.EventIdFkNavigation)
                .Include(c => c.PlayerIdFkNavigation)
                .FirstOrDefaultAsync(m => m.SheetId == id);
            if (charactersSheets == null)
            {
                return NotFound();
            }

            return View(charactersSheets);
        }

        // GET: CharactersSheets/Create
        public IActionResult Create()
        {
            ViewData["EventIdFk"] = new SelectList(_context.EventsTable, "EventId", "EventDescription");
            ViewData["PlayerIdFk"] = new SelectList(_context.Players, "PlayerId", "AspUserIdFk");
            return View();
        }

        // POST: CharactersSheets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SheetId,Name,Money,Description,Approved,EventIdFk")] CharactersSheets charactersSheets)
        {
            var user = await GetCurrentUserAsync();
            charactersSheets.Approved = false;
            charactersSheets.Money = 0;
            charactersSheets.EventIdFkNavigation = _context.EventsTable.Find(charactersSheets.EventIdFk);
            charactersSheets.SheetId = _context.CharactersSheets.Count();
            var players = _context.Players.Where(pl => pl.AspUserIdFkNavigation == user).First();
            charactersSheets.PlayerIdFk = players.PlayerId;
            charactersSheets.PlayerIdFkNavigation = players;
            if (ModelState.IsValid)
            {
                _context.Add(charactersSheets);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventIdFk"] = new SelectList(_context.EventsTable, "EventId", "EventDescription", charactersSheets.EventIdFk);
            ViewData["PlayerIdFk"] = new SelectList(_context.Players, "PlayerId", "AspUserIdFk", charactersSheets.PlayerIdFk);
            return View(charactersSheets);
        }

        // GET: CharactersSheets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var charactersSheets = await _context.CharactersSheets.FindAsync(id);
            if (charactersSheets == null)
            {
                return NotFound();
            }
            ViewData["EventIdFk"] = new SelectList(_context.EventsTable, "EventId", "EventDescription", charactersSheets.EventIdFk);
            ViewData["PlayerIdFk"] = new SelectList(_context.Players, "PlayerId", "AspUserIdFk", charactersSheets.PlayerIdFk);
            return View(charactersSheets);
        }

        // POST: CharactersSheets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SheetId,PlayerIdFk,Name,Money,Description,Approved,EventIdFk")] CharactersSheets charactersSheets)
        {
            if (id != charactersSheets.SheetId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(charactersSheets);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CharactersSheetsExists(charactersSheets.SheetId))
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
            ViewData["EventIdFk"] = new SelectList(_context.EventsTable, "EventId", "EventDescription", charactersSheets.EventIdFk);
            ViewData["PlayerIdFk"] = new SelectList(_context.Players, "PlayerId", "AspUserIdFk", charactersSheets.PlayerIdFk);
            return View(charactersSheets);
        }

        // GET: CharactersSheets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var charactersSheets = await _context.CharactersSheets
                .Include(c => c.EventIdFkNavigation)
                .Include(c => c.PlayerIdFkNavigation)
                .FirstOrDefaultAsync(m => m.SheetId == id);
            if (charactersSheets == null)
            {
                return NotFound();
            }

            return View(charactersSheets);
        }

        // POST: CharactersSheets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var charactersSheets = await _context.CharactersSheets.FindAsync(id);
            _context.CharactersSheets.Remove(charactersSheets);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CharactersSheetsExists(int id)
        {
            return _context.CharactersSheets.Any(e => e.SheetId == id);
        }

        public async Task<IActionResult> GetCharacterSheet(string APIKEY, string mail)
        {
            if(String.IsNullOrEmpty(APIKEY) || String.IsNullOrEmpty(mail))
            {
                return BadRequest("One of the parameters in Request was null or empty");
            }
            Players user = null;
            try {user =  _context.Players.Where(u => u.Email == mail).First(); }
            catch (Exception e) { }

            if (user == null)
                return BadRequest("No user found");
            EventsTable eventItem = new EventsTable();
            try
            {
                eventItem = _context.EventsTable.Where(eve => eve.ApiKeys.Where(key => key.Apikey == APIKEY).First().EventId == eve.EventId).First();
            }
            catch(Exception e) { return BadRequest("No event with this apikey was found"); }
            CharactersSheets character = null;
            try
            {
                var characterList = _context.CharactersSheets.Where(ch => ch.EventIdFk == eventItem.EventId).ToList();
                character = characterList.Where(ch => ch.PlayerIdFk == user.PlayerId).First();
            }
            catch (Exception e) { }
            if (character==null)
            {
                return BadRequest("No charater  was not found");
            }


           
            sheet item = new sheet();
            item.name = character.Name;
            item.desc = character.Description;
            item.money = character.Money;
            item.approved = character.Approved;



            return Json(item);
        }
        struct sheet
        {
            public string name;
            public int? money;
            public string desc;
            public bool? approved;
        }
    }
}
