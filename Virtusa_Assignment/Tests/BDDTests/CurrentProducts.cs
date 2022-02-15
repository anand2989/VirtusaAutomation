using AventStack.ExtentReports;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Virtusa_Assignment.Tests;

namespace Virtusa_Assignment.Pages.PageObjects
{
    [Binding]
    public class CurrentProducts : BaseTest
    {
        lLoydsBankHomePage _lLoydsBankHomePage;
        CurrentProductsPage _currentProductsPage;

        ExtentTest? _test;

        [Given(@"\[Navigate to LLoyds Application]")]
        public void NavigatetoLLoydsApplication()
        {
            setUp();

            BaseTestSetup();

            createParentNode(_envProperties["TestName"]);

            GoToUrl(_envProperties["VirtusaAppUrl"]);
        }

        [When(@"\[Click On Current Products Link]")]
        public void WhenClickOnCurrentProductsLink()
        {
            _test = _createChildNode("Launch Application");

            _lLoydsBankHomePage = new lLoydsBankHomePage(_driver, _test);

            _lLoydsBankHomePage.ClickonProductAndServices();

            _lLoydsBankHomePage.ClickonCurrentAccounts();
        }

        [Then(@"\[Validate Current Product information]")]
        public void ThenValidateCurrentProductinformation()
        {
            _test = _createChildNode("Launch Application");

            _currentProductsPage = new CurrentProductsPage(_driver, _test);

            Assert.True(_currentProductsPage.VerifyCurrentProductPage());
            
            Assert.True(_currentProductsPage.VerifyNumberofProductsForCurrentAccount() > 0);

            Assert.AreEqual(_currentProductsPage.VerifyPlatinumAccountFee(), Convert.ToInt16(Resources.TestData.Platinumfees));
        }

        [AfterTestRun]
        public static void AfterFeature()
        {
            _driver.Quit();

        }
    }
}