using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudCommTCSSeleniumC_.Utilities
{
    public class ScreenshotHelper
    {

        public static void TakeScreenshot(
             IWebDriver driver)
        {
            if (driver == null)
            {
                return;
            }

            string folder =
                Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "Screenshots");

            Directory.CreateDirectory(folder);

            string fileName =
                $"Failure_{DateTime.Now:yyyyMMddHHmmss}.png";

            string path =
                Path.Combine(folder, fileName);

            Screenshot screenshot =
                ((ITakesScreenshot)driver)
                .GetScreenshot();

            screenshot.SaveAsFile(path);
        }
    }
}
