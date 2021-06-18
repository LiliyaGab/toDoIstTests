using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ToDoIstTests
{
    public class SettingsPage
    {
        public By CloseLink { get { return By.XPath("//a[@class='close_link fixed_pos']"); } }
        public By EmailFiled { get { return By.XPath("//div[@id='login_info']/dl/dd/span"); } }
    }
}
