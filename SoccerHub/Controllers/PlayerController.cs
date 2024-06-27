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
    public class PlayerController : Controller
    {
        private readonly IPlayerRepository _repo;

        public PlayerController(IPlayerRepository repo)
        {
            _repo = repo;
        }


        public IActionResult Index()
        {
            var players = _repo.GetPlayers();
            return View(players);
        }
        public IActionResult ViewPlayer(int id)
        {
            var player = _repo.GetPlayer(id);
            return View(player);
        }
        public IActionResult InsertPlayer()
        {
            var player = _repo.AssignPosition();
            return View(player);
        }
        public IActionResult InsertPlayerToDatabase(Player playerToInsert)
        {
            _repo.InsertPlayer(playerToInsert);
            return RedirectToAction("Index");
        }

        public IActionResult UpdatePlayer(int playerid)
        {
            Player player = _repo.GetPlayer(playerid);
            if (player == null)
            {
                return View("PlayerNotFound");
            }
            return View(player);
        }

        public IActionResult UpdatePlayerToDatabase(Player player)
        {
            _repo.UpdatePlayer(player);

            return RedirectToAction("ViewPlayer", new { id = player.PlayerID });
        }

        public IActionResult DeletePlayer(Player player)
        {
            _repo.DeletePlayer(player);
            return RedirectToAction("Index");
        }

    }

}

