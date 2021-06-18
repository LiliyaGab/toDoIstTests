using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ToDoIstTests
{
    public class StartPage
    {
        public By SettingsIcon { get { return By.XPath("//button[@aria-owns='setting_menu']");  } }
        public By LogoutButton { get { return By.XPath("//div[text()='Log out']"); } }
        public By NewTaskButton { get { return By.XPath("//button[@class='plus_add_button']"); } }
        public By TaskField { get { return By.XPath("//div[contains(@class,'item_editor_input')]/descendant::div[6]"); } }
        public By SubmitButton { get { return By.XPath("//button[@type='submit']"); } }
        public By TaskListItem { get { return By.XPath("//div[@class='task_content']/span"); } }
        public By SettingsButton { get { return By.XPath("//div[text()='Settings']"); } }
        
    }
}
