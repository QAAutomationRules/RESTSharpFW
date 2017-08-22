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
    public sealed class PUTPlaylistDetailsSteps
    {
        [When(@"I execute a PUT on Playlist Details of an existing Playlist")]
        public void WhenIExecuteAPUTOnPlaylistDetailsOfAnExistingPlaylist()
        {
            IRestResponse response = RESTHelpers.PUTPlaylistWithAuthHeader(
               ConfigurationManager.AppSettings["SpotifyURL"].ToString(),
               ConfigurationManager.AppSettings["PlayListResource"].ToString(),
               ConfigurationManager.AppSettings["ModifyToken"],
               "PUTPlayListPublicJSON.json"
               );

            RESTHelpers.Is201CreatedResponse(response);

            ScenarioContext.Current.Add("PUTPlayListJSONResponse", response.Content);
        }

        [Then(@"the Playlist details are updated")]
        public void ThenThePlaylistDetailsAreUpdated()
        {

            var response = ScenarioContext.Current.Get<string>("PUTPlayListJSONResponse");

            var updatedPlaylistResponse = RESTHelpers.GetJObject(response);

            updatedPlaylistResponse.GetValue("id").ToString().Should().NotBe(ScenarioContext.Current.Get<string>("NewPlaylistID"));

            updatedPlaylistResponse.GetValue("public").ToString().Should().Be("False");

            updatedPlaylistResponse.GetValue("description").ToString().Should().Be("Updated playlist description");

            updatedPlaylistResponse.GetValue("name").ToString().Should().Be("Updated Playlist Name");
        }

    }
}
