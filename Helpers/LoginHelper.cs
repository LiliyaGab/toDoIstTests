using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoIstTests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(AppManager manager) : base(manager)
        { }
        public void Login(AccountData user)
        {
            if (IsLoggedIn())
            {
                Logout();
            }
            FillTheField(LoginPage.UserTextField, user.Username);
            FillTheField(LoginPage.PasswordTextField, user.Password);
            Click(LoginPage.SubmitLoginButton);
        }
        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(StartPage.SettingsIcon).Click();
                driver.FindElement(StartPage.LogoutButton).Click();
            }
                
        }
        public bool IsLoggedIn()
        {
            if (IsElementPresent(StartPage.SettingsIcon))
                return true;
            else return false;
        }
        public bool IsLoggedIn(string username)
        {
            if (IsLoggedIn())
            {
                manager.Navigate.OpenSettingsPage();
                string email = driver.FindElement(SettingsPage.EmailFiled).Text;
                manager.Navigate.CloseSettingsPage();
                if (email == username)
                    return true;
            }
            return false;
        }
    }
}
