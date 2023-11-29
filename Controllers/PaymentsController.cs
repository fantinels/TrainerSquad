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
    public class PaymentsController : Controller
    {
        private readonly TrainerSquadContext _context;

        public PaymentsController(TrainerSquadContext context)
        {
            _context = context;
        }

        // GET: Payments
        public async Task<IActionResult> Index()
        {
            var trainerSquadContext = _context.Payment.Include(p => p.Client);
            return View(await trainerSquadContext.ToListAsync());
        }

        // GET: Payments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Payment == null)
            {
                return NotFound();
            }

            var payment = await _context.Payment
                .Include(p => p.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // GET: Payments/Create
        public IActionResult Create()
        {
            var viewModel = new PaymentFormViewModel();
            viewModel.Clients = _context.Client.ToList();

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PaymentFormViewModel paymentFormViewModel)
        {
            _context.Add(paymentFormViewModel.Payment);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: Payments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var payment = _context.Payment.FirstOrDefault(e => e.Id == id);

            if (payment == null)
            {
                return NotFound();
            }

            List<Client> clients = _context.Client.ToList();

            PaymentFormViewModel viewModel = new PaymentFormViewModel();

            viewModel.Payment = payment;
            viewModel.Clients = clients;

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Payment payment)
        {
            if (payment == null)
            {
                return NotFound();
            }

            _context.Update(payment);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Payments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Payment == null)
            {
                return NotFound();
            }

            var payment = await _context.Payment
                .Include(p => p.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Payment == null)
            {
                return Problem("Entity set 'TrainerSquadContext.Payment'  is null.");
            }
            var payment = await _context.Payment.FindAsync(id);
            if (payment != null)
            {
                _context.Payment.Remove(payment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentExists(int id)
        {
          return (_context.Payment?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
