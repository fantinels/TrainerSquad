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
    public class SchedulesController : Controller
    {
        private readonly TrainerSquadContext _context;

        public SchedulesController(TrainerSquadContext context)
        {
            _context = context;
        }

        // GET: Schedules
        public async Task<IActionResult> Index()
        {
            var trainerSquadContext = _context.Schedule.Include(s => s.Client).Include(s => s.Personal);
            return View(await trainerSquadContext.ToListAsync());
        }

        // GET: Schedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Schedule == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedule
                .Include(s => s.Client)
                .Include(s => s.Personal)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // GET: Schedules/Create
        public IActionResult Create()
        {
            var viewModel = new ScheduleFormViewModel();
            viewModel.Clients = _context.Client.ToList();
            viewModel.Personals = _context.Personal.ToList();

            return View(viewModel);
        }

        // POST: Schedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ScheduleFormViewModel scheduleFormViewModel)
        {
            _context.Add(scheduleFormViewModel.Schedule);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: Schedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var schedule = _context.Schedule.FirstOrDefault(s => s.Id == id);

            if (schedule == null)
            {
                return NotFound();
            }

            List<Client> clients = _context.Client.ToList();
            List<Personal> personals = _context.Personal.ToList();

            ScheduleFormViewModel viewModel = new ScheduleFormViewModel();

            viewModel.Schedule = schedule;
            viewModel.Clients = clients;
            viewModel.Personals = personals;

            return View(viewModel);
        }

        // POST: Schedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Schedule schedule)
        {
            if (schedule == null)
            {
                return NotFound();
            }

            _context.Update(schedule);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Schedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Schedule == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedule
                .Include(s => s.Client)
                .Include(s => s.Personal)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // POST: Schedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Schedule == null)
            {
                return Problem("Entity set 'TrainerSquadContext.Schedule'  is null.");
            }
            var schedule = await _context.Schedule.FindAsync(id);
            if (schedule != null)
            {
                _context.Schedule.Remove(schedule);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScheduleExists(int id)
        {
          return (_context.Schedule?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
