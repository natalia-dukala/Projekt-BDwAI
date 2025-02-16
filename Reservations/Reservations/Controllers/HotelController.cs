using Microsoft.AspNetCore.Authorization;
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
            var hotels = _context.Hotels.Include(h => h.Category).ToList();

            return View(hotels);
        }

        // GET: HotelController/Details/5
        public ActionResult Details(int id)
        {
            var hotel = _context.Hotels.Include(h => h.Category).Include(h => h.Rooms).FirstOrDefault(h => h.Id == id);

            return View(hotel);
        }

        // GET: HotelController/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name");
           
            return View();
        }


        // POST: HotelController/Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        // GET: HotelController/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var hotel = _context.Hotels.FirstOrDefault(b => b.Id == id);
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", hotel.CategoryId);

            return View(hotel);

        }

        // POST: HotelController/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Hotel hotel)
        {
            _context.Hotels.Update(hotel);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        // GET: HotelController/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var hotel = _context.Hotels.Include(h => h.Category).FirstOrDefault(h => h.Id == id);

            return View(hotel);
        }


        // POST: HotelController/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Hotel hotel)
        {
            var hotelInDb = _context.Hotels.Find(id);

            _context.Hotels.Remove(hotelInDb);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}
