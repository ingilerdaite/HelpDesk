using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace HelpDeskAutomation
{
    public class NewServiceRequestPage
    {
        public NewServiceRequestPage()
        {
            PageFactory.InitElements(Driver.Instance, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".modal-popup.pull-right.btn.btn-primary.btn-sm")]
        public IWebElement NewServiceRequestButton { get; set; }

        [FindsBy(How = How.Id, Using = "Kreipinys_kr_pavadinimas")]
        public IWebElement TitleInput { get; set; }

        [FindsBy(How = How.Id, Using = "Kreipinys_kr_aprasas")]
        public IWebElement BodyInput { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='kreipinio_informacija']/div[6]/div/button[1]")]
        public IWebElement CreateServiceRequestButton { get; set; }

        public void GoTo()
        {
            NewServiceRequestButton.Click();
        }

        public NewServiceRequestPage WithTitle(string title)
        {
            TitleInput.SendKeys(title);
            return this;
        }

        public NewServiceRequestPage WithService(string service)
        {
            SelectNewServiceRequestDropDownValue(1, service);
            return this;
        }

        public NewServiceRequestPage WithType(string type)
        {
            SelectNewServiceRequestDropDownValue(2, type);
            return this;
        }

        public NewServiceRequestPage WithBody(string body)
        {
            BodyInput.SendKeys(body);
            return this;
        }

        public NewServiceRequestPage WithOptionallyRelatedRequest(string relatedRequestTitle)
        {
            if (!string.IsNullOrWhiteSpace(relatedRequestTitle))
            {
                SelectNewServiceRequestDropDownValue(5, relatedRequestTitle);
            }

            return this;
        }

        public void Create()
        {
            CreateServiceRequestButton.Click();
        }

        private void SelectNewServiceRequestDropDownValue(int formRowId, string text)
        {
            var selectButtonXPath = string.Format(".//*[@id='kreipinio_informacija']/div[{0}]/div/div/button", formRowId);
            var serviceDropDownButton = (new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(2))).Until(ExpectedConditions.ElementIsVisible(By.XPath(selectButtonXPath)));

            serviceDropDownButton.Click();

            //Select item as a link by service title
            var selectedServiceItemXPath = string.Format(".//*[@id='kreipinio_informacija']/div[{0}]/div/div/div/ul/descendant::span[text()='{1}']", formRowId, text);
            var serviceItem = (new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(2))).Until(ExpectedConditions.ElementIsVisible(By.XPath(selectedServiceItemXPath)));

            serviceItem.Click();
        }
    }
}
