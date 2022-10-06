using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Quiz
{
    public class RegisterUser : Common_method
    {


        #region elements
        
        //*[@id='slider-carousel']/div/div[1]/div[1]/h1/span
        By automationHeadaing = By.XPath("//div[@class='col-sm-6']//child::h1");
        By signupButton = By.XPath("//a[text()=' Signup / Login']");
        By signupTitle = By.XPath("//h2[text()='New User Signup!']");
        By name = By.Name("name");
        By email = By.XPath("//input[@placeholder='Email Address' and @data-qa='signup-email']");
        By signupButton2 = By.XPath("//button[text()='Signup']");
        By accountinfo = By.XPath("//h2//b[text()='Enter Account Information']");
        By gender = By.Id("id_gender1");
        By password = By.Id("password");
        By day = By.Name("days");
        By month = By.Name("months");
        By years = By.Name("years");
        By newsletter = By.Id("newsletter");
        By option = By.Id("optin");
        By firstname = By.Id("first_name");
        By last_name = By.Id("last_name");
        By company = By.Id("company");
        By address1 = By.Id("address1");
        By address2 = By.Id("address2");
        By country = By.Id("country");
        By state = By.Id("state");
        By city = By.Id("city");
        By zipcode = By.Id("zipcode");
        By mobile_number = By.Id("mobile_number");
        By createAccount = By.XPath("//button[text()='Create Account']");
        By accountCreated = By.XPath("//h2//b[text()='Account Created!']");
        By Continue = By.XPath("//a[text()='Continue']");
        By loginUsername = By.XPath("//b[text()='Sharoon']");

        #endregion


        #region Test steps

        #region Step 1

        public void landingPage(string u)
        {
            driverUrl(u);
        }

        #endregion

        #region Step 2
        public void verifyHomepage(string value)
        {
            log.Info("Verify that home page is visible successfully");
            verifyElement(automationHeadaing,value);
            log.Info("The visible element is "+ value);
        }
        #endregion

        #region Step 3

        public void clickSignup()
        {
            log.Info("Click on Signup / Login button");
            click(signupButton);
            log.Info("Signup button clicked");
            
        }
        #endregion

        #region Step 4

        public void verifySignuptitle(string value)
        {
            log.Info("Verify New User Signup! is visible");
            verifyElement(signupTitle, value);
            log.Info("New User Signup! is visible successfully");
        }
        #endregion

        #region Step 5
        public void inputname(String nameInput)
        {
            log.Info("Enter name");
            setText(name, nameInput);
            log.Info("Entered name is "+nameInput);
        }
        #endregion

        #region Step 6

        public void inputemail(String emailInput)
        {
            log.Info("Enter email");
            setText(email, emailInput);
            log.Info("Entered email is " + emailInput);
        }
        #endregion

        #region Step 7
        public void clickSignup2()
        {
            log.Info("Click Signup button");
            click(signupButton2);
            log.Info("Signup button clicked");

        }
        #endregion

        #region Step 8
        public void verifyaccountinfo(string value)
        {
            log.Info("Verify that ENTER ACCOUNT INFORMATION is visible");
            verifyElement(accountinfo, value);
            log.Info("Verifed text is "+value);
        }
        #endregion

        #region Step 9
        public void filldetail1(string pass,string days,string months,string year)
        {
            log.Info("Fill details: Title, Name, Email, Password, Date of birth");
            click(gender);
            setText(password, pass);
            dropdown(day,days);
            dropdown(month,months);
            dropdown(years, year);
            log.Info("Filled details are " +pass+ " "+days+" "+months+" "+year);
        }
        #endregion

        #region Step 10
        public void clickNewsletter()
        {
            if (!findElement(newsletter).Selected)
            {
                log.Info("Select checkbox Sign up for our newsletter!");
                click(newsletter);
                log.Info("Checkbox is selected");
            }

        }
        #endregion

        #region Step 11
        public void clickOption()
        {
            if (!findElement(option).Selected)
            {
                log.Info("Select checkbox Receive special offers from our partners!");
                click(option);
                log.Info("Checkbox is selected");
            }

        }
        #endregion

        #region Step 12
        public void filldetail2(string f, string l, string c, string a1, string a2,string c1,string s, string ci,string z,string m)
        {
            log.Info("Fill details: First name, Last name, Company, Address, Address2, Country, State, City,Zipcode, Mobile Number");
            setText(firstname, f);
            setText(last_name, l);
            setText(company, c);
            setText(address1, a1);
            setText(address2, a2);
            dropdown(country, c1);
            setText(state, s);
            setText(city, ci);
            setText(zipcode, z);
            setText(mobile_number, m);
            log.Info("Filled details are "+f+" "+l+" "+c+" "+a1+" "+a1+" "+c1+" "+s+" "+ci+" "+z+" "+m);
        }
        #endregion

        #region Step 13
        public void clickCreateAccount()
        {
            log.Info("Click Create Account button");
            click(createAccount);
            log.Info("Click action perform");
        }
        #endregion

        #region Step 14
        public void verifyAccountCreated(string value)
        {
            log.Info("Verify that ACCOUNT CREATED! is visible");
            verifyElement(accountCreated, value);
            log.Info("ACCOUNT CREATED! is verified");
        }
        #endregion

        #region Step 15
        public void clickContineou()
        {
            log.Info("Click Continue button");
            click(Continue);
            log.Info("Continue button is clicked");

        }
        #endregion

        #region Step 16
        public void verifyLoginUsername(string value)
        {
            log.Info("Verify that Logged in as username is visible");
            verifyElement(loginUsername, value);
            log.Info("The visible user name is "+value);

        }
        #endregion

        #endregion


        #region Register

        public void registerUser(string[] a)
        {
            landingPage(a[0]);
            verifyHomepage("AutomationExercise");
            clickSignup();
            verifySignuptitle("New User Signup!");
            inputname(a[1]);
            inputemail(a[2]);
            clickSignup2();
            verifyaccountinfo("ENTER ACCOUNT INFORMATION");
            filldetail1(a[3], a[4], a[5], a[6]);
            clickNewsletter();
            clickOption();
            filldetail2(a[7], a[8], a[9], a[10], a[11], a[12], a[13], a[14], a[15] ,a[16]);
            clickCreateAccount();
            verifyAccountCreated("ACCOUNT CREATED!");
            clickContineou();
            verifyLoginUsername(a[1]);
        }

        #endregion

    }
}

