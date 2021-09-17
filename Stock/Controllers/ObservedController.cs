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
            }
            return View(objList);
        }

        //Get - Create
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
    }
}
