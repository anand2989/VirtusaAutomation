using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Threading;
using Virtusa_Assignment.Tests;

namespace Virtusa_Assignment.Pages
{
    public class BasePage : BaseTest
    {
        protected new IWebDriver _driver;
        protected new ExtentTest _extentTest;
        
    
        //private int _screenshotRandomNumber = 0;
        protected WebDriverWait _webDriverWait;
       

        public BasePage(IWebDriver driver, ExtentTest test)
        {
            _driver = driver;
            _extentTest = test;
            _webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(Convert.ToDouble(_envProperties["webdriverwait"])));

        }


        public void Click(IWebElement _webElement, String elementName)
        {
            try
            {
                _webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(_webElement));
                _webElement.Click();

                _extentTest.Log(Status.Pass, "Clicking on the element : " + elementName);            
            }
            catch (NoSuchElementException ex)
            {
                _extentTest.Log(Status.Fail, "Clicking on the element : " + elementName);
                throw new NoSuchElementException("Unable to click the element " + elementName + "throwing the exception " + ex.Message);
            }
        }

        public string GetElementText(IWebElement _webElement)
        {
            if (IsElementVisible(_webElement))
            {
                return _webElement.Text;
            }
            else
            {
                return "";
            }
        }

        public bool IsElementVisible(IWebElement _webElement)
        {
            try
            {
                return _webElement.Displayed;
            }
            catch (Exception ex)
            {
                return _webElement.Displayed;
            }
        }

        public void StaticWait(int staticWaitInMilliSeconds)
        {
            Thread.Sleep(staticWaitInMilliSeconds);
        }

        public void WaitForElementToExist(By elementSelector, TimeSpan timeout)
        {
            new WebDriverWait(_driver, timeout).Until(d => d.FindElements(elementSelector).Any());
        }

        protected internal void _waitForElementVisible(string _webElementXpath, string typeofIdentifier)
        {
            bool _webElementExist = false;
            int _iterationCount = 0;

            do
            {
                try
                {
                    switch (typeofIdentifier)
                    {
                        case "xpath":

                            _webElementExist = _driver.FindElement(By.XPath(_webElementXpath)).Displayed;

                            StaticWait(3000);

                            break;
                    }

                    _iterationCount++;
                }
                catch (Exception ex)
                {
                    StaticWait(1500);
                    continue;
                }

            } while (!_webElementExist && _iterationCount <= 9);
        }

        public bool IsElementVisible(string _elementPath, string _identifier)
        {
            bool _elementVisible = false;

            try
            {
                switch (_identifier)
                {
                    case "xpath":

                        _elementVisible = _driver.FindElement(By.XPath(_elementPath)).Displayed;

                        break;
                }
            }
            catch (Exception ex)
            {
                _elementVisible = false;
            }

            return _elementVisible;
        }

    }
}
