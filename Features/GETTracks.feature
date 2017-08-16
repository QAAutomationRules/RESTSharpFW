Feature: GET Tracks
	
	As a Spotify API Consumer
	I want to be able to retrieve Tracks

Background: Get a Token
	Given I get a valid token back from the Accounts API

@GET
Scenario: Add two numbers
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen
