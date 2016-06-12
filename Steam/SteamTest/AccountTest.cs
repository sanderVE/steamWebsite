using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Steam.Models;

namespace SteamTest
{
    [TestClass]
    public class AccountTest
    {
        [TestMethod]
        public void Accounttest()
        {
            AccountModel am = new AccountModel("username", "password", "email", 1);
            Assert.AreEqual("username", am.name);
            Assert.AreEqual("password", am.password);
            Assert.AreEqual("email", am.email);
            Assert.AreEqual(1, am.id);
        }
    }
}
