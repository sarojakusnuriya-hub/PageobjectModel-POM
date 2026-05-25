using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
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
                .SetUpDriver(new FirefoxConfig());
 
           FirefoxOptions options = new FirefoxOptions();
 
            options.AddArgument("--start-maximized");
 
            options.AddArgument("--start-maximized");
            options.AddArgument("--headless=new");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");

            driver.Value =
                new FirefoxDriver(options);
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
