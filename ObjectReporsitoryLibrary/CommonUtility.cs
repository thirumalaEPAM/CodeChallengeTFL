using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectReporsitoryLibrary
{
    public class CommonUtility
    {
        IWebDriver webdriver;

        /// <summary>
        /// Wait for the WebElement until it loads
        /// </summary>
        /// <param name="elt"></param>
        /// <returns></returns>
        public IWebElement WaitForElement(By elt)
        {

            WebDriverWait wait = new WebDriverWait(webdriver, TimeSpan.FromSeconds(5));
            return wait.Until(X => X.FindElement(elt));
        }
        /// <summary>
        /// Get Text from WebElement
        /// </summary>
        /// <param name="elt"></param>
        /// <returns></returns>
        public String getElementText(By elt)
        {

            return WaitForElement(elt).Text.ToString();
        }
        /// <summary>
        /// Send Text into Text field by using this method
        /// </summary>
        /// <param name="elt"></param>
        /// <param name="text"></param>
        public void SendText(By elt, String text)
        {

            WaitForElement(elt).SendKeys(text);

        }

        /// <summary>
        /// Select the location value from dropdown by using Actions class methods
        /// </summary>
        /// <param name="elt"></param>
        /// <param name="location"></param>
        public void EnterLocations(By elt, String location)
        {
            Actions act = new Actions(webdriver);
            WaitForElement(elt).SendKeys(location);
            act.SendKeys(Keys.Down);
            act.SendKeys(Keys.Enter);
            act.Perform();

        }
        /// <summary>
        /// Click the webelement
        /// </summary>
        /// <param name="elt"></param>
        public void ClickElement(By elt)
        {
            WaitForElement(elt).Click();
        }

        /// <summary>
        /// Page scroll down using this method
        /// </summary>
        /// <param name="elt"></param>
        public void pageScroll(By elt)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)webdriver;
            js.ExecuteScript("window.scrollBy(0, 250)", "");

        }

        /// <summary>
        /// Click the element from the List
        /// </summary>
        /// <param name="by"></param>
        public void ClickListWebElements(By by)
        {
            IList<IWebElement> elts = webdriver.FindElements(by);
            elts[elts.Count - 1].Click();
        }

        /// <summary>
        /// Count the elements from List
        /// </summary>
        /// <param name="by"></param>
        /// <returns></returns>
        public int CountElements(By by)
        {
            IList<IWebElement> elts = webdriver.FindElements(by);
            return elts.Count;
        }

        /// <summary>
        /// Select the Dropdown values
        /// </summary>
        /// <param name="by"></param>
        /// <param name="value"></param>
        public void SelectValue(By by, string value)
        {
            SelectElement sel = new SelectElement(WaitForElement(by));
            sel.SelectByText(value);

        }
        /// <summary>
        /// Click the webelement using IJavascript executor method
        /// </summary>
        /// <param name="elt"></param>
        public void pageScrollandClick(By elt)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)webdriver;
            js.ExecuteScript("arguments[0].click();", webdriver.FindElement(elt));

        }
       /// <summary>
       /// Mouse click event using Actions class emthod
       /// </summary>
       /// <param name="by"></param>
        public void Mouseclick(By by)
        {
            Actions act = new Actions(webdriver);
            act.MoveToElement(WaitForElement(by)).Click();
            act.Perform();

        }
        public CommonUtility(IWebDriver driver) { this.webdriver = driver; }
    }
}
