Feature: Delete Tracks From Playlist
	
	As a Spotify API Consumer
	I want to be able to Delete Tracks from a playlist

@DELETE
Scenario: Delete track from Playlist
	Given I have a URL to the Spotify API
    When I POST a New Playlist to the Spotify API
	Then I capture the New Playlist ID
	And I Add a Track To the New Playlist
	When I run the Delete Track from playlist request
	Then the track no longer exists in the playlist
