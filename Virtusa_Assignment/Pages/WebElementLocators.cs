using System.Collections.Generic;
using AventStack.ExtentReports;
using OpenQA.Selenium;

namespace Virtusa_Assignment.Pages
{
    public class WebElementLocators : BasePage
    {
        public WebElementLocators(IWebDriver driver, ExtentTest extentTest) : base(driver, extentTest)
        {
        }

        protected IWebElement _returnWebElementById(string _id)
        {
            return _driver.FindElement(By.Id(_id));
        }

        protected IWebElement _returnWebElementByName(string _name)
        {
            return _driver.FindElement(By.Name(_name));
        }

        protected IWebElement _returnWebElementByClassName(string _className)
        {
            return _driver.FindElement(By.ClassName(_className));
        }

        protected IWebElement _returnWebElementByTagName(string _tagName)
        {
            return _driver.FindElement(By.TagName(_tagName));
        }

        protected IWebElement _returnWebElementByLinkText(string _linkText)
        {
            return _driver.FindElement(By.LinkText(_linkText));
        }

        protected IWebElement _returnWebElementByPartialLinkText(string _partialLinkText)
        {
            return _driver.FindElement(By.PartialLinkText(_partialLinkText));
        }

        protected IWebElement _returnWebElementByCssSelector(string _cssSelector)
        {
            return _driver.FindElement(By.CssSelector(_cssSelector));
        }

        protected IWebElement _returnWebElementByXpath(string _xpath)
        {
            return _driver.FindElement(By.XPath(_xpath));
        }

        protected IList<IWebElement> _returnWebElementsByCssSelector(string _cssSelector)
        {
            return _driver.FindElements(By.CssSelector(_cssSelector));
        }

        protected IList<IWebElement> _returnWebElementsByXpath(string _xpath)
        {
            return _driver.FindElements(By.XPath(_xpath));
        }

        protected bool _elementExistsByXPath(string _xpath)
        {
            if (_driver.FindElements(By.XPath(_xpath)).Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}