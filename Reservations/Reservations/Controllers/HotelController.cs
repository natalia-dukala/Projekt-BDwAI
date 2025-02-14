using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Reservations.Models;

namespace Reservations.Controllers
{
    public class HotelController : Controller
    {
        private readonly ReservationsDbContext _context;
        public HotelController(ReservationsDbContext context)
        {
            _context = context;
        }

        // GET: HotelController
        public ActionResult Index()
        {
            var hotels = _context.Hotels.Include(h => h.Category).Include(h => h.Rooms).ToList();
            return View(hotels);
        }

        // GET: HotelController/Details/5
        public ActionResult Details(int id)
        {
            var hotel = _context.Hotels
                .Include(h => h.Category)
                .Include(h => h.Rooms)
                .FirstOrDefault(h => h.Id == id);

            if (hotel == null)
            {
                return NotFound(); // Zwracamy stronę 404, jeśli hotel nie istnieje
            }

            ViewBag.HotelId = hotel.Id;
            return View(hotel);
        }


        // GET: HotelController/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        // POST: HotelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Hotel hotel)
        {
            try
            {
                _context.Hotels.Add(hotel);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Name", hotel.CategoryId);
                
                return View(hotel);
            }
        }

        // GET: HotelController/Edit/5
        public ActionResult Edit(int id)
        {
            var hotel = _context.Hotels.Find(id);
            ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Name");

            return View(hotel);
        }

        // POST: HotelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Hotel hotel)
        {
            try
            {
                _context.Hotels.Update(hotel);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Name", hotel.CategoryId);
                
                return View(hotel);
            }
        }

        // GET: HotelController/Delete/5
        public ActionResult Delete(int id)
        {
            var hotel = _context.Hotels.Include(h => h.Category).FirstOrDefault(h => h.Id == id);

            return View(hotel);
        }

        // POST: HotelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var hotel = _context.Hotels.Find(id);
                _context.Hotels.Remove(hotel);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
