Feature: POST New PlayList
	
	As a math idiot
	I want to be told the sum of two numbers

@POST
Scenario: POST a New Playlist to the Spotify API
	Given I have a URL to the Spotify API
	When I POST a New Playlist to the Spotify API
	Then the New Playlist is persisted to Spotify
