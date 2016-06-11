using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Steam.Models
{
    public class StoreModel
    {
        public List<GameModel> games = new List<GameModel>();

        public StoreModel()
        {
            //OracleDatabaseModel database = new OracleDatabaseModel();
            //GameModel g = new GameModel();
            //List<string> gamestrings = database.GetGames();
            //foreach (string s in gamestrings)
            //{
            //    g.title = gamestrings[0];
            //    g.prijs = Convert.ToInt32(gamestrings[1]);
            //    g.releaseDate = Convert.ToDateTime(gamestrings[2]);
            //    gamestrings.RemoveAt(0);
            //    gamestrings.RemoveAt(0);
            //    gamestrings.RemoveAt(0);
            //}
        }
    }
}