﻿using OpenQA.Selenium;
using SwagProject.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagProject.Page
{
    public class LoginPage
    {
        private IWebDriver driver = WebDrivers.Instance;
        public IWebElement Username => driver.FindElement(By.Id("user-name"));
        public IWebElement Password => driver.FindElement(By.Id("password"));
        public IWebElement LoginButton => driver.FindElement(By.Id("login-button"));

        public void LoginOnPage(string name, string pass)
        {
            Username.SendKeys(name);
            Password.SendKeys(pass);
            LoginButton.Submit();
        }
    }
}
