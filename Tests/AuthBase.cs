using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ToDoIstTests
{
    public class AuthBase : TestBase
    {
        [SetUp]
        public void Setup()
        {
            AccountData user = new AccountData(Settings.Login, Settings.Password);
            app = AppManager.GetInstance();
            app.Navigate.OpenHomePage();
            app.Auth.Login(user);
        }
    }
}
