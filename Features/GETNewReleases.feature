Feature: GET New Releases
	In order to get new release music
	As a Spotify customer
	I want to be able to retrieve new releases

Background: Get a Token
	Given I get a valid token back from the Accounts API

@GET @SpotifyAPI
Scenario: GET the list of New Releases on Spotify
	Given I have a URL to the Spotify API
	When I execute a GET New Releases Request
	Then the New Release Json is returned from the Spotify API
