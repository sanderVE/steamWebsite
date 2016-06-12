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

        public ActionResult Review(int id)
        {
            return View();
        }

        public ActionResult AddToCart(int id)
        {
            DatabaseModel database = new DatabaseModel();
            int cartid = database.GetCart((int)Session["GebruikerID"]);
            database.AddToCart(cartid, id);
            return View("index");
        }

        public ActionResult Cart()
        {
            DatabaseModel database = new DatabaseModel();
            //database.RemoveFromCart();
            List<GameModel> games = database.GetGamesCart((int)Session["GebruikerID"]);
            return View(games);
        }

        public ActionResult Remove(int id)
        {
            DatabaseModel database = new DatabaseModel();
            int cartid = database.GetCart((int)Session["GebruikerID"]);
            database.RemoveFromCart(cartid);
            List<GameModel> games = database.GetGamesCart((int)Session["GebruikerID"]);
            return View(games);
        }

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