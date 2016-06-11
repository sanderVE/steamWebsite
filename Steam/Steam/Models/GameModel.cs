using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Steam.Models
{
    public class GameModel
    {
        public int id;
        public string title;
        public List<string> genre;
        public List<string> developer;
        public List<string> publisher;
        public DateTime releaseDate;
        public int prijs;
        public List<string> besturingssysteem;
        public List<string> language;
        public List<ReviewModel> reviews;
        public int score;

        public GameModel()
        {
            genre = new List<string>();
            developer = new List<string>();
            publisher = new List<string>();
            besturingssysteem = new List<string>();
            language = new List<string>();
        }

        public GameModel(int id, string title, int prijs, DateTime releaseDate)
        {
            this.id = id;
            genre = new List<string>();
            developer = new List<string>();
            publisher = new List<string>();
            besturingssysteem = new List<string>();
            language = new List<string>();
            this.title = title;
            this.prijs = prijs;
            this.releaseDate = releaseDate;
        }

        public bool buy(AccountModel acc)
        {
            return true;
        }
    }
}