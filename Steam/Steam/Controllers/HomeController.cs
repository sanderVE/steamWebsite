using Steam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Steam.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Games()
        {
            DatabaseModel database = new DatabaseModel();
            List<GameModel> games = database.GetGames();
            return View(games);
        }

        public ActionResult Game(int id)
        {
            //int a = (int)Session["GebruikerID"];
            DatabaseModel database = new DatabaseModel();
            GameModel game = database.GetGame(id);
            return View(game);
        }

        public ActionResult Library()
        {
            DatabaseModel database = new DatabaseModel();
            List<GameModel> games = database.GetGamesUser((int)Session["GebruikerID"]);
            return View(games);
        }
    }
}