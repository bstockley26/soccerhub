﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoccerHub.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SoccerHub.Controllers
{
    public class RecruitController : Controller
    {
        private readonly IRecruitRepository _repo;

        public RecruitController(IRecruitRepository repo)
        {
            _repo = repo;
        }


        public IActionResult Index()
        {
            var recruits = _repo.GetRecruits();
            return View(recruits);
        }
    }
}

