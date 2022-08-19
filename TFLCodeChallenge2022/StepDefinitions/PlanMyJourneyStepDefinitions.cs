using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectReporsitoryLibrary;
using NUnit.Framework;

namespace TFLCodeChallenge2022.StepDefinitions
{
    [Binding]
    public class PlanMyJourneyStepDefinitions
    {

        private ScenarioContext _scenarioContext;
              

        public PlanMyJourneyStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(@"I can enter valid (.*) and (.*)")]
        public void GivenICanEnterValidAnd(string source, string destination)
        {           
            _scenarioContext[Constants.Source] = source;
            _scenarioContext[Constants.Destination] = destination;
            BddHooks.planjourneyHelper.planmyjourney(source, destination);
        }

        [Given(@"I launched TFL portal and Enter Journey Time without  giving the source and destions")]
        public void GivenILaunchedTFLPortalAndEnterJourneyTimeWithoutGivingTheSourceAndDestions()
        {  
            BddHooks.help.ButtonClick(PlanJourneyRepo.eltChangeTime);
            BddHooks.help.ButtonClick(PlanJourneyRepo.eltDate);
            BddHooks.help.selectValuefromDropdown(PlanJourneyRepo.eltDate, Constants.journeyDate);
        }

        [Given(@"I launch TFL portal and Enter Invalid Source and Destination As ""([^""]*)"" and ""([^""]*)""")]
        public void GivenILaunchTFLPortalAndEnterInvalidSourceAndDestinationAsAnd(string xXX, string yYY)
        {           
            BddHooks.planjourneyHelper.planmyjourney(xXX, yYY);

        }
        [Given(@"I launched TFL portal and Enter valid Source ""([^""]*)"" and  Destination ""([^""]*)""")]
        public void GivenILaunchedTFLPortalAndEnterValidSourceAndDestination(string p0, string p1)
        {
            _scenarioContext[Constants.Source] = p0;
            _scenarioContext[Constants.Destination] = p1;
            BddHooks.planjourneyHelper.planmyjourney(p0, p1);
        }


        [When(@"I can click on PlanMyJourney button")]
        public void WhenICanClickOnPlanMyJourneyButton()
        {            
            BddHooks.help.ButtonClick(PlanJourneyRepo.eltPlanMyJourneybtn);
            BddHooks.help.waitforpageLoad();
        }

        [When(@"Click on ChangeTime Link")]
        public void WhenClickOnChangeTimeLink()
        {            
            BddHooks.help.ButtonClick(PlanJourneyRepo.eltChangeTime);
        }

        [When(@"Select the Arriving Option")]
        public void WhenSelectTheArrivingOption()
        {
           
            BddHooks.help.ButtonClick(PlanJourneyRepo.eltArrivingbtn);
        }

        [When(@"Select Date ""([^""]*)"" and Time ""([^""]*)""")]
        public void WhenSelectDateAndTime(string p0, string p1)
        {
            BddHooks.help.ButtonClick(PlanJourneyRepo.eltDate);
            BddHooks.help.selectValuefromDropdown(PlanJourneyRepo.eltDate, p0);
            BddHooks.help.ButtonClick(PlanJourneyRepo.eltTime);
            BddHooks.help.selectValuefromDropdown(PlanJourneyRepo.eltTime, p1);

        }

        [Then(@"I can view and validate the journey results page")]
        public void ThenICanViewAndValidateTheJourneyResultsPage()
        {
            string journeyresultsTxt = BddHooks.help.getText(JourneyResultsRepo.eltJourneypage);
            string fromPlace = BddHooks.help.getText(JourneyResultsRepo.eltFrom);
            string toPlace = BddHooks.help.getText(JourneyResultsRepo.eltTo);
            Assert.AreEqual(Constants.journeyResults, journeyresultsTxt);
            Assert.AreEqual(_scenarioContext[Constants.Source].ToString(), fromPlace);
            Assert.AreEqual(_scenarioContext[Constants.Destination].ToString(), toPlace);
            Assert.IsTrue(BddHooks.journeyPageHelper.ValidationJourneyResults());
            BddHooks.help.WriteLog(System.DateTime.Now + ": Validation is done in Journey results page \n");
        }


        [Then(@"I can view ""([^""]*)""")]
        public void ThenICanView(string p0)
        {           
            string journeyresultsTxt = BddHooks.help.getText(JourneyResultsRepo.eltJourneypage);
            string fromPlace = BddHooks.help.getText(JourneyResultsRepo.eltFrom);
            string toPlace = BddHooks.help.getText(JourneyResultsRepo.eltTo);
            Assert.AreEqual(p0, journeyresultsTxt);
            Assert.AreEqual(_scenarioContext[Constants.Source].ToString(), fromPlace);
            Assert.AreEqual(_scenarioContext[Constants.Destination].ToString(), toPlace);
            Assert.IsTrue(BddHooks.journeyPageHelper.ValidationJourneyResults());
            BddHooks.help.WriteLog(System.DateTime.Now + ": Validation is done in Journey results page \n");
        }

        [Then(@"I can view  monadatory fields validations on From and To fields")]
        public void ThenICanViewMonadatoryFieldsValidationsOnFromAndToFields()
        {
            string fromValidation = BddHooks.help.getText(PlanJourneyRepo.eltFromvalidation);
            string toValidation = BddHooks.help.getText(PlanJourneyRepo.eltTovalidation);
            Assert.AreEqual(Constants.fromFieldValidation, fromValidation);
            Assert.AreEqual(Constants.toFieldValidation, toValidation);

            BddHooks.help.WriteLog(System.DateTime.Now +  " : Mandatory fields validation done\n ");
        }

        [Then(@"I can not view the Journey results")]
        public void ThenICanNotViewTheJourneyResults()
        {
            string validationError = BddHooks.help.getText(PlanJourneyRepo.eltValidationError);
            Assert.AreEqual(Constants.InvalidJourneyerror, validationError);
            BddHooks.help.WriteLog(System.DateTime.Now + " : Validated the Error validation\n");

        }
    }
}
