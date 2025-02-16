using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        // GET: RoomController/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create(int hotelId)
        {
            var room = new Room { HotelId = hotelId, IsRented = false };

            return View(room);
        }

        // POST: RoomController/Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();

            return RedirectToAction("Details", "Hotel", new { id = room.HotelId });
        }

        // GET: RoomController/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var room = _context.Rooms.Find(id);

            return View(room);
        }

        // POST: RoomController/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Room room)
        {
            _context.Rooms.Update(room);
            _context.SaveChanges();

            return RedirectToAction("Details", "Hotel", new { id = room.HotelId });
        }

        // GET: RoomController/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var room = _context.Rooms.Find(id);

            return View(room);
        }

        // POST: RoomController/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var room = _context.Rooms.Find(id);

            _context.Rooms.Remove(room);
            _context.SaveChanges();

            return RedirectToAction("Details", "Hotel", new { id = room.HotelId });
        }
    }
}
