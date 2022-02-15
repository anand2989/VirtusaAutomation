using AventStack.ExtentReports;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Virtusa_Assignment.Reporting;
using Virtusa_Assignment.Tests;

namespace Virtusa_Assignment.Pages.PageObjects
{
    [Binding]
    public class ProductAndServices : BaseTest
    {
        lLoydsBankHomePage _lLoydsBankHomePage;

        ExtentTest? _test;

        [Given(@"\[Invoke Browser]")]
        public void GivenInvokeBrowser()
        {
            setUp();

            BaseTestSetup();

            createParentNode(_envProperties["TestName"]);
        }

        [Given(@"\[Navigate to LLoyds Bank Application]")]
        public void GivenNavigateToLLoydsBankApplication()
        {
            GoToUrl(_envProperties["VirtusaAppUrl"]);
        }

        [When(@"\[Click On Product and Services Link]")]
        public void WhenClickOnProductAndServicesLink()
        {
            _test = _createChildNode("Launch Application");

            _lLoydsBankHomePage = new lLoydsBankHomePage(_driver, _test);

            _lLoydsBankHomePage.ClickonProductAndServices();
        }

        [Then(@"\[Verify the Application is navigated to Product and services Page]")]
        public void ThenVerifyTheApplicationIsNavigatedToProductAndServicesPage()
        {
            Assert.True(_lLoydsBankHomePage.VerifyProductAndServicePage());
        }

        [AfterTestRun]
        public static void AfterFeature()
        {
            _driver.Quit();
        }
    }
}
