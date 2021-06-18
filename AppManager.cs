using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ToDoIstTests
{
    public class AppManager
    {
        protected IWebDriver driver;
        protected StringBuilder verificationErrors;
        private string baseURL;
        private LoginHelper auth;
        private NavigationHelper navigate;
        private TaskHelper task;
        private static ThreadLocal<AppManager> app = new ThreadLocal<AppManager>();
        private AppManager()
        {
            var driverService = ChromeDriverService.CreateDefaultService(@"C:\distr");
            var options = new ChromeOptions();
            options.AddArgument("--disable-features=RendererCodeIntegrity");
            driver = new ChromeDriver(driverService, options);
            baseURL = Settings.BaseURL;
            verificationErrors = new StringBuilder();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            auth = new LoginHelper(this);
            navigate = new NavigationHelper(this, baseURL);
            task = new TaskHelper(this);
        }
        public static AppManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                AppManager newInstance = new AppManager();
                newInstance.Navigate.OpenHomePage();
                app.Value = newInstance;
            }
            return app.Value;
        }
        ~AppManager()
        {
            Stop();
        }
        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }
        public LoginHelper Auth
        {
            get
            {
                return auth;
            }
        }
        public NavigationHelper Navigate
        {
            get
            {
                return navigate;
            }
        }
        public TaskHelper Task
        {
            get
            {
                return task;
            }
        }
    }
}
