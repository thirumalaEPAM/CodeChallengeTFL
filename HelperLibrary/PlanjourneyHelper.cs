using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectReporsitoryLibrary;
using OpenQA.Selenium;

namespace HelperLibrary
{
    public class PlanjourneyHelper
    {
        IWebDriver webdriver;
        CommonUtility commonUtility;
        /// <summary>
        /// This method select the source and destination locations
        /// </summary>
        /// <param name="fromplace"></param>
        /// <param name="toplace"></param>
        public void planmyjourney(string fromplace, string toplace)
        {

            commonUtility.SendText(PlanJourneyRepo.eltFromLocation, fromplace);
            commonUtility.SendText(PlanJourneyRepo.eltToLocation, toplace);


        }

        public PlanjourneyHelper(IWebDriver driver)
        {
            this.webdriver = driver;
            commonUtility = new CommonUtility(webdriver);
        }
    }
}
