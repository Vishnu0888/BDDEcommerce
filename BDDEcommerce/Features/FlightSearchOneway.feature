Feature: FlightSearchOneway
	as a user i am able to search for flights

@mytag
Scenario: Flight Search Oneway	
	Given User is on landing page
	And i select round trip 
	And user select origin as "LON"
	And user select destination "MIA"
	And user select date as "28-January-2023"
	And user click on serach button
	Then user is redirected to listing page