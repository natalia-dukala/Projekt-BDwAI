using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reservations.Models;

namespace Reservations.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ReservationsDbContext _context;
        public CategoryController(ReservationsDbContext context)
        {
            _context = context;
        }

        // GET: CategoryController
        public ActionResult Index()
        {
            var categories = _context.Categories.ToList();
            
            return View(categories);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            try
            {
                _context.Categories.Add(category);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(category);
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var category = _context.Categories.Find(id);

            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category category)
        {
            try
            {
                _context.Categories.Update(category);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(category);
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var category = _context.Categories.Find(id);

            return View(category);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var category = _context.Categories.Find(id);
            try
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(category);
            }
        }
    }
}
