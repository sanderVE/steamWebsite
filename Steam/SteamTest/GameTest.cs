using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Steam.Models;

namespace SteamTest
{
    [TestClass]
    public class GameTest
    {
        [TestMethod]
        public void Gametest()
        {
            GameModel gm = new GameModel(1, "game", 60, Convert.ToDateTime("5-5-2016"));
            Assert.AreEqual(1, gm.id);
            Assert.AreEqual("game", gm.title);
            Assert.AreEqual(60, gm.prijs);
            Assert.AreEqual("5-5-2016", gm.releaseDate);
        }
    }
}