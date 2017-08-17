Feature: SpotifyAccountsAPI
	In order to get API Tokens
	As a Spotify API user
	I want to be able to use the Accounts API to get Authorization Tokens

@Accounts
Scenario: Accounts API Returns OAuth Token
	Given I get a valid token back from the Accounts API
	
	
Scenario: Accounts API GET OAUTH for doing stuff
	Given I get an OAuth Token from the Accounts API