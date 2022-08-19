# Project name : TFLCodeChallenge
## Pre-Requisites for project execution
- Visual Studio 2022
- Latest Chrome Driver version 104.0.5112.7900

## 01 - Automation Framework design Approach

###### IDE & Language
   - Visual Studio 2022 & C#
###### Automation Tool
   - Selenium WebDriver
###### Project Type
   - BDD-SpecFlow
###### Design Pattern
   - Singleton with POM
###### DataDriven
   - Scenario Outline
###### Reports & Logs
   - Extent Reports
   - Logs are maintaining in separate text file
###### Browsers
   - Chrome Driver
## 02 - Test Scenarios

- Scenario 1: I can plan my journey successfully	

- Scenario 2: I can not plan my journey without entering Source and Destinations	

- Scenario 3: I can not plan my journey with Invalid  Source and Destination locations

- Scenario 4: I can change my Planjourney based on Arrival time by using ChangeTime option

- Scenario 5: I can edit my journy details and preferences

- Scenario 6:  I can view My recent journey plans

 ## 03 - Brief Description about framework Approach
 - Reports created using ExtentReports and ScreenShots captured for failed scenarios
 - Logs are maintaning in separate text file
 - In Project solution 
 
     ###### 1. ObjectRepsitoryLibrary : 
      which contains common utilities, locators (defined in page classfiles), SingletonBaseclass 
       
    ###### 2. HelperLibrary : 
     which contains the methods which are specific to the respective pages
       
    ###### 4. BDDFramework(SpecFlow Project) 
       Feature files : We can include all scenarios in Feature files
       Stepdefination files : We can define all scenarios under stepdefination class files
       BddHooks : We write code snippets that run before or after each scenario/step/Test

