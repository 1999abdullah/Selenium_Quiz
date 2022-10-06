﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Selenium_Quiz
{
    public class Common_method
    {
        public static IWebDriver commonDriver;

        public static readonly log4net.ILog log =
        log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
       
        Actions action;

        #region Webdriver

        public static IWebDriver webDriver(string driver)
        {
            if (driver == "Chrome" || driver == "chrome")
            {
                commonDriver = new ChromeDriver();
                log.Info("Chrome Driver launch");
            }
            else if (driver == "firefox")
            {
                commonDriver = new FirefoxDriver();
                log.Info("Firefox Driver launch");
            }
            else if (driver == "edge")
            {
                commonDriver = new EdgeDriver();
                log.Info("Edge Driver launch");
            }
            commonDriver.Manage().Window.Maximize();
            return commonDriver;
        }

        #endregion

        #region General Method

        #region Find element
        public IWebElement findElement(By Locate)
        {

            return commonDriver.FindElement(Locate);
        }

        #endregion

        #region Verify element
        public void verifyElement(By Locate,string value)
        {
            if (IsElementVisible(Locate) == true)
            {
                string a = findElement(Locate).Text;
                Assert.AreEqual(value, a);
            }
            else if(IsElementVisible(Locate) == false)
            {
                MessageBox.Show("Element is not visibal");
            }

        }

        #endregion

        #region Url calling
        public void driverUrl(string url)
        {
            log.Info("Navigate to URL http://automationexercise.com");
            commonDriver.Url = url;
            log.Info("The open url is "+url);
        }
        #endregion

        #region Send Text 
        public void setText(By locate, string text)
        {

            bool a = isElementTextFeild(locate);
            if (a == true)
            {
                IWebElement findedElement = findElement(locate);
                findedElement.Clear();
                removeElemntText(findedElement);
                findedElement.SendKeys(text + Keys.Tab);
            }
            else if (a == false)
            {
                MessageBox.Show("Element feild is not corerect");
            }

        }
        #endregion

        #region Simple Send Text 
        public void simpleSetText(By locate, string text)
        {

                IWebElement findedElement = findElement(locate);
                findedElement.Clear();
                removeElemntText(findedElement);
                findedElement.SendKeys(text + Keys.Tab);
            

        }
        #endregion

        #region Click 

        public void click(By locator)
        {
            try
            {
                IWebElement element = WaitforElement(locator);

                action = new Actions(commonDriver);
                action.Click(element).Build().Perform();
            }
            catch
            {
                log.Error(locator + " element is not clicked");
            }
        }
        #endregion

        #region Drop down
        public void dropdown(By locator ,string a)
        {
            SelectElement drop = new SelectElement(commonDriver.FindElement(locator));
            drop.SelectByValue(a);
        }

        #endregion

        #region Removing the Text 

        public void removeElemntText(IWebElement element)
        {
            int a = element.Text.Length;

            while (a > 0)
            {
                element.SendKeys(Keys.Backspace);
            }
        }
        #endregion

        #region Close Driver
        public static void close()
        {
            commonDriver.Close();
        }

        #endregion

        #region Sleep method
        public void sleep(int seconds)
        {
            Thread.Sleep(seconds);
            
        }
        #endregion

        #region Get Element Text
        public string getElementText(By locator)
        {
            string text;
            try
            {
                text = findElement(locator).Text;
            }
            catch
            {
                try
                {
                    text = findElement(locator).GetAttribute("Value");
                }
                catch
                {
                    text = findElement(locator).GetAttribute("innerHTML");

                }
            }
            return text;

        }
        #endregion

        #region Is Element Text Feild
        private bool isElementTextFeild(By locator)
        {
            IWebElement element = findElement(locator);

            try
            {
                bool resultEmail = Convert.ToBoolean(element
                    .GetAttribute("type")
                    .Equals("email"));
                bool resultText = Convert.ToBoolean(element
                    .GetAttribute("type")
                    .Equals("text"));
                bool resultpass = Convert.ToBoolean(element
                    .GetAttribute("type")
                    .Equals("password"));
                bool a = resultpass == true || resultText == true || resultEmail == true ? true : false;
                return a;

            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Get Element State
        public string getElementState(By locator)
        {
            string state = findElement(locator).GetAttribute("Disabled");
            return state == null ? "enabled" : state == "true" ? "disabled" : "Invalid";

        }
        #endregion

        #region Scroll To Element
        public void scrollToElement(By locator)
        {
           

            IWebElement state = WaitforElement(locator);
            IJavaScriptExecutor commonExecuter = (IJavaScriptExecutor)commonDriver;
            commonExecuter.ExecuteScript("arguments[0].scrollIntoView(true); ", state);


        }
        #endregion

        #region Execute Java ScriptCode
        public static string ExecuteJavaScriptCode(string javascriptCode)
        {
            string value = null;
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)commonDriver;
                value = (string)js.ExecuteScript(javascriptCode);
            }
            catch (Exception)
            {

            }
            return value;
        }

        #endregion

        #region Wait for  Element
        private IWebElement WaitforElement(By by, int timeToReadyElement = 0)
        {
            IWebElement element = null;
            try
            {
                if (timeToReadyElement != 0 && timeToReadyElement.ToString() != null)
                {
                    //PlaybackWait(timeToReadyElement * 1000);
                    timeToReadyElement = timeToReadyElement * 1000;
                }
                element = findElement(by);
            }
            catch
            {
                WebDriverWait wait = new WebDriverWait(commonDriver, TimeSpan.FromSeconds(10));
                wait.Until(driver => IsPageReady() == true && IsElementVisible(by) == true && IsClickable(by) == true);
                element = findElement(by);
            }
            return element;
        }

        //private void PlaybackWait(int v)
        //{
        //    throw new NotImplementedException();
        //}

        private bool IsClickable(By by)
        {
            try
            {
                new WebDriverWait(commonDriver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
                return true;
            }
            catch
            {
                return false;
            }

        }

        private bool IsElementVisible(By by)
        {

            return (findElement(by).Displayed || findElement(by).Enabled) ? true : false;


        }

        private bool IsPageReady()
        {

            return ExecuteJavaScriptCode("return document.readyState").Equals("complete");

        }

        #endregion

        #region Element present
        private bool IsElementPresent(By by)
        {
            try
            {
                findElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        #endregion

        #endregion





    }
}

