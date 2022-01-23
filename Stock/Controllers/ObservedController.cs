using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Stock.Data;
using Stock.Models;
using Stock.Models.ViewModels;
using Stock.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stock.Controllers
{
    public class ObservedController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IObservedService _service;

        public ObservedController(ApplicationDbContext db, IObservedService service)
        {
            _db = db;
            _service = service;
        }

        public IActionResult Index()
        {
            var userStocks = _service.GetUserStocks();
            return View(userStocks);
        }

        //GET - Create
        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> TypeDropDown = _db.Category.Select(i => new SelectListItem
            {
                Text = i.Walor,
                Value = i.Id.ToString()
            });
            ViewBag.TypeDropDown = TypeDropDown;
            return View();
        }

        //POST - Create
        [HttpPost]
        public IActionResult CreatePost(Observed observed)
        {         

            if (ModelState.IsValid)
            {
                _db.Add(observed);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(observed);
        }

        //GET - Delete
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NoContent();
            }
            var obj = _db.Observed.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST - Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Observed.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Observed.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET - Update
        [HttpGet]
        public IActionResult Update(int? id)
        {

            IEnumerable<SelectListItem> TypeDropDown = _db.Category.Select(i => new SelectListItem
            {
                Text = i.Walor,
                Value = i.Id.ToString()
            });
            ViewBag.TypeDropDown = TypeDropDown;


            if (id == null || id == 0)
            {
                return NoContent();
            }
            var obj = _db.Observed.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST - Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Observed observed)
        {
            if (ModelState.IsValid)
            {
                _db.Observed.Update(observed);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(observed);
        }
    }
}
