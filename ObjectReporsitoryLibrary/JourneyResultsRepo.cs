using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectReporsitoryLibrary
{
    public class JourneyResultsRepo
    {
        public static By eltJourneypage = By.XPath("//span[text()='Journey results']");
        public static By eltFrom = By.XPath("//span[text()='From:']//following-sibling::span/strong");
        public static By eltTo = By.XPath("//span[text()='To:']//following-sibling::span/strong");
        public static By eltPublicTrans = By.XPath("//h2[text()='Fastest by public transport']");
        public static By eltCyclingandOther = By.XPath("//h2[text()='Cycling and other options']");
        public static By eltFastTrans = By.XPath("//h2[@class='jp-result-transport publictransport clearfix']");

        public static By eltEditJourney = By.XPath("//span[text()='Edit journey']");
        public static By eltClearLocation = By.XPath("//a[text()='Clear To location']");
        public static By eltEditPreference = By.XPath("//a[text()='Edit preferences']");
        public static By eltDeselectAllPref = By.XPath("//a[@class='jp-deselect-all']");
        public static By eltBusCheckbox = By.XPath("//input[@id='bus']");
        public static By eltTramCheckbox = By.XPath("//input[@id='tram']");
        public static By eltUpdateJourney = By.XPath("//input[@class='primary-button plan-journey-button']");
        public static By eltSavePref = By.XPath("//label[@for='SavePreferences']");
        public static By eltLeavingDate = By.XPath("//span[text()='Leaving:']//following-sibling::strong");
        public static By eltPlanmyjourneylink = By.XPath("//a[text()='Plan a journey']");
        public static By eltMoreResults = By.XPath("//span[contains(text(),'We found more than one')]");
        public static By eltJourneyResults = By.XPath("//ol[@id='disambiguation-options-to']//li");

    }
}
