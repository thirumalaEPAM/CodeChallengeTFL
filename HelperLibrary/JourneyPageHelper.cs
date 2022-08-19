using ObjectReporsitoryLibrary;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperLibrary
{
    public class JourneyPageHelper
    {
        IWebDriver webdriver;
        CommonUtility commonUtility;
        PageHelper pageHelper;

        /// <summary>
        /// Update the Journey details and Preferences 
        /// </summary>
        /// <param name="dect"></param>
        public void UpdateJourneyPreferences(Dictionary<string, string> dect)
        {
            try
            {

                commonUtility.Mouseclick(PlanJourneyRepo.eltToLocation);
                commonUtility.ClickElement(JourneyResultsRepo.eltClearLocation);
                //commonUtility.EnterLocations(PlanJourneyRepo.eltToLocation, dect["Destination"]);
                commonUtility.SendText(PlanJourneyRepo.eltToLocation, dect["Destination"]);
                commonUtility.ClickElement(PlanJourneyRepo.eltDate);
                commonUtility.SelectValue(PlanJourneyRepo.eltDate, dect["JourneyDate"]);
                commonUtility.ClickElement(JourneyResultsRepo.eltEditPreference);
                commonUtility.ClickElement(JourneyResultsRepo.eltDeselectAllPref);
                if (dect["Bus"] == "true")
                {
                    commonUtility.pageScroll(JourneyResultsRepo.eltBusCheckbox);
                    commonUtility.Mouseclick(JourneyResultsRepo.eltBusCheckbox);
                }
                if (dect["Tram"] == "true")
                {
                    commonUtility.Mouseclick(JourneyResultsRepo.eltTramCheckbox);
                }
                commonUtility.pageScroll(JourneyResultsRepo.eltSavePref);
                commonUtility.pageScroll(JourneyResultsRepo.eltUpdateJourney);
                pageHelper.WriteLog(System.DateTime.Now + ":" + "Updated the Journey preferences\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.Message);
            }
        }


        /// <summary>
        /// Based on the journey results , this method will return true /false 
        /// </summary>
        /// <returns></returns>
        public Boolean ValidationJourneyResults()
        {
            Boolean flag = journeyTypesCheck();

            if (!flag)
            { 
               string moreSearchResults=commonUtility.getElementText(JourneyResultsRepo.eltMoreResults);
                pageHelper.WriteLog(System.DateTime.Now + ":" + moreSearchResults + "\n");
                commonUtility.ClickListWebElements(JourneyResultsRepo.eltJourneyResults);
                flag = journeyTypesCheck();

            }
            
            return flag;
        }
        public Boolean journeyTypesCheck() 
        {
            Boolean flag = false;
            string result = string.Empty;
            try
            {
                result = commonUtility.getElementText(JourneyResultsRepo.eltCyclingandOther);
                if (result == Constants.cyclingandOther) flag = true;
                else flag = false;

            }
            catch (TimeoutException ex)
            {
                result = commonUtility.getElementText(JourneyResultsRepo.eltFastTrans);
                if (result == Constants.fastestTrans) flag = true;

            }
            catch (Exception ex)
            {
                flag = false;

            }

            return flag;

        }
        public Boolean validation(int dictCount, By by)
        {
            int elementsCount = commonUtility.CountElements(by);

            Boolean flag = false;

            if (dictCount == elementsCount) flag = true;

            return flag;
        }
        public JourneyPageHelper(IWebDriver driver)
        {
            this.webdriver = driver;
            commonUtility = new CommonUtility(webdriver);
            pageHelper = new PageHelper(driver);
        }
    }
}
