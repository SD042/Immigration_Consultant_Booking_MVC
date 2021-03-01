using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Immigration_Consultant_Booking_MVC.Data;
using Immigration_Consultant_Booking_MVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace Immigration_Consultant_Booking_MVC.Controllers
{
    public class ConsultationBookingsController : Controller
    {
        private readonly Immigration_Consultant_Booking_DBContext _context;

        public ConsultationBookingsController(Immigration_Consultant_Booking_DBContext context)
        {
            _context = context;
        }
        [Authorize]
        // GET: ConsultationBookings
        public async Task<IActionResult> Index()
        {
            var immigration_Consultant_Booking_DBContext = _context.ConsultationBooking.Include(c => c.Client).Include(c => c.Consultant);
            return View(await immigration_Consultant_Booking_DBContext.ToListAsync());
        }
        [Authorize]
        // GET: ConsultationBookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultationBooking = await _context.ConsultationBooking
                .Include(c => c.Client)
                .Include(c => c.Consultant)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consultationBooking == null)
            {
                return NotFound();
            }

            return View(consultationBooking);
        }
        [Authorize]
        // GET: ConsultationBookings/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Id");
            ViewData["ConsultantId"] = new SelectList(_context.Consultant, "Id", "Id");
            return View();
        }

        // POST: ConsultationBookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClientId,ConsultantId")] ConsultationBooking consultationBooking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consultationBooking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Id", consultationBooking.ClientId);
            ViewData["ConsultantId"] = new SelectList(_context.Consultant, "Id", "Id", consultationBooking.ConsultantId);
            return View(consultationBooking);
        }
        [Authorize]
        // GET: ConsultationBookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultationBooking = await _context.ConsultationBooking.FindAsync(id);
            if (consultationBooking == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Id", consultationBooking.ClientId);
            ViewData["ConsultantId"] = new SelectList(_context.Consultant, "Id", "Id", consultationBooking.ConsultantId);
            return View(consultationBooking);
        }

        // POST: ConsultationBookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClientId,ConsultantId")] ConsultationBooking consultationBooking)
        {
            if (id != consultationBooking.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consultationBooking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultationBookingExists(consultationBooking.Id))
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
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Id", consultationBooking.ClientId);
            ViewData["ConsultantId"] = new SelectList(_context.Consultant, "Id", "Id", consultationBooking.ConsultantId);
            return View(consultationBooking);
        }
        [Authorize]
        // GET: ConsultationBookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consultationBooking = await _context.ConsultationBooking
                .Include(c => c.Client)
                .Include(c => c.Consultant)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consultationBooking == null)
            {
                return NotFound();
            }

            return View(consultationBooking);
        }

        // POST: ConsultationBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consultationBooking = await _context.ConsultationBooking.FindAsync(id);
            _context.ConsultationBooking.Remove(consultationBooking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultationBookingExists(int id)
        {
            return _context.ConsultationBooking.Any(e => e.Id == id);
        }
    }
}
