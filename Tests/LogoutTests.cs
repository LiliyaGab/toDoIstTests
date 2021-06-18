using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ToDoIstTests
{
    public class LogoutTests : TestBase
    {
        [Test]
        public void LogoutTest()
        {
            AccountData user = new AccountData(Settings.Login, Settings.Password);
            app.Auth.Login(user);
            app.Auth.Logout();
            Assert.IsFalse(app.Auth.IsLoggedIn(user.Username));
        }
    }
}
