using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace CloudCommTCSSeleniumC_.Drivers
{

    public class DriverFactory
    {
        private static ThreadLocal<IWebDriver> driver =
          new ThreadLocal<IWebDriver>();

        public static void InitDriver()
        {
            new DriverManager()
                .SetUpDriver(new ChromeConfig());

            ChromeOptions options =
                new ChromeOptions();

            options.AddArgument("--start-maximized");

            driver.Value =
                new ChromeDriver(options);
        }

        public static IWebDriver GetDriver()
        {
            return driver.Value;
        }

        public static void QuitDriver()
        {
            if (driver.Value != null)
            {
                driver.Value.Quit();
                driver.Value.Dispose();

                driver.Value = null;
            }
        }
    }
}
