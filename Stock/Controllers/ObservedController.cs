using Microsoft.AspNetCore.Mvc;
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
            return View(objList);
        }

        //Get - Create
        [HttpGet]
        public IActionResult Create()
        {           
            return View();
        }
    }
}
