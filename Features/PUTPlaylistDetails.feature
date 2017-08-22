Feature: PUT Playlist Details
	
	As a Spotify API consumer
	I want to be able to update Playlist Details

@PUT
Scenario: Update Playlist Details
	Given I have a URL to the Spotify API
	When I POST a New Playlist to the Spotify API
	Then I capture the New Playlist ID
	When I execute a PUT on Playlist Details of an existing Playlist
	Then the Playlist details are updated
