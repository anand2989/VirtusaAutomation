using AventStack.ExtentReports;
using NUnit.Framework;
using System;
using System.Reflection;
using Virtusa_Assignment.Pages.PageObjects;

namespace Virtusa_Assignment.Tests
{
    [TestFixture]
    class LLoydsBankTests : BaseTest
    {
        private lLoydsBankHomePage? _lLoydsBankHome;
        private CurrentProductsPage _currentProductsPage;

        //reporting
        ExtentTest? _extentTest;

        [SetUp]
        public void TestSetup()
        {
            GoToUrl(_envProperties["VirtusaAppUrl"]);

            createParentNode(_envProperties["TestName"]);
        }

        [Test]
        public void ValidateCurrentProductsInformation ()
        {
            _extentTest = _createChildNode(MethodBase.GetCurrentMethod().Name);

            try
            {
                // home Page
                _lLoydsBankHome = new lLoydsBankHomePage(_driver, _extentTest);

                _lLoydsBankHome.ClickonProductAndServices();

                _lLoydsBankHome.ClickonCurrentAccounts();

                _currentProductsPage = new CurrentProductsPage(_driver, _extentTest);

                Assert.True(_currentProductsPage.VerifyCurrentProductPage());
                _extentTest.Log(Status.Pass, "Current Page Loaded Properly");

                Assert.True(_currentProductsPage.VerifyNumberofProductsForCurrentAccount() > 0);
                _extentTest.Log(Status.Pass, "Current products are not zero");

                Assert.AreEqual(_currentProductsPage.VerifyPlatinumAccountFee(), Convert.ToInt16(Resources.TestData.Platinumfees));
                _extentTest.Log(Status.Pass, "Platinum product fees per month is " + Resources.TestData.Platinumfees);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false, "Test case failed due to following error : " + ex.Message);
            }
        }
    }
}
