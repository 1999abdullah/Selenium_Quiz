using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Quiz
{
    public class placeOrder:Common_method
    {

        #region elements
       
        
        By product = By.XPath("//a[text()=' Products']");
        By brand = By.XPath("//h2[text()='Brands']");
        By p = By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/div/div[1]/div[1]/a");
        
        #endregion

        #region Placeorder

        public void placeorder()
        {
           
           click(product);
           scrollToElement(brand);

        }



        #endregion
    }
}