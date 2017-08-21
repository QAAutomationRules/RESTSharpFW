using FluentAssertions;
using RestSharp;
using RESTSharpFW.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace RESTSharpFW.Steps
{
    [Binding]
    public sealed class POSTNewPlaylistSteps
    {
        [When(@"I POST a New Playlist to the Spotify API")]
        public void WhenIPOSTANewPlaylistToTheSpotifyAPI()
        {
            IRestResponse response = RESTHelpers.POSTOAUTHHeaderToken(
               ConfigurationManager.AppSettings["SpotifyURL"].ToString(),
               ConfigurationManager.AppSettings["PlayListResource"].ToString(),
               ConfigurationManager.AppSettings["ModifyToken"],
               "POSTPlayListPublicJSON.json"
               );

            RESTHelpers.Is201CreatedResponse(response);

            ScenarioContext.Current.Add("PlayListJSONResponse", response.Content);
        }

        [Then(@"the New Playlist is persisted to Spotify")]
        public void ThenTheNewPlaylistIsPersistedToSpotify()
        {
            ScenarioContext.Current.Get<string>("PlayListJSONResponse")
                .Should().Contain("New playlist description 11");

            ScenarioContext.Current.Get<string>("PlayListJSONResponse")
                .Should().Contain("New Playlist11");
           

        }


    }
}
