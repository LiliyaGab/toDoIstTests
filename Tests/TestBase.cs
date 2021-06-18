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
    public class TestBase
    {
        protected AppManager app;

        [SetUp]
        public void SetupTest()
        {
            app = AppManager.GetInstance();
            app.Navigate.OpenHomePage();
        }
    }
}
