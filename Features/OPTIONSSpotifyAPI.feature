Feature: OPTIONS Spotify API
	
	As a Spotify API Consumer
	I want to be able to Execute OPTIONs Calls on the Spotify API

@OPTIONS
Scenario: OPTIONS call returns supported HTTP Verbs
	Given I have a URL to the Spotify API
	When I execute an Options request
	Then the supported HTTP Verbs are returned
