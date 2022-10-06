using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Selenium_Quiz
{

     
    public class invoicePage: RegisterUser
    {
        placeOrder place = new placeOrder();


        By register_login = By.XPath("(//a[@href='/login'])[2]");
        By download = By.XPath("//a[text()='Download Invoice']");
        

        public void clickRegistrUser()
        {
            
            click(register_login);
        }

        public void downloadButton()
        {

            click(download);
           
            string[] filePaths = Directory.GetFiles(@"C:\Users\samiiabd\Downloads");
            string file = null;
            foreach (string filePath in filePaths)
            {
                if(filePath== "C:\\Users\\samiiabd\\Downloads\\invoice (4).txt")
                {
                    file = filePath;
                    Console.WriteLine(file);
                }
            }
            Assert.IsTrue(file.Contains("invoice"));
            
        }

        public void downloadinvoice(string[] a)
        {
            landingPage(a[0]);
            verifyHomepage("AutomationExercise");
            place.scrollToproduct();
            place.clickProduct();
            Thread.Sleep(3000);
            place.clickContineu();
            place.clickCart();
            place.verifyCheckoutButton("Proceed To Checkout");
            place.clickProceed();
            Thread.Sleep(4000);
            clickRegistrUser();
            inputname(a[1]);
            inputemail(a[2]);
            clickSignup2();
            verifyaccountinfo("ENTER ACCOUNT INFORMATION");
            filldetail1(a[3], a[4], a[5], a[6]);
            clickNewsletter();
            clickOption();
            filldetail2(a[7], a[8], a[9], a[10], a[11], a[12], a[13], a[14], a[15], a[16]);
            clickCreateAccount();
            verifyAccountCreated("ACCOUNT CREATED!");
            clickContineou();
            place.downPlaceOrder(a);
            downloadButton();
            clickContineou();

        }
        

    }
}
