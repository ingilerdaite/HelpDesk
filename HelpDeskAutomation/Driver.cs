using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace HelpDeskAutomation
{
    public class Driver
    {
        public static IWebDriver Instance { get; set; }

        public static void Initialize()
        {
            Instance = new RemoteWebDriver(new Uri("http://127.0.0.1:4444/wd/hub"), DesiredCapabilities.Firefox());
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
        }

        public static void Close()
        {
            Driver.Instance.Close();
        }
    }
}
