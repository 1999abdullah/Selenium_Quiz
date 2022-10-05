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

        By automationHeadaing = By.XPath("//*[@id='slider-carousel']/div/div[1]/div[1]/h1/span");
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


        #region Constructor
        public RegisterUser(IWebDriver driver1)
        {
            commonDriver = driver1;
        }
        #endregion


        #region operation-methods

        void landingPage(string u)
        {
           
            driverUrl(u);
           
        }

        void verifyHomepage(string value)
        {
            verifyElement(automationHeadaing,value);
        }


        void clickSignup()
        {

            click(signupButton);
            
        }

        void verifySignuptitle(string value)
        {
            verifyElement(signupTitle, value);
        }


        void inputname(String nameInput)
        {
            setText(name, nameInput);
        }

        void inputemail(String emailInput)
        {
            setText(email, emailInput);
        }
        void clickSignup2()
        {

            click(signupButton2);

        }

        void verifyaccountinfo(string value)
        {
            verifyElement(accountinfo, value);
        }

        void filldetail1(string pass,string days,string months,string year)
        {
            click(gender);
            setText(password, pass);
            dropdown(day,days);
            dropdown(month,months);
            dropdown(years, year);
        }

        void clickNewsletter()
        {
            if (!findElement(newsletter).Selected)
            {
                click(newsletter);
            }

        }

        void clickOption()
        {
            if (!findElement(option).Selected)
            {
                click(option);
            }

        }

        void filldetail2(string f, string l, string c, string a1, string a2,string c1,string s, string ci,string z,string m)
        {
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

        }

        void clickCreateAccount()
        {
           
                click(createAccount);
  
        }

        void verifyAccountCreated(string value)
        {
            verifyElement(accountCreated, value);
        }

        void clickContineou()
        {

            click(Continue);

        }

        void verifyLoginUsername(string value)
        {
            verifyElement(loginUsername, value);
        }

        #endregion

        #region Register


        public  void registerUser(string[] a)
        {
            landingPage(a[0]);
            verifyHomepage("Automation");
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

