using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectReporsitoryLibrary
{
    public class PlanJourneyRepo
    {
        public static By eltFromLocation = By.XPath("//input[@Id='InputFrom']");
        public static By eltToLocation = By.XPath("//input[@Id='InputTo']");
        public static By eltPlanMyJourneybtn = By.XPath("//input[@Id='plan-journey-button']");
        public static By eltAcceptCookiesbtn = By.XPath("//button[@id='CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll']");
        public static By eltSaveCookies = By.XPath("//strong[text()='Done']");
        public static By eltFromvalidation = By.XPath("//span[@id='InputFrom-error']");
        public static By eltTovalidation = By.XPath("//span[@id='InputTo-error']");
        public static By eltChangeTime = By.XPath("//a[@class='change-departure-time']");
        public static By eltArrivingbtn = By.XPath("//label[@for='arriving']");
        public static By eltDate = By.XPath("//select[@id='Date']");
        public static By eltTime = By.XPath("//select[@id='Time']");
        public static By eltValidationError = By.XPath("//li[@class='field-validation-error']");
        public static By eltRecentJournys = By.XPath("//a[text()='Recents']");
        public static By eltRecentsList = By.XPath("//div[@id='jp-recent-content-jp-']//child::a[contains(@href,'plan-a-journey')]");
    }
}
