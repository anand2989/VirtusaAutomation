using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using Virtusa_Assignment.Extensions;
using Virtusa_Assignment.Reporting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Virtusa_Assignment.Tests
{
    [TestFixture]
    public class BaseTest : ExtentReporting
    {
        protected static IWebDriver _driver;
       
        [OneTimeSetUp]
        public void setUp()
        {
            // read properties
            LoadPropertiesFromFile();

            createReportInstance();
        }

        [SetUp]
        public void BaseTestSetup()
        {
            switch (_envProperties["browser"].ToLower())
            {
                case "chrome":
                    {
                        _driver = new ChromeDriver(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName);
                        break;
                    }
                   
                default:
                    {
                        throw new Exception("No browser type specified in the propoerties file");
                    }
            }
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = 5.Seconds();
            _driver.Manage().Timeouts().PageLoad = 20.Seconds();         
        }

        [TearDown]
        public void BaseTestCleanup()
        {
            // if the test failed, take a screenshot
            if (TestContext.CurrentContext.Result.Outcome == ResultState.Success)
            {
                var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
                var screenShotFileName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/" +
                    TestContext.CurrentContext.Test.FullName + DateTime.Now.ToString("MMM-dd-HHmm") + ".jpg";
                screenshot.SaveAsFile(screenShotFileName);
                Console.WriteLine("Screenshot saved at: " + screenShotFileName);
            }

            _driver.Quit();

            FlushExtentReport();
        }  
        

        protected internal void GoToUrl(String url)
        {
            _driver.Navigate().GoToUrl(url);
        }
    }
}