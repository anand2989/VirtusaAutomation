using System;
using OpenQA.Selenium;
using AventStack.ExtentReports;
using Virtusa_Assignment.Extensions;
using System.Collections.Generic;

namespace Virtusa_Assignment.Pages.PageObjects
{
    public class lLoydsBankHomePage : WebElementLocators
    {
        private string _lloydshomepage_list_product_services = "//ul[@id='mainnav']/li";
        private string _lloydshomepage_lnk_currentaccount = "//span[text()='Take a look at our range of accounts']/..";
        private string _lloydshomepage_txt_ProductandService = "//h1[text()='Products and Services']";
       
        public lLoydsBankHomePage(IWebDriver driver, ExtentTest extentTest) : base(driver, extentTest)
        {

        }

        public void ClickonProductAndServices()
        {
            WaitForElementToExist(By.XPath(_lloydshomepage_list_product_services), 120.Seconds());

            IList<IWebElement> _listofproductservices = _returnWebElementsByXpath(_lloydshomepage_list_product_services);

            for (int _rotator = 1; _rotator <= _listofproductservices.Count; _rotator++)
            {
                string _productservicesTxt = _returnWebElementByXpath(_lloydshomepage_list_product_services + "[" + _rotator + "]/a").Text;

                if (_productservicesTxt.ToLower().Contains(Resources.TestData.Producttext))
                {
                    Click(_returnWebElementByXpath(_lloydshomepage_list_product_services + "[" + _rotator + "]/a"), "Product And Services");
                    break;
                }
            }
        }

        public void ClickonCurrentAccounts()
        {
            _waitForElementVisible(_lloydshomepage_lnk_currentaccount, "xpath");
            Click(_returnWebElementByXpath(_lloydshomepage_lnk_currentaccount), "Current Account");
        }

        public bool VerifyLloydAppHomePage()
        {
            _waitForElementVisible(_lloydshomepage_list_product_services, "xpath");
            return  IsElementVisible(_returnWebElementByXpath(_lloydshomepage_list_product_services));    
        }

        public bool VerifyProductAndServicePage()
        {
            _waitForElementVisible(_lloydshomepage_txt_ProductandService, "xpath");
            return IsElementVisible(_returnWebElementByXpath(_lloydshomepage_txt_ProductandService));
        }
    }
}