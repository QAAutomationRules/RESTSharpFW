Feature: GET Albums

	As a Spotify API Consumer
	I want to be able to retrieve Albums

Background: Get a Token
	Given I get a valid token back from the Accounts API

@GET
Scenario: GET Albums from the Spotify API
	Given I have a URL to the Spotify API
	When I execute the GET Albums request
	Then the Albums are returned in the JSON Data
