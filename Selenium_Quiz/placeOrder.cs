using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Selenium_Quiz
{
    public class placeOrder:Common_method
    {

        #region elements
      
        By product = By.XPath("(//i[@class='fa fa-shopping-cart'])[2]");
        By contineo = By.XPath("//button[@data-dismiss='modal']");
        By cartbutton = By.XPath("//div[@class='col-sm-8']/div/ul/li[3]/a");
        By checkoutbutton = By.XPath("//a[text()='Proceed To Checkout']");
        By address = By.XPath("//ul[@id='address_delivery']/li[4]");
        By review = By.XPath("//h2[text()='Review Your Order']");
        By reviewProduct = By.XPath("//a[text()='Blue Top']");
        By message = By.Name("message");
        By placeOrders = By.XPath("//a[text()='Place Order']");
        By name_on_card = By.Name("name_on_card");
        By card_number = By.Name("card_number");
        By cvc = By.Name("cvc");
        By expiry_month = By.Name("expiry_month");
        By expiry_year = By.Name("expiry_year");
        By pay = By.Id("submit");
        By successMessage = By.XPath("//div[contains(text(),'Your order has been placed successfully!')]");

        #endregion



        #region Placeorder Steps

        #region Step 1
        public void scrollToproduct()
        {
            scrollToElement(product);
        }
        #endregion

        public void clickProduct()
        {
            Thread.Sleep(2000);
            click(product);
            
        }

        public void clickContineu()
        {
            click(contineo);

        }

        public void clickCart()
        {
            scrollToElement(cartbutton);
            click(cartbutton);

        }

        public void verifyCheckoutButton(string value)
        {
            verifyElement(checkoutbutton, value);

        }

        public  void clickProceed()
        {
            
            click(checkoutbutton);

        }
        public void verifyAddressDetail(string userAddress,string productName)
        {
            verifyElement(address,userAddress);
            scrollToElement(review);
            verifyElement(reviewProduct, productName);
        }
       
        public void enterDiscription(string mess)
        {
            scrollToElement(message);
            simpleSetText(message, mess);
            click(placeOrders);
        }


        public void paymentDetails(string cardName, string cardNum, string cvvNum, string monthExpire, string yearExpire)
        {
            setText(name_on_card, cardName);
            setText(card_number, cardNum);
            setText(cvc, cvvNum);
            setText(expiry_month, monthExpire);
            setText(expiry_year, yearExpire);
            
        }

        public void clickPay()
        {
            click(pay);
        }

        public void verifySuccessmessage(string mess)
        {
            commonDriver.Navigate().Back();
            verifyElement(successMessage, mess);
            commonDriver.Navigate().Forward();
        }


        public void placeorder(string[] a)
        {
            scrollToproduct();
            clickProduct();
            Thread.Sleep(5000);
            clickContineu();
            clickCart();
            verifyCheckoutButton("Proceed To Checkout");
            clickProceed();
            verifyAddressDetail(a[10], "Blue Top");
            enterDiscription(a[17]);
            paymentDetails(a[18], a[19], a[20], a[21], a[22]);
            clickPay();
            verifySuccessmessage("Your order has been placed successfully!");
        }

        public void downPlaceOrder(string[] a)
        {
            clickCart();
            verifyCheckoutButton("Proceed To Checkout");
            clickProceed();
            verifyAddressDetail(a[10], "Blue Top");
            enterDiscription(a[17]);
            paymentDetails(a[18], a[19], a[20], a[21], a[22]);
            clickPay();
           // verifySuccessmessage("Your order has been placed successfully!");
        }



        #endregion

    }
}