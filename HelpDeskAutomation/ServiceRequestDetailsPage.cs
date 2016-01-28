using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace HelpDeskAutomation
{
    public class ServiceRequestDetailsPage
    {
        public ServiceRequestDetailsPage()
        {
            PageFactory.InitElements(Driver.Instance, this);
        }

        [FindsBy(How = How.XPath, Using = ".//*[@id='kreipiniai-grid']/table/tbody/tr[1]/td[7]/a")]
        public IWebElement NewestServiceRequestLink { get; set; }

        public object Title
        {
            get
            {
                var h2s = Driver.Instance.FindElements(By.TagName("h2"));
                var tempTitle = string.Empty;
                if (h2s.Count > 0)
                {
                    tempTitle = h2s[0].Text;
                    
                    string title = tempTitle.Trim().Remove(0, "Kreipinys \"".Length);
                    title = title.TrimEnd(new char[] {'\"'});
                    return title;
                }

                return string.Empty;
            }
        }

        public void GoToNewestServiceRequestPage()
        {
            NewestServiceRequestLink.Click();
        }
    }
}
