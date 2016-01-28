using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace HelpDeskAutomation
{
    public class ServicRequestPage
    {
        public ServicRequestPage()
        {
            PageFactory.InitElements(Driver.Instance, this);
        }

        [FindsBy(How = How.Id, Using = "paieska")]
        public IWebElement SearchInput { get; set; }

        [FindsBy(How = How.Id, Using = "kreipiniai-grid")]
        public IWebElement ServiceRequestGrid { get; set; }

        public bool IsAt
        {
            get
            {
                var IsOnServiceRequestPage = false;
                var HasSearchField = false;
                var PageHasServiceRequestTable = false;

                try
                {
                    var h2s = Driver.Instance.FindElements(By.TagName("h2"));
                    if (h2s.Count > 0)
                    {
                        IsOnServiceRequestPage = h2s[0].Text == "Kreipiniai";
                    }

                    //var searchInput = Driver.Instance.FindElement(By.Id("paieska"));
                    if (SearchInput != null)
                    {
                        HasSearchField = true;
                    }

                    //var serviceRequestGrid = Driver.Instance.FindElement(By.Id("kreipiniai-grid"));
                    if (ServiceRequestGrid != null)
                    {
                        PageHasServiceRequestTable = true;
                    }
                }
                catch (NoSuchElementException ex)
                {
                    return false;
                }
                

                return IsOnServiceRequestPage && HasSearchField && PageHasServiceRequestTable;
            }
        }

        public void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl("http://hd.aursad.eu/site/kreipiniai");
        }
    }
}
