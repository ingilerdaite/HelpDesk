using HelpDeskAutomation;
using NUnit.Framework;

namespace HelpDeskTests
{
    [TestFixture]
    public class LoginTests
    {
        [OneTimeSetUp]
        public void Init()
        {
            Driver.Initialize();
        }

        [Test]
        public void SuccessfullAdminUserLoginTest()
        {
            LoginPage loginPage = new LoginPage();
            ServicRequestPage servicRequestPage  = new ServicRequestPage();
            loginPage.GoToStaff();
            loginPage.LoginAs("aurimas.sadauskas@gmail.com").WithPassword("test").Login();

            Assert.IsTrue(servicRequestPage.IsAt, "Failed to login.");

            if (servicRequestPage.IsAt)
            {
                loginPage.Logout();
            }
        }

        [Test]
        public void WrongAdminUserLoginTest()
        {
            LoginPage loginPage = new LoginPage();
            ServicRequestPage servicRequestPage = new ServicRequestPage();

            loginPage.GoToStaff();
            
            loginPage.LoginAs("aurimas.sadauskas@gmail.com").WithPassword("test1").Login();
            Assert.IsFalse(servicRequestPage.IsAt);

            loginPage.LoginAs("fsdagfds").WithPassword("blaaa").Login();
            Assert.IsFalse(servicRequestPage.IsAt);
        }

        [Test]
        public void SuccessfullRepresentativeUserLoginTest()
        {
            LoginPage loginPage = new LoginPage();
            ServicRequestPage servicRequestPage = new ServicRequestPage();
            loginPage.GoToSite();
            loginPage.LoginAs("K0001_2").WithPassword("7WwNYocKez").Login();

            Assert.IsTrue(servicRequestPage.IsAt, "Failed to login.");

            if (servicRequestPage.IsAt)
            {
                loginPage.Logout();
            }
        }

        [Test]
        public void WrongRepresentativeUserLoginTest()
        {
            LoginPage loginPage = new LoginPage();
            ServicRequestPage servicRequestPage = new ServicRequestPage();

            loginPage.GoToSite();
            loginPage.LoginAs("K0001_2").WithPassword("test").Login();
            Assert.IsFalse(servicRequestPage.IsAt);

            loginPage.LoginAs("aurimas.sadauskas@gmail.com").WithPassword("test").Login();
            Assert.IsFalse(servicRequestPage.IsAt);
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            Driver.Close();
        }
    }
}
