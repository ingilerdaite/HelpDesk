using System;
using HelpDeskAutomation;
using NUnit.Framework;

namespace HelpDeskTests
{
    [TestFixture]
    public class CreateServiceRequestTests
    {
        [OneTimeSetUp]
        public void Init()
        {
            Driver.Initialize();
        }

        [Test]
        public void Representative_User_Can_Create_Service_Request()
        {
            Helper.Login();
            NewServiceRequestPage newServiceRequestPage = new NewServiceRequestPage();
            ServicRequestPage servicRequestPage = new ServicRequestPage();
            ServiceRequestDetailsPage serviceRequestDetailsPage  = new ServiceRequestDetailsPage();
            newServiceRequestPage.GoTo();
            newServiceRequestPage
                .WithService("Virtualus serveris")
                .WithType("Incidentas")
                .WithTitle("This is New Service Request title")
                .WithBody("This is request body")
                .WithOptionallyRelatedRequest(string.Empty)
                .Create();
            servicRequestPage.GoTo();
            serviceRequestDetailsPage.GoToNewestServiceRequestPage();
            Assert.AreEqual(serviceRequestDetailsPage.Title, "This is New Service Request title", "Title did not match created service request");
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            Driver.Close();
        }
    }
}
