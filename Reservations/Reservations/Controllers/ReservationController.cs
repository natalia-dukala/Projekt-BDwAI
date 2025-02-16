using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reservations.Models;

namespace Reservations.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ReservationsDbContext _context;
        private readonly UserManager<User> _userManager;

        public ReservationController(ReservationsDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: ReservationController
        public ActionResult Index()
        {
            var reservations = _context.Reservations.Include(r => r.Room).Include(r => r.User).ToList();

            return View(reservations);
        }

        // GET: ReservationController/Create
        [Authorize(Roles = "User")]
        public ActionResult Create(int roomId)
        {
            var room = _context.Rooms.Find(roomId);
            var reservation = new Reservation { RoomId = roomId, Room = room};

            return View(reservation);
        }

        // POST: ReservationController/Create
        [HttpPost]
        [Authorize(Roles = "User")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Reservation reservation)
        {
            var user = _userManager.GetUserAsync(User).Result;
            var room = _context.Rooms.Find(reservation.RoomId);

            reservation.FirstName = user.FirstName;
            reservation.LastName = user.LastName;
            reservation.UserId = user.Id;
            room.IsRented = true;

            _context.Reservations.Add(reservation);
            _context.SaveChanges();

            return RedirectToAction("Details", "Hotel", new { id = room.HotelId });
        }

        [Authorize(Roles = "User")]
        public ActionResult Delete(int roomId)
        {
            var user = _userManager.GetUserAsync(User).Result;
            var reservation = _context.Reservations.FirstOrDefault(r => r.RoomId == roomId && r.UserId == user.Id);
            var room = _context.Rooms.Find(roomId);
            room.IsRented = false;

            _context.Reservations.Remove(reservation);
            _context.SaveChanges();

            return RedirectToAction("Details", "Hotel", new { id = room?.HotelId });
        }
    }
}
