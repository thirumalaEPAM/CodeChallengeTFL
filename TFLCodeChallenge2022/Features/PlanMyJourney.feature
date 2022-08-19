Feature: As a User I need to plan my Journey

@MyJourney
Scenario Outline: I can plan my journey successfully	
	Given I can enter valid <source> and <destination>
	When I can click on PlanMyJourney button
	Then I can view "Journey results"	

Examples:
| source                      | destination         |
|Penge West Rail Station      | Liverpool Street    |
|Heathrow Airport Terminal 4 | Romford Rail Station|

Scenario: I can not plan my journey without entering Source and Destinations
	Given I launched TFL portal and Enter Journey Time without  giving the source and destions
	When I can click on PlanMyJourney button 
	Then I can view  monadatory fields validations on From and To fields

Scenario: I can not plan my journey with Invalid  Source and Destination locations
	Given I launch TFL portal and Enter Invalid Source and Destination As "XXX" and "YYY"
	When I can click on PlanMyJourney button 
	Then I can not view the Journey results


Scenario: I can change my Plan journey based on Arrival time by using Change Time option
	Given I launched TFL portal and Enter valid Source "Penge West Rail Station" and  Destination "Liverpool Street"
	When Click on ChangeTime Link
	And Select the Arriving Option
	And Select Date "Sat 27 Aug" and Time "07:00"
	And I can click on PlanMyJourney button  
   Then I can view and validate the journey results page	