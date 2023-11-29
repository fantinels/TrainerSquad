using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrainerSquad.Data;
using TrainerSquad.Models;
using TrainerSquad.Models.ViewModels;

namespace TrainerSquad.Controllers
{
    public class PersonalsController : Controller
    {
        private readonly TrainerSquadContext _context;

        public PersonalsController(TrainerSquadContext context)
        {
            _context = context;
        }

        // GET: Personals
        public async Task<IActionResult> Index()
        {
              return _context.Personal != null ? 
                          View(await _context.Personal.ToListAsync()) :
                          Problem("Entity set 'TrainerSquadContext.Personal'  is null.");
        }

        // GET: Personals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            List<Equipment> equipments = _context.Equipment.ToList();
            List<Client> clients = _context.Client.ToList();
            //List<Schedule> schedules = _context.Schedule.ToList();
            //List<Schedule> schedules = _context.Schedule.ToList();
            if (id == null || _context.Personal == null)
            {
                return NotFound();
            }

            var personal = await _context.Personal
                .Include("Equipments")
                .Include("Clients")
                .Include("Schedule")
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personal == null)
            {
                return NotFound();
            }

            PersonalFormViewModel viewModel = new PersonalFormViewModel();
            viewModel.Equipments = equipments;
            viewModel.Clients = clients;
            viewModel.Personal = personal;

            return View(viewModel);
        }

        // GET: Personals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Personals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Password,Email")] Personal personal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personal);
        }

        // GET: Personals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Personal == null)
            {
                return NotFound();
            }

            var personal = await _context.Personal.FindAsync(id);
            if (personal == null)
            {
                return NotFound();
            }
            return View(personal);
        }

        // POST: Personals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Password,Email")] Personal personal)
        {
            if (id != personal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonalExists(personal.Id))
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
            return View(personal);
        }

        // GET: Personals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Personal == null)
            {
                return NotFound();
            }

            var personal = await _context.Personal
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personal == null)
            {
                return NotFound();
            }

            return View(personal);
        }

        // POST: Personals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Personal == null)
            {
                return Problem("Entity set 'TrainerSquadContext.Personal'  is null.");
            }
            var personal = await _context.Personal.FindAsync(id);
            if (personal != null)
            {
                _context.Personal.Remove(personal);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonalExists(int id)
        {
          return (_context.Personal?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
