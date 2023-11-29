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
    public class TrainingsController : Controller
    {
        private readonly TrainerSquadContext _context;

        public TrainingsController(TrainerSquadContext context)
        {
            _context = context;
        }

        // GET: Trainings
        public async Task<IActionResult> Index()
        {
            var trainerSquadContext = _context.Training.Include(t => t.Client);
            return View(await trainerSquadContext.ToListAsync());
        }

        // GET: Trainings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Training == null)
            {
                return NotFound();
            }

            var training = await _context.Training
                .Include(t => t.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (training == null)
            {
                return NotFound();
            }

            return View(training);
        }

        // GET: Trainings/Create
        public IActionResult Create()
        {
            var viewModel = new TrainingFormViewModel();
            viewModel.Clients = _context.Client.ToList();

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TrainingFormViewModel trainingFormViewModel)
        {
            _context.Add(trainingFormViewModel.Training);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: Trainings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var training = _context.Training.FirstOrDefault(t => t.Id == id);

            if (training == null)
            {
                return NotFound();
            }

            List<Client> clients = _context.Client.ToList();

            TrainingFormViewModel viewModel = new TrainingFormViewModel();

            viewModel.Training = training;
            viewModel.Clients = clients;

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Training training)
        {
            if (training == null)
            {
                return NotFound();
            }

            _context.Update(training);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Trainings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Training == null)
            {
                return NotFound();
            }

            var training = await _context.Training
                .Include(t => t.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (training == null)
            {
                return NotFound();
            }

            return View(training);
        }

        // POST: Trainings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Training == null)
            {
                return Problem("Entity set 'TrainerSquadContext.Training'  is null.");
            }
            var training = await _context.Training.FindAsync(id);
            if (training != null)
            {
                _context.Training.Remove(training);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainingExists(int id)
        {
          return (_context.Training?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
