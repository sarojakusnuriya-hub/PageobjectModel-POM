using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudCommTCSSeleniumC_.Pages
{
    public  class LoginPage
    {

        IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        By username = By.Id("user-name");
        By password = By.Id("password");
        By loginBtn = By.Id("login-button");

        public void Login(string user, string pass)
        {
            driver.FindElement(username).SendKeys(user);
            driver.FindElement(password).SendKeys(pass);
            driver.FindElement(loginBtn).Click();

            Thread.Sleep(4000);


        }
    }
}
