﻿using Microsoft.AspNetCore.Mvc;
using Stock.Data;
using Stock.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stock.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public AccountController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

    
        public IActionResult Login()
        {
            return View();
        }

     
        public IActionResult Register()
        {
            return View();
        }
    }
}