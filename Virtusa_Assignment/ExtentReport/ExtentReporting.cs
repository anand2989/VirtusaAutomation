using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Virtusa_Assignment.PropertiesFile;
using System;
using System.IO;

namespace Virtusa_Assignment.Reporting
{
    public class ExtentReporting : GetProperties
    {
        protected static ExtentReports _extentReports;
        protected ExtentHtmlReporter _htmlReporter;
        protected ExtentTest _extentTest;
        protected ExtentKlovReporter ExtentKlovReporter;
        protected static string hmtlreport;

        //Creating the extent report instance
        protected void createReportInstance()
        {
            if (_extentReports == null)
            {
                hmtlreport = DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss");

                string reportname = _envProperties["reportName"];

                string _reportPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
                
                _reportPath = _reportPath + "/ExtentReport/Reports/"  + hmtlreport +"/" + reportname;

                if (!Directory.Exists(_reportPath))
                {
                    Directory.CreateDirectory(_reportPath);
                }

                _extentReports = new ExtentReports();

                _htmlReporter = new ExtentHtmlReporter(_reportPath + "/" + hmtlreport + ".html");

                string _testerName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString().Split('\\')[1].ToString();

                _extentReports.AttachReporter(_htmlReporter);

                _extentReports.AddSystemInfo("Reporter name", _testerName);

                _extentReports.AddSystemInfo("Environment", _envProperties["envName"].ToString());

                _extentReports.AddSystemInfo("username", _testerName);
            }
        }

        // Creating the parent node for the extent test report
        protected void createParentNode(string _scenarioName)
        {
            _extentTest = _extentReports.CreateTest(_scenarioName);
        }

        // Creating the parent node for the extent test report
        protected ExtentTest _createChildNode(string _childTestName)
        {
            return _extentTest.CreateNode(_childTestName);
        }

        protected void FlushExtentReport()
        {
            _extentReports.Flush();
        }
    }
}
