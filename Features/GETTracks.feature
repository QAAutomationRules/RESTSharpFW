Feature: GET Tracks
	
	As a Spotify API Consumer
	I want to be able to retrieve Tracks

Background: Get a Token
	Given I get a valid token back from the Accounts API

@GET
Scenario: GET Tracks from the Spotify API
	Given I have a URL to the Spotify API
	When I execute a GET Tracks request
	Then the Tracks are returned in the JSON
