using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Steam.Models
{
    public class AccountModel
    {
        public int id;
        public string name;
        public string password;
        public string email;
        public string country;
        public List<GameModel> games;
        public List<ReviewModel> reviews;
        public List<AchievementModel> achievements;

        public AccountModel(string name, string password, string email, int id)
        {
            games = new List<GameModel>();
            this.name = name;
            this.password = password;
            this.email = email;
            this.id = id;
        }

        public void ChangePassword(string password)
        {

        }

        public void ChangeEmail(string email)
        {

        }
        public void ChangeCountry(string country)
        {

        }

        public void delete()
        {

        }

        public List<GameModel> showGames()
        {
            return games;
        }
    }
}