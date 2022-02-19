using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Stock.Data;
using Stock.Models;
using Stock.Models.ViewModels;
using Stock.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Stock.Controllers
{
    public class ObservedController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IObservedService _service;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ObservedController(ApplicationDbContext db, IObservedService service, SignInManager<ApplicationUser> signInManager)
        {
            _db = db;
            _service = service;
            _signInManager = signInManager;
        }

        public  IActionResult Index()
        {

            //if(User LogedIn)           
            if (User.Identity.IsAuthenticated)
            {
                var userStocks = _service.GetUserStocks();
                userStocks =  _db.Observed
                                  .Where(a => a.ApplicationUser.Id == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value)
                                 .ToList();
                 
                return View(userStocks);
            }
            return RedirectToAction("Login", "Account");
        }

        //GET - Create
        [HttpGet]
        public IActionResult Create()
        {
            var TypeDropDown = _service.GetTypeDropDown();
            ViewBag.TypeDropDown = TypeDropDown;
            return View();
        }

        //POST - Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ObservedVM model)
        {         
            if (ModelState.IsValid)
            {
                //_service.Create(model);
                var dbStock = _db.Market.FirstOrDefault(s => s.Id == model.MarketId);
                var observed = new Observed
                {
                    MarketId = model.MarketId,
                    NumberOfActions = model.NumberOfActions,
                    PurchasePrice = model.PurchasePrice,
                    Stock = dbStock.Stock,
                    Profit = model.NumberOfActions * (model.PurchasePrice - dbStock.Price),
                    ApplicationUserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value
                };

                _db.Observed.Add(observed);
                _db.SaveChanges();               
                return RedirectToAction("Index");
            }
            return View();
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
            var obj = _service.GetById(id);
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

            var TypeDropDown = _service.GetTypeDropDown();
            ViewBag.TypeDropDown = TypeDropDown;


            if (id == null || id == 0)
            {
                return NoContent();
            }
            var obj = _service.GetById(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST - Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ObservedVM model)
        {
            if (ModelState.IsValid)
            {
                _service.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}