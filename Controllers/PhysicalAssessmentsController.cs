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
    public class PhysicalAssessmentsController : Controller
    {
        private readonly TrainerSquadContext _context;

        public PhysicalAssessmentsController(TrainerSquadContext context)
        {
            _context = context;
        }

        // GET: PhysicalAssessments
        public async Task<IActionResult> Index()
        {
            var trainerSquadContext = _context.PhysicalAssessment.Include(p => p.Client);
            return View(await trainerSquadContext.ToListAsync());
        }

        // GET: PhysicalAssessments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PhysicalAssessment == null)
            {
                return NotFound();
            }

            var physicalAssessment = await _context.PhysicalAssessment
                .Include(p => p.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (physicalAssessment == null)
            {
                return NotFound();
            }

            return View(physicalAssessment);
        }

        // GET: PhysicalAssessments/Create
        public IActionResult Create()
        {
            var viewModel = new PhysicalAssessmentFormViewModel();
            viewModel.Clients = _context.Client.ToList();

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PhysicalAssessmentFormViewModel physicalAssessmentFormViewModel)
        {
            _context.Add(physicalAssessmentFormViewModel.PhysicalAssessment);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: PhysicalAssessments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var physicalAssessment = _context.PhysicalAssessment.FirstOrDefault(p => p.Id == id);

            if (physicalAssessment == null)
            {
                return NotFound();
            }

            List<Client> clients = _context.Client.ToList();

            PhysicalAssessmentFormViewModel viewModel = new PhysicalAssessmentFormViewModel();

            viewModel.PhysicalAssessment = physicalAssessment;
            viewModel.Clients = clients;

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit( PhysicalAssessment physicalAssessment)
        {
            if (physicalAssessment == null)
            {
                return NotFound();
            }

            _context.Update(physicalAssessment);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: PhysicalAssessments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PhysicalAssessment == null)
            {
                return NotFound();
            }

            var physicalAssessment = await _context.PhysicalAssessment
                .Include(p => p.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (physicalAssessment == null)
            {
                return NotFound();
            }

            return View(physicalAssessment);
        }

        // POST: PhysicalAssessments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PhysicalAssessment == null)
            {
                return Problem("Entity set 'TrainerSquadContext.PhysicalAssessment'  is null.");
            }
            var physicalAssessment = await _context.PhysicalAssessment.FindAsync(id);
            if (physicalAssessment != null)
            {
                _context.PhysicalAssessment.Remove(physicalAssessment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhysicalAssessmentExists(int id)
        {
          return (_context.PhysicalAssessment?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
