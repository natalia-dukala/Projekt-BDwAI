using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Reservations.Models;

namespace Reservations.Controllers
{
    public class RoomController : Controller
    {
        private readonly ReservationsDbContext _context;
        public RoomController(ReservationsDbContext context)
        {
            _context = context;
        }

        // NIEPOTRZEBNE
        // GET: RoomController
        public ActionResult Index(int hotelId)
        {
            var rooms = _context.Rooms.Where(r => r.HotelId == hotelId).Include(r => r.Hotel).ToList();
            return View(rooms);
        }

        // GET: RoomController/Details/5
        public ActionResult Details(int id)
        {
            var room = _context.Rooms.Include(r => r.Hotel).FirstOrDefault(r => r.Id == id);

            return View();
        }

        // GET: RoomController/Create
        public ActionResult Create(int hotelId)
        {
            var room = new Room { HotelId = hotelId, Available = true };

            return View(room);
        }

        // POST: RoomController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Room room)
        {
            if (!room.Available)
            {
                room.Available = true;
            }

            try
            {
                _context.Rooms.Add(room);
                _context.SaveChanges();

                return RedirectToAction("Details", "Hotel", new { id = room.HotelId });
            }
            catch
            {
                return View(room);
            }
        }

        // GET: RoomController/Edit/5
        public ActionResult Edit(int id)
        {
            var room = _context.Rooms.Find(id);
            ViewBag.Room = room;

            return View(room);
        }

        // POST: RoomController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Room room)
        {
            try
            {
                _context.Rooms.Update(room);
                _context.SaveChanges();

                return RedirectToAction("Details", "Hotel", new { id = room.HotelId });
            }
            catch
            {
                return View(room);
            }
        }

        // GET: RoomController/Delete/5
        public ActionResult Delete(int id)
        {
            var room = _context.Rooms.Find(id);

            return View(room);
        }

        // POST: RoomController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var room = _context.Rooms.Find(id);
            try
            {
                _context.Rooms.Remove(room);
                _context.SaveChanges();

                return RedirectToAction("Details", "Hotel", new { id = room.HotelId });
            }
            catch
            {
                return View(room);
            }
        }
    }
}
