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
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidData()
        {
            AccountData user = new AccountData(Settings.Login, Settings.Password);
            app.Auth.Logout();
            app.Auth.Login(user);
            Assert.IsTrue(app.Auth.IsLoggedIn(user.Username));
        }

        [Test]
        public void LoginWithInvalidData()
        {
            AccountData user = new AccountData("user", "password");
            app.Auth.Logout();
            app.Auth.Login(user);
            Assert.IsFalse(app.Auth.IsLoggedIn(user.Username));
        }
    }
}
