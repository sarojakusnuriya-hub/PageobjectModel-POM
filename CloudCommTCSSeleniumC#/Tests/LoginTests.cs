using Allure.NUnit;
using CloudCommTCSSeleniumC_.Pages;
using CloudCommTCSSeleniumC_.TestDataDir;
using CloudCommTCSSeleniumC_.Tests;
using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using CloudCommTCSSeleniumC_.Utilities;




namespace CloudCommTCSSeleniumC_.TestDataDir
{

    [AllureNUnit]
    [Parallelizable(ParallelScope.All)]
    public  class LoginTests:BaseTest
    {
      
            [Test, TestCaseSource(typeof(ExcelHelper), nameof(ExcelHelper.GetLoginData))]
            public void VerifyLogin(string username, string password)
            {
            Driver.Navigate().GoToUrl(
                    "https://www.saucedemo.com/");

                LoginPage loginPage = new LoginPage(Driver);

                loginPage.Login(username, password);

            Assert.That(Driver.Url.Contains("inventory.html"), Is.True);

        }
    }
}
