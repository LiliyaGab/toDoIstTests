using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ToDoIstTests
{
    public class HelperBase
    {
        protected IWebDriver driver;
        protected bool acceptNextAlert = true;
        protected WebDriverWait wait;
        protected AppManager manager;
        protected LoginPage loginPage;
        protected StartPage startPage;
        protected SettingsPage settingsPage;
        public HelperBase(AppManager manager)
        {
            this.manager = manager;
            this.driver = manager.Driver;
        }
        public void WaitUntilVisible(By locator)
        {
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Message = "Element with locator '" + locator + "' was not visible in 10 seconds";
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }
        public void WaitUntilClickable(By locator)
        {
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Message = "Element with locator '" + locator + "'was not visible in 10 seconds";
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
        }
        public static Func<IWebDriver, IWebElement> Condition(By locator)
        {
            return (driver) =>
            {
                var element = driver.FindElements(locator).FirstOrDefault();
                return element != null && element.Displayed && element.Enabled ? element : null;
            };
        }
        public void Click(By locator)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(15)).Until(Condition(locator)).Click();
        }
        public void FillTheField(By locator, string text)
        {
            driver.FindElement(locator).Click();
            //driver.FindElement(locator).Clear();
            driver.FindElement(locator).SendKeys(text);
        }
        protected LoginPage LoginPage
        {
            get
            {
                if (loginPage == null)
                {
                    loginPage = new LoginPage();
                }
                return loginPage;
            }
        }
        protected StartPage StartPage
        {
            get
            {
                if (startPage == null)
                {
                    startPage = new StartPage();
                }
                return startPage;
            }
        }
        protected SettingsPage SettingsPage
        {
            get
            {
                if (settingsPage == null)
                {
                    settingsPage = new SettingsPage();
                }
                return settingsPage;
            }
        }
        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        public string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
