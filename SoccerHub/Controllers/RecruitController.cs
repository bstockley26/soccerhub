using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoccerHub.Data;
using SoccerHub.Models;

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

        public IActionResult ViewRecruit(int id)
        {
            var recruit = _repo.GetRecruit(id);
            return View(recruit);
        }
        public IActionResult InsertRecruit()
        {
            var recruit = _repo.AssignPosition();
            return View(recruit);
        }
        public IActionResult InsertRecruitToDatabase(Recruit recruitToInsert)
        {
            _repo.InsertRecruit(recruitToInsert);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateRecruit(int id)
        {
            Recruit recruit = _repo.GetRecruit(id);
            if (recruit == null)
            {
                return View("RecruitNotFound");
            }
            return View(recruit);
        }

        public IActionResult UpdatePlayerToDatabase(Recruit recruit)
        {
            _repo.UpdateRecruit(recruit);

            return RedirectToAction("ViewRecruit", new { id = recruit.RecruitID });
        }

        public IActionResult DeleteRecruit(Recruit recruit)
        {
            _repo.DeleteRecruit(recruit);
            return RedirectToAction("Index");
        }
    }
}

