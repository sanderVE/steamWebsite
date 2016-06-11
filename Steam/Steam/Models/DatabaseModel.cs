using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Steam.Models
{
    public class DatabaseModel
    {
        static string Connectionstring = @"Data Source = (DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = fhictora01.fhict.local)(PORT = 1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = fhictora))); User ID = dbi353331; PASSWORD =Wachtwoord123;";

        OracleConnection conn = new OracleConnection(Connectionstring);

        public List<GameModel> GetGames()
        {

            List<GameModel> ReturnData = new List<GameModel>();
            using (OracleConnection conn = new OracleConnection(Connectionstring))
            {
                using (OracleCommand command = new OracleCommand("SELECT *" + " FROM " + "Game", conn))
                {
                    command.Connection.Open();
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            int prize = reader.GetInt32(2);
                            DateTime releaseDate = reader.GetDateTime(3);
                            GameModel game = new GameModel(id, name,prize, releaseDate);
                            ReturnData.Add(game);
                        }
                        return ReturnData;
                    }
                }
            }
        }

        internal List<GameModel> GetGamesUser(int id)
        {
            List<GameModel> ReturnData = new List<GameModel>();
            using (OracleConnection conn = new OracleConnection(Connectionstring))
            {
                using (OracleCommand command = new OracleCommand("SELECT *" + " FROM " + "Game WHERE gameid IN(SELECT gameid FROM GEBRUIKERGAME WHERE gebruikerid = " + id + ")", conn))//IN(SELECT gameID FROM GEBRUIKERGAME WHERE gebruikerID" + id + ")"
                {
                    command.Connection.Open();
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int iduser = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            int prize = reader.GetInt32(2);
                            DateTime releaseDate = reader.GetDateTime(3);
                            GameModel game = new GameModel(iduser, name, prize, releaseDate);
                            ReturnData.Add(game);
                        }
                        return ReturnData;
                    }
                }
            }
        }

        public GameModel GetGame(int id)
        {
            GameModel ReturnData = new GameModel();
            using (OracleConnection conn = new OracleConnection(Connectionstring))
            {
                using (OracleCommand command = new OracleCommand("SELECT * FROM Game WHERE gameID =" + id, conn))
                {
                    command.Connection.Open();
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int gameID = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            int prize = reader.GetInt32(2);
                            DateTime releaseDate = reader.GetDateTime(3);
                            GameModel game = new GameModel(gameID, name, prize, releaseDate);
                            ReturnData = game;
                        }
                        return ReturnData;
                    }
                }
            }
        }

        public string GetUserPassword(string naam)
        {
            string ReturnData = null;
            using (OracleConnection conn = new OracleConnection(Connectionstring))
            {
                using (OracleCommand command = new OracleCommand("SELECT wachtwoord FROM GEBRUIKER WHERE gebruikernaam = :naam", conn))
                {
                    command.Parameters.Add("naam", naam);
                    command.Connection.Open();
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string password = reader.GetString(0);
                            ReturnData = password;
                        }
                        return ReturnData;
                    }
                }
            }
        }

        public AccountModel GetUser(string naam)
        {
            AccountModel ReturnData;
            using (OracleConnection conn = new OracleConnection(Connectionstring))
            {
                using (OracleCommand command = new OracleCommand("SELECT gebruikernaam, wachtwoord, emailadres, gebruikerid FROM GEBRUIKER WHERE gebruikernaam = :naam", conn))
                {
                    command.Parameters.Add("naam", naam);
                    command.Connection.Open();
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        string gebruikersnaam = "";
                        string wachtwoord = "";
                        string emailadres = "";
                        int id = 0;
                        while (reader.Read())
                        {
                            gebruikersnaam = reader.GetString(0);
                            wachtwoord = reader.GetString(1);
                            emailadres = reader.GetString(2);
                            id = reader.GetInt32(3);
                        }
                        ReturnData = new AccountModel(gebruikersnaam, wachtwoord, emailadres, id);
                        return ReturnData;
                    }
                }
            }
        }

        public void InsertPerson(string username, string password, string email)
        {
            RegisterViewModel user = new RegisterViewModel();
            using (OracleConnection conn = new OracleConnection(Connectionstring))
            {
                using (OracleCommand command = new OracleCommand("INSERT INTO GEBRUIKER(GEBRUIKERNAAM, WACHTWOORD, EMAILADRES) VALUES(:gebruikersnaam,:wachtwoord,:email)", conn))
                {
                    command.Parameters.Add("gebruikersnaam", username);
                    command.Parameters.Add("wachtwoord", password);
                    command.Parameters.Add("email", email);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


    }
}