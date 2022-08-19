using System;
using System.Collections.Generic;
using ObjectReporsitoryLibrary;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TFLCodeChallenge2022.StepDefinitions
{
    [Binding]
    public class UpdateJourneyStepDefinations
    {
        Dictionary<string, string> dectJourneyPref = new Dictionary<string, string>();
      

        [Given(@"I can Launch TFL application and do my journey plan")]
        public void GivenICanLaunchTFLApplicationAndDoMyJourneyPlan()
        {            
            BddHooks.planjourneyHelper.planmyjourney(Constants.source, Constants.destination);
            BddHooks.help.ButtonClick(PlanJourneyRepo.eltPlanMyJourneybtn);
            BddHooks.help.waitforpageLoad();
            BddHooks.help.pageScrollUp();
        }

        [When(@"I can click on Edit Journey button for change my journey details")]
        public void WhenICanClickOnEditJourneyButtonForChangeMyJourneyDetails()
        {
            BddHooks.help.ButtonClick(JourneyResultsRepo.eltEditJourney);
            BddHooks.help.waitforpageLoad();
        }
        [When(@"I Change My preferences")]
        public void WhenIChangeMyPreferences(Table table)
        {
            dectJourneyPref = table.Rows.ToDictionary(r => r["Key"], r => r["Value"]);
            BddHooks.journeyPageHelper.UpdateJourneyPreferences(dectJourneyPref);

        }

        [When(@"I  Save the preferences and click on UpdateJourney button")]
        public void WhenISaveThePreferencesAndClickOnUpdateJourneyButton()
        {
            BddHooks.help.ButtonClick(JourneyResultsRepo.eltSavePref);
            BddHooks.help.ButtonClick1(JourneyResultsRepo.eltUpdateJourney);

        }

        [Then(@"I can view my journey details updated successfully")]
        public void ThenICanViewMyJourneyDetailsUpdatedSuccessfully()
        {
            string toPlace = BddHooks.help.getText(JourneyResultsRepo.eltTo);
            string LeavingDate = BddHooks.help.getText(JourneyResultsRepo.eltLeavingDate);
            string leavingDatecon = BddHooks.help.LeavingDateConversion(LeavingDate);
            Assert.AreEqual(dectJourneyPref["Destination"], toPlace);
            Assert.AreEqual(dectJourneyPref["JourneyDate"], leavingDatecon);
            BddHooks.help.WriteLog(BddHooks.currentTime + "Validated updated journey details\n");

        }

        [When(@"I Navigate to Plan My Journey and click on Recents tab")]
        public void WhenINavigateToPlanMyJourneyAndClickOnRecentsTab()
        {
            BddHooks.help.ButtonClick(JourneyResultsRepo.eltPlanmyjourneylink);
        }

        [Then(@"I can view the List of my Recent journey plans")]
        public void ThenICanViewTheListOfMyRecentJourneyPlans()
        {
            Boolean validation = BddHooks.journeyPageHelper.validation(1, PlanJourneyRepo.eltRecentsList);
            if (validation == false)
            {
                BddHooks.planjourneyHelper.planmyjourney(Constants.source, Constants.destination);
                BddHooks.help.ButtonClick(PlanJourneyRepo.eltPlanMyJourneybtn);
                BddHooks.help.waitforpageLoad();
                BddHooks.help.pageScrollUp();
                BddHooks.help.ButtonClick(JourneyResultsRepo.eltPlanmyjourneylink);
                BddHooks.help.pageScrollDown();
            }
            validation = BddHooks.journeyPageHelper.validation(1, PlanJourneyRepo.eltRecentsList);
            Assert.IsTrue(validation);
            BddHooks.help.WriteLog(BddHooks.currentTime + "Validated the Recent Journey plans\n");
        }
    }
}
