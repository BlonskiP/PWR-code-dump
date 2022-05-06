﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskRegiser.Core;
using TaskRegiser.Core.Entities;

namespace TaskRegister.View.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly SignInManager<Employee> _signInManager;
        public ProjectsController(AppDbContext context, SignInManager<Employee> signInManager)
        {
            _signInManager = signInManager;
            _context = context;
        }

        // GET: Projects
        [Authorize(Roles = RolesResource.Policy.AdminOnly)]
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Projects.Include(p => p.ProjectManager);
            return View(await appDbContext.ToListAsync());
        }

        [Authorize(Roles = RolesResource.Policy.AllUsers)]
        public async Task<IActionResult> GetUserProjects()
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var appDbContext = await _context.Projects.Include(p => p.ProjectManager).Where(p => p.ProjectManager.Id == user).ToListAsync();
            return View(appDbContext);
        }
        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .Include(p => p.ProjectManager)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Projects/Create
        [Authorize(Roles = RolesResource.Policy.AdminOnly)]
        public IActionResult Create()
        {
            ViewData["EmployeeFK"] = new SelectList(_context.Users, "Id", "UserName");
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RolesResource.Policy.AdminOnly)]
        public async Task<IActionResult> Create([Bind("ID,Name,EmployeeFK,CreationDate")] Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeFK"] = new SelectList(_context.Users, "Id", "UserName", project.EmployeeFK);
            return View(project);
        }

        // GET: Projects/Edit/5
        [Authorize(Roles = RolesResource.Policy.AdminOnly)]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            ViewData["EmployeeFK"] = new SelectList(_context.Users, "Id", "UserName", project.EmployeeFK);
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RolesResource.Policy.AdminOnly)]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,EmployeeFK,CreationDate")] Project project)
        {
            if (id != project.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.ID))
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
            ViewData["EmployeeFK"] = new SelectList(_context.Users, "Id", "UserName", project.EmployeeFK);
            return View(project);
        }

        // GET: Projects/Delete/5
        [Authorize(Roles = RolesResource.Policy.AdminOnly)]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .Include(p => p.ProjectManager)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [Authorize(Roles = RolesResource.Policy.AdminOnly)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.ID == id);
        }
    }
}
