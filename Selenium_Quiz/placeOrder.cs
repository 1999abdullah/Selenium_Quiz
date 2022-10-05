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
        

        #endregion

        #region Placeorder

        void scrollToproduct()
        {
            scrollToElement(product);
        }

        void clickProduct()
        {
            click(product);
            
        }

        void clickContineu()
        {
            click(contineo);

        }

        void clickCart()
        {
            scrollToElement(cartbutton);
            click(cartbutton);

        }

        void verifyCheckoutButton(string value)
        {
            verifyElement(checkoutbutton, value);

        }

        void clickProceed()
        {
            
            click(checkoutbutton);

        }
        void verifyAddressDetail(string value)
        {
            verifyElement(address, value);
            scrollToElement(review);
        }
       

        public void placeorder()
        {
            scrollToproduct();
            clickProduct();
            Thread.Sleep(5000);
            clickContineu();
            clickCart();
            verifyCheckoutButton("Proceed To Checkout");
            clickProceed();
            verifyAddressDetail("45 -c ,street 1");




        }



        #endregion
    }
}