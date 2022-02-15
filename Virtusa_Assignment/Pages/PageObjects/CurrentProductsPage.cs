using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virtusa_Assignment.Extensions;

namespace Virtusa_Assignment.Pages.PageObjects
{
    public class CurrentProductsPage : WebElementLocators
    {
        private string _lloydscurrenproduct_list_currentproducts = "//strong[text()='Free everyday banking']/ancestor::div[7]/div";
        private string _lloydscurrenproduct_txt_currentaccounts = "//h1[text()='Current Accounts']";

        public CurrentProductsPage(IWebDriver driver, ExtentTest extentTest) : base(driver, extentTest)
        {

        }

        public bool VerifyCurrentProductPage()
        {
            _waitForElementVisible(_lloydscurrenproduct_txt_currentaccounts, "xpath");
            return IsElementVisible(_returnWebElementByXpath(_lloydscurrenproduct_txt_currentaccounts));
        }

        public int VerifyNumberofProductsForCurrentAccount()
        {
            WaitForElementToExist(By.XPath(_lloydscurrenproduct_list_currentproducts), 120.Seconds());

            IList<IWebElement> _listofcurrentproducts = _returnWebElementsByXpath(_lloydscurrenproduct_list_currentproducts);

            return _listofcurrentproducts.Count;
        }

        public int VerifyPlatinumAccountFee()
        {
            string _platinumfee = null;

            WaitForElementToExist(By.XPath(_lloydscurrenproduct_list_currentproducts), 120.Seconds());

            IList<IWebElement> _listofcurrentproducts = _returnWebElementsByXpath(_lloydscurrenproduct_list_currentproducts);

            for (int _rotator = 1; _rotator <= _listofcurrentproducts.Count; _rotator++)
            {
                string _productName = _returnWebElementByXpath(_lloydscurrenproduct_list_currentproducts + "[" + _rotator + "]//h2/span").Text;

                if (_productName.ToLower().Contains(Resources.TestData.ProductName))
                {
                    _platinumfee = _returnWebElementByXpath(_lloydscurrenproduct_list_currentproducts + "[" + _rotator + "]//p//strong").Text.Split(' ')[0].Replace("£", " ").Trim();

                    break;
                }
            }

            return Convert.ToInt32(_platinumfee);

        }
    }
}
