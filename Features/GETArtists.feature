Feature: GET Artists
	
	As a Spotify API Consumer
	I want to be able to retrieve Artists

Background: Get a Token
	Given I get a valid token back from the Accounts API

@GET
Scenario: GET Artists request returns Artists in the Spotify users Profile
	Given I have a URL to the Spotify API
	When I execute the GET Artists request
	Then the Artists are displayed correctly in the JSON that is returned
