using AventStack.ExtentReports;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using Virtusa_Assignment.Pages.PageObjects;
using Virtusa_Assignment.Reporting;
using Virtusa_Assignment.Tests;

namespace Virtusa_Assignment
{
    [Binding]
    public class LLyodBankHomeStepDefinitions : BaseTest
    {
        lLoydsBankHomePage _lLoydsBankHomePage;

        ExtentTest? _Test;
        

        [Given(@"\[Launch Browser]")]
        public void GivenLaunchBrowser()
        {
            setUp();

            BaseTestSetup();

            createParentNode(_envProperties["TestName"]);
        }


        [When(@"\[Navigate to LLyods Bank Application]")]
        public void WhenNavigateToLLyodsBankApplication()
        {
            GoToUrl(_envProperties["VirtusaAppUrl"]);
        }

        [Then(@"\[Verify the Application is navigated to right url]")]
        public void ThenVerifyTheApplicationIsNavigatedToRightUrl()
        {
            _Test = _createChildNode("Launch Application");

            _lLoydsBankHomePage = new lLoydsBankHomePage(_driver, _Test);

            Assert.True(_lLoydsBankHomePage.VerifyLloydAppHomePage(), "Application not loaded properly");
        }

        [AfterTestRun]
        public static void AfterFeature()
        {
            _driver.Quit();

        }
    }
}
