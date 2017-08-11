Feature: SpotifyAccountsAPI
	In order to get API Tokens
	As a Spotify API user
	I want to be able to use the Accounts API to get Authorization Tokens

@Accounts
Scenario: Accounts API Returns OAuth Token
	Given I create a valid POST request to use against the Accounts API
	When I execute the POST Request
	Then the OAUTH Token is returned
