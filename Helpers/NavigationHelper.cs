using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoIstTests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(AppManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }
        public void OpenHomePage() => driver.Navigate().GoToUrl(baseURL + "/users/showlogin");
        public void OpenSettingsPage()
        {
            driver.FindElement(StartPage.SettingsIcon).Click();
            driver.FindElement(StartPage.SettingsButton).Click();
        }
        public void CloseSettingsPage()
        {
            driver.FindElement(SettingsPage.CloseLink).Click();
        }
    }
}
