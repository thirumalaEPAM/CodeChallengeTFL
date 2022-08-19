using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectReporsitoryLibrary;
using OpenQA.Selenium;

namespace HelperLibrary
{
    public class PageHelper
    {
        IWebDriver webdriver;
        CommonUtility Commonobj;

        /// <summary>
        ///WebElement Element Click 
        /// </summary>
        /// <param name="by"></param>
        public void ButtonClick(By by)
        {
            try
            {
                Commonobj.ClickElement(by);
            }
            catch (Exception ex) { 
                Commonobj.Mouseclick(by);
            }
        }

        /// <summary>
        /// Wait for Page load
        /// </summary>
        public void waitforpageLoad()
        {
            System.Threading.Thread.Sleep(15000);
        }

        /// <summary>
        /// Click the elemenet from the List
        /// </summary>
        /// <param name="by"></param>
        public void ButtonClick1(By by)
        {
            Commonobj.ClickListWebElements(by);
        }

        /// <summary>
        /// Page Scrolling up using this method
        /// </summary>
        public void pageScrollUp()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)webdriver;
            js.ExecuteScript("window.scrollBy(0, -350)", "");

        }

        /// <summary>
        /// Page should be scroll down using this method
        /// </summary>
        public void pageScrollDown()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)webdriver;
            js.ExecuteScript("window.scrollBy(0, 300)", "");

        }
        public void SendText(By by, string text)
        {

            Commonobj.SendText(by, text);
        }

        /// <summary>
        /// Select the value from the drop down
        /// </summary>
        /// <param name="by"></param>
        /// <param name="value"></param>
        public void selectValuefromDropdown(By by, string value)
        {

            Commonobj.SelectValue(by, value);
        }

       
        public string getText(By by)
        {

            return Commonobj.getElementText(by);
        }
        /// <summary>
        /// Date Conversion Method
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public string LeavingDateConversion(string date)
        {
            string result = string.Empty;

            string[] strArr = date.Split(' ');

            result = strArr[0].Substring(0, 3) + " " + strArr[1].Substring(0, 2) + " " + strArr[2].Substring(0, 3);

            return result;

        }

        /// <summary>
        /// This Method defines about the Accepting the cookies functionality
        /// </summary>
        public void AcceptCookies()
        {
            try
            {

                Commonobj.pageScroll(PlanJourneyRepo.eltAcceptCookiesbtn);
                Commonobj.ClickElement(PlanJourneyRepo.eltAcceptCookiesbtn);
                Commonobj.pageScrollandClick(PlanJourneyRepo.eltSaveCookies);
                Commonobj.ClickElement(PlanJourneyRepo.eltSaveCookies);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.Message);
            }

        }
        public string RondomNum()
        {

            string datetime = DateTime.Now.ToString();
            return datetime.Replace("/", "").Replace(":", "");
        }
        /// <summary>
        /// This Method defines about the screen shot capture
        /// </summary>
        /// <returns></returns>
        public String TakeScreenshot()
        {
            Screenshot screenshot = ((ITakesScreenshot)webdriver).GetScreenshot();
            string path1 = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug\\net6.0\\", "");
            string path = path1 + "\\Screenshots\\" + RondomNum() + ".png";
            screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
            return path;
        }

        /// <summary>
        /// Write Log data
        /// </summary>
        /// <param name="strLog"></param>
        public void WriteLog(string strLog)
        {

            string path1 = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug\\net6.0\\", "");
            string logFilePath = path1 + "\\LogData\\log" + System.DateTime.Today.ToString("MM-dd-yyyy") + "." + "txt";
            FileInfo logFileInfo = new FileInfo(logFilePath);
            DirectoryInfo logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
            if (!logDirInfo.Exists) logDirInfo.Create();
            using (FileStream fileStream = new FileStream(logFilePath, FileMode.Append))
            {
                using (StreamWriter log = new StreamWriter(fileStream))
                {
                    log.WriteLine(strLog);
                }
            }
        }
        public PageHelper(IWebDriver driver)
        {
            this.webdriver = driver;
            Commonobj = new CommonUtility(webdriver);
        }

    }
}
