using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using TrainerSquad.Data;
using TrainerSquad.Models;
using TrainerSquad.Models.ViewModels;

namespace TrainerSquad.Controllers
{
    public class EquipmentsController : Controller
    {
        private readonly TrainerSquadContext _context;

        public EquipmentsController(TrainerSquadContext context)
        {
            _context = context;
        }

        // GET: Equipments
        public async Task<IActionResult> Index()
        {
            var trainerSquadContext = _context.Equipment.Include(e => e.Personal);
            return View(await trainerSquadContext.ToListAsync());
        }

        // GET: Equipments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Equipment == null)
            {
                return NotFound();
            }

            var equipment = await _context.Equipment
                .Include(e => e.Personal)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipment == null)
            {
                return NotFound();
            }

            return View(equipment);
        }

        // GET: Equipments/Create
        public IActionResult Create()
        {
            var viewModel = new EquipmentFormViewModel();
            viewModel.Personals = _context.Personal.ToList();

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EquipmentFormViewModel equipmentFormViewModel)
        {
            _context.Add(equipmentFormViewModel.Equipment);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: Equipments/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var equipment = _context.Equipment.FirstOrDefault(e => e.Id == id);

            if (equipment == null)
            {
                return NotFound();
            }

            List<Personal> personals = _context.Personal.ToList();

            EquipmentFormViewModel viewModel = new EquipmentFormViewModel();

            viewModel.Personals = personals;
            viewModel.Equipment = equipment;

            return View(viewModel);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(Equipment equipment)
        {
            if (equipment == null)
            {
                return NotFound();
            }

            _context.Update(equipment);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Equipments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Equipment == null)
            {
                return NotFound();
            }

            var equipment = await _context.Equipment
                .Include(e => e.Personal)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipment == null)
            {
                return NotFound();
            }

            return View(equipment);
        }

        // POST: Equipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Equipment == null)
            {
                return Problem("Entity set 'TrainerSquadContext.Equipment'  is null.");
            }
            var equipment = await _context.Equipment.FindAsync(id);
            if (equipment != null)
            {
                _context.Equipment.Remove(equipment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipmentExists(int id)
        {
          return (_context.Equipment?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
