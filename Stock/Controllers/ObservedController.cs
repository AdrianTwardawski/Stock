using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Stock.Data;
using Stock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stock.Controllers
{
    public class ObservedController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ObservedController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Observed> objList = _db.Observed;
            foreach (var obj in objList)
            {
                obj.Category = _db.Category.FirstOrDefault(u => u.Id == obj.CategoryId);


                var KursConv = float.Parse(obj.Category.Kurs.Replace(",", "."));
                var KursRound = MathF.Round(KursConv, 2);
                obj.Zysk = (KursRound - obj.CenaZakupu)*obj.LiczbaAkcji;


            }
            return View(objList);
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
