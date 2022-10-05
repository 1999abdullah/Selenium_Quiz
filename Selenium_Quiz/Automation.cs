using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;

namespace Selenium_Quiz
{
    [TestClass]
    public class Automation
    {

        public TestContext instance;
        public TestContext TestContext
        {

            set { instance = value; }
            get { return instance; }

        }

        [TestInitialize]
        public void testInitalize()
        {
            Common_method.log.Info("Test case start");
        }
        [TestCleanup]
        public void testCleanup()
        {
            Common_method.log.Info("Test case close");
        }



        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "register_data.XML", "LoginWithValidCredentials", DataAccessMethod.Sequential)]
        public void TestCaseRegisterUser()
        {
            #region xml to string
            string url = TestContext.DataRow["url"].ToString();

            string name = TestContext.DataRow["name"].ToString();

            string email = TestContext.DataRow["email"].ToString();

            string password = TestContext.DataRow["password"].ToString();
            string days = TestContext.DataRow["days"].ToString();
            string month = TestContext.DataRow["month"].ToString();
            string year = TestContext.DataRow["year"].ToString();
            string fname = TestContext.DataRow["fname"].ToString();
            string lname = TestContext.DataRow["lname"].ToString();
            string company = TestContext.DataRow["company"].ToString();
            string address1 = TestContext.DataRow["address1"].ToString();
            string address2 = TestContext.DataRow["address2"].ToString();
            string country = TestContext.DataRow["country"].ToString();
            string state = TestContext.DataRow["state"].ToString();
            string city = TestContext.DataRow["city"].ToString();
            string postaladdress = TestContext.DataRow["postaladdress"].ToString();
            string number = TestContext.DataRow["number"].ToString();
            string[] values = new string[] { url,name,email,password,days,month,year,fname,lname,company,address1,address2, country,state, city,postaladdress,number };

            #endregion


            IWebDriver automationDriver = Common_method.webDriver("chrome");
            RegisterUser register = new RegisterUser(automationDriver);
            register.registerUser(values);
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "register_data.XML", "LoginWithValidCredentials", DataAccessMethod.Sequential)]
        public void Placeorder()
        {
            #region xml to string
            string url = TestContext.DataRow["url"].ToString();

            string name = TestContext.DataRow["name"].ToString();

            string email = TestContext.DataRow["email"].ToString();

            string password = TestContext.DataRow["password"].ToString();
            string days = TestContext.DataRow["days"].ToString();
            string month = TestContext.DataRow["month"].ToString();
            string year = TestContext.DataRow["year"].ToString();
            string fname = TestContext.DataRow["fname"].ToString();
            string lname = TestContext.DataRow["lname"].ToString();
            string company = TestContext.DataRow["company"].ToString();
            string address1 = TestContext.DataRow["address1"].ToString();
            string address2 = TestContext.DataRow["address2"].ToString();
            string country = TestContext.DataRow["country"].ToString();
            string state = TestContext.DataRow["state"].ToString();
            string city = TestContext.DataRow["city"].ToString();
            string postaladdress = TestContext.DataRow["postaladdress"].ToString();
            string number = TestContext.DataRow["number"].ToString();
            string[] values = new string[] { url, name, email, password, days, month, year, fname, lname, company, address1, address2, country, state, city, postaladdress, number };

            #endregion


            IWebDriver automationDriver = Common_method.webDriver("chrome");
            RegisterUser register = new RegisterUser(automationDriver);
            placeOrder order = new placeOrder();
            register.registerUser(values);
            order.placeorder();

        }


    }
}
