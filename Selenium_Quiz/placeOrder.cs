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
        By cartbutton1 = By.XPath("(//*[@id='cartModal']/div/div/div[3]/button");


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

        




        public void placeorder()
        {
            scrollToproduct();
            clickProduct();
            Thread.Sleep(5000);
            IWebElement state = findElement(cartbutton1);
            IJavaScriptExecutor commonExecuter = (IJavaScriptExecutor)commonDriver;
            commonExecuter.ExecuteScript("arguments[0].scrollIntoView(true); ", state);




        }



        #endregion
    }
}