using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EasyBus.Models;

namespace EasyBusProject.Controllers
{
    public class TripController : Controller
    {
        private readonly MainDbContext _context;

        public TripController(MainDbContext context)
        {
            _context = context;
        }

        // GET: Trip
        public async Task<IActionResult> Index()
        {
            var mainDbContext = _context.Trips.Include(t => t.Bus).Include(t => t.DropOff).Include(t => t.PickUp);
            return View(await mainDbContext.ToListAsync());
        }

        // GET: Trip/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trips
                .Include(t => t.Bus)
                .Include(t => t.DropOff)
                .Include(t => t.PickUp)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        // GET: Trip/Create
        public IActionResult Create()
        {
            ViewData["BusId"] = new SelectList(_context.Buses, "Id", "Model");
            ViewData["DropOffID"] = new SelectList(_context.Stations, "Id", "Name");
            ViewData["PickUpID"] = new SelectList(_context.Stations, "Id", "Name");
            return View();
        }

        // POST: Trip/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind("Id,Name,BusId,Time,Price,Duration,PickUpID,DropOffID")]*/ Trip trip, List<string> AvailableDays)
        {
            if (AvailableDays != null)
            {
                trip.AvailableDays = AvailableDays.Select(Enum.Parse<WeekDays>).ToList();
                var available = ModelState["AvailableDays"];
                if (available != null && trip.AvailableDays.Count > 0) 
                {
                    available.ValidationState = Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid;
                }
                available = ModelState["Bus"];
                if (available != null) 
                {
                    available.ValidationState = Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid;
                }
            }
            if (ModelState.IsValid)
            {
                _context.Add(trip);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BusId"] = new SelectList(_context.Buses, "Id", "Model", trip.BusId);
            ViewData["DropOffID"] = new SelectList(_context.Stations, "Id", "Name", trip.DropOffID);
            ViewData["PickUpID"] = new SelectList(_context.Stations, "Id", "Name", trip.PickUpID);
            return View(trip);
        }

        // GET: Trip/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trips.FindAsync(id);
            if (trip == null)
            {
                return NotFound();
            }
            ViewData["BusId"] = new SelectList(_context.Buses, "Id", "Model", trip.BusId);
            ViewData["DropOffID"] = new SelectList(_context.Stations, "Id", "City", trip.DropOffID);
            ViewData["PickUpID"] = new SelectList(_context.Stations, "Id", "City", trip.PickUpID);
            return View(trip);
        }

        // POST: Trip/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,AvailableDays,BusId,Time,Price,Duration,PickUpID,DropOffID")] Trip trip)
        {
            if (id != trip.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trip);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TripExists(trip.Id))
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
            ViewData["BusId"] = new SelectList(_context.Buses, "Id", "Model", trip.BusId);
            ViewData["DropOffID"] = new SelectList(_context.Stations, "Id", "City", trip.DropOffID);
            ViewData["PickUpID"] = new SelectList(_context.Stations, "Id", "City", trip.PickUpID);
            return View(trip);
        }

        // GET: Trip/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trips
                .Include(t => t.Bus)
                .Include(t => t.DropOff)
                .Include(t => t.PickUp)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        // POST: Trip/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trip = await _context.Trips.FindAsync(id);
            if (trip != null)
            {
                _context.Trips.Remove(trip);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TripExists(int id)
        {
            return _context.Trips.Any(e => e.Id == id);
        }
    }
}
