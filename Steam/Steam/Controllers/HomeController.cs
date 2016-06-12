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

        //homepage
        public ActionResult Index()
        {
            return View();
        }

        //bekijk de store
        public ActionResult Games()
        {
            DatabaseModel database = new DatabaseModel();
            List<GameModel> games = database.GetGames();
            return View(games);
        }

        //bekijk game
        public ActionResult Game(int id)
        {
            DatabaseModel database = new DatabaseModel();
            GameModel game = database.GetGame(id);
            return View(game);
        }

        //bekijk de library
        public ActionResult Library()
        {
            DatabaseModel database = new DatabaseModel();
            List<GameModel> games = database.GetGamesUser((int)Session["GebruikerID"]);
            return View(games);
        }

        //bekijk review
        public ActionResult Review(int id)
        {
            return View();
        }

        //voeg iets ttoe aan winkelwagen
        public ActionResult AddToCart(int id)
        {
            DatabaseModel database = new DatabaseModel();
            int cartid = database.GetCart((int)Session["GebruikerID"]);
            database.AddToCart(cartid, id);
            return View("index");
        }

        //laat winkelwagen zien
        public ActionResult Cart()
        {
            DatabaseModel database = new DatabaseModel();
            List<GameModel> games = database.GetGamesCart((int)Session["GebruikerID"]);
            return View(games);
        }

        //haal game uit winkelwagen
        public ActionResult Remove(int id)
        {
            DatabaseModel database = new DatabaseModel();
            int cartid = database.GetCart((int)Session["GebruikerID"]);
            database.RemoveFromCart(cartid);
            List<GameModel> games = database.GetGamesCart((int)Session["GebruikerID"]);
            return View(games);
        }

        //koop alle games in winkelwagen
        public ActionResult Buy()
        {
            DatabaseModel database = new DatabaseModel();
            int cartid = database.GetCart((int)Session["GebruikerID"]);
            List<GameModel> games = database.GetGamesCart((int)Session["GebruikerID"]);
            foreach (GameModel g in games)
            {
                database.BuyGames(g.id, (int)Session["GebruikerID"]);
            }
            database.RemoveFromCart(cartid);
            return View("Library");
        }
    }
}