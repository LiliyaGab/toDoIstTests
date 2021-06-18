using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ToDoIstTests
{
    public class LoginPage
    {
        public By UserTextField { get { return By.Name("email"); } }
        public By PasswordTextField { get { return By.Name("password"); } }
        public By SubmitLoginButton { get { return By.XPath("//button[contains(@class,'submit_btn')]"); } }
    }
}
