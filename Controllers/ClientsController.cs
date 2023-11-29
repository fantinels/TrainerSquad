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
    public class ClientsController : Controller
    {
        private readonly TrainerSquadContext _context;

        public ClientsController(TrainerSquadContext context)
        {
            _context = context;
        }

        // GET: Clients
        public async Task<IActionResult> Index()
        {
            var trainerSquadContext = _context.Client.Include(c => c.Personal);
            return View(await trainerSquadContext.ToListAsync());
        }

        // GET: Clients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            List<Payment> payments = _context.Payment.ToList();
            List<PhysicalAssessment> physicalAssessment = _context.PhysicalAssessment.ToList();
            if (id == null || _context.Client == null)
            {
                return NotFound();
            }

            var client = await _context.Client
                .Include(c => c.Personal)
                .Include("Payments")
                .Include("PhysicalAssessments")

                .FirstOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            ClientFormViewModel viewModel = new ClientFormViewModel();
            viewModel.Client = client;
            viewModel.Payments = payments;
            viewModel.PhysicalAssessments = physicalAssessment;

            return View(client);
        }

        // GET: Clients/Create
        public IActionResult Create()
        {
            var viewModel = new ClientFormViewModel(); 
            viewModel.Personals = _context.Personal.ToList();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientFormViewModel clientFormViewModel)
        {
            _context.Add(clientFormViewModel.Client);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var client = _context.Client.FirstOrDefault(c => c.Id == id);

            if (client == null)
            {
                return NotFound();
            }

            List<Personal> personals = _context.Personal.ToList();

            ClientFormViewModel viewModel = new ClientFormViewModel();

            viewModel.Personals = personals;
            viewModel.Client = client;

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Client client)
        {
            if (client == null)
            {
                return NotFound();
            }

            _context.Update(client);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Client == null)
            {
                return NotFound();
            }

            var client = await _context.Client
                .Include(c => c.Personal)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Client == null)
            {
                return Problem("Entity set 'TrainerSquadContext.Client'  is null.");
            }
            var client = await _context.Client.FindAsync(id);
            if (client != null)
            {
                _context.Client.Remove(client);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(int id)
        {
          return (_context.Client?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
