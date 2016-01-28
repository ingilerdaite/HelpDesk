using HelpDeskAutomation;

namespace HelpDeskTests
{
    public static class Helper
    {
        public static void Login()
        {
            LoginPage loginPage = new LoginPage();
            loginPage.GoToSite();
            loginPage.LoginAs("K0001_2").WithPassword("7WwNYocKez").Login();
        }
    }
}
