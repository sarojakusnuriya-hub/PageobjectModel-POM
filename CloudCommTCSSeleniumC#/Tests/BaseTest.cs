using Allure.Net.Commons;
using Allure.Net.Commons;
using CloudCommTCSSeleniumC_.Drivers;
using CloudCommTCSSeleniumC_.Utilities;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudCommTCSSeleniumC_.Tests
{
    public  class BaseTest
    {
        // protected IWebDriver driver;

        protected IWebDriver Driver =>
             DriverFactory.GetDriver();

        [SetUp]
        public void Setup()
        {
            DriverFactory.InitDriver();
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                if (Driver != null &&
                    TestContext.CurrentContext.Result
                    .Outcome.Status ==
                    TestStatus.Failed)
                {
                    ScreenshotHelper
                        .TakeScreenshot(Driver);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"TearDown Error: {ex.Message}");
            }
            finally
            {
                DriverFactory.QuitDriver();
            }
        }
    }
}

