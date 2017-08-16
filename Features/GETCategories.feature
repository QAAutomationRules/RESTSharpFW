Feature: GET Categories
	
	As a Spotify API Consumer
	I want to be able to retrieve Music Categories

Background: Get a Token
	Given I get a valid token back from the Accounts API

@GET
Scenario: GET Categories request returns Categories JSON from the Spotify API
	Given I have a URL to the Spotify API
	When I execute the GET Categories API call
	Then the JSON returned matches what is expected
