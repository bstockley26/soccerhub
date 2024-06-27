using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoccerHub.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SoccerHub.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly IScheduleRepository _repo;

        public ScheduleController(IScheduleRepository repo)
        {
            _repo = repo;
        }


        public IActionResult Index()
        {
            var schedule = _repo.GetAllGames();
            return View(schedule);
        }
    }
}

