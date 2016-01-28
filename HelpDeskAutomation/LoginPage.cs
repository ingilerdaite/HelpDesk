using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;

namespace HelpDeskAutomation
{
    public class LoginPage
    {
        public LoginPage()
        {
            PageFactory.InitElements(Driver.Instance, this);
        }

        [FindsBy(How = How.Id, Using = "LoginForm_username")]
        public IWebElement UserNameInput { get; set; }

        [FindsBy(How = How.Id, Using = "LoginForm_password")]
        public IWebElement PasswordInput { get; set; }

        [FindsBy(How = How.ClassName, Using = "btn-lg")]
        public IWebElement LoginButton { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/header/div/nav/div[2]/ul[2]/li/a")]
        public IWebElement SettingsButton { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/header/div/nav/div[2]/ul[2]/li/ul/li[4]/a")]
        public IWebElement LogoutButton { get; set; }

        public void GoToSite()
        {
            Driver.Instance.Navigate().GoToUrl("http://hd.aursad.eu/site/");
        }

        public void GoToStaff()
        {
            Driver.Instance.Navigate().GoToUrl("http://hd.aursad.eu/site/staff/");
        }

        public LoginPage LoginAs(string userName)
        {
            UserNameInput.SendKeys(userName);
            return this;
        }

        public LoginPage WithPassword(string passwd)
        {
            PasswordInput.SendKeys(passwd);
            return this;
        }

        public void Login()
        {
            LoginButton.Click();
        }

        public void Logout()
        {
            SettingsButton.Click();
            LogoutButton.Click();
        }
    }
}
