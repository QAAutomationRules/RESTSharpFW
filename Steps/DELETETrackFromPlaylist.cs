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
    public sealed class DELETETrackFromPlaylist
    {
        [When(@"I run the Delete Track from playlist request")]
        public void WhenIRunTheDeleteTrackFromPlaylistRequest()
        {
            IRestResponse response = RESTHelpers.DELETETrackFromPlaylist(
              ConfigurationManager.AppSettings["SpotifyURL"].ToString(),
              ConfigurationManager.AppSettings["PlayListResource"].ToString(),
              ConfigurationManager.AppSettings["ModifyToken"],
              "DELETETrackFromPlaylist.json"
              );

            RESTHelpers.IsValidOKResponse(response);

            ScenarioContext.Current.Add("DELETEPlayListTracksJSONResponse", response.Content);
        }

        [Then(@"the track no longer exists in the playlist")]
        public void ThenTheTrackNoLongerExistsInThePlaylist()
        {
            IRestResponse response = RESTHelpers.GETPlaylist(
                ConfigurationManager.AppSettings["SpotifyURL"].ToString(),
              ConfigurationManager.AppSettings["PlayListResource"].ToString(),
              ConfigurationManager.AppSettings["ModifyToken"]
              );

            RESTHelpers.IsValidOKResponse(response);

            response.Content.Contains("4iV5W9uYEdYUVa79Axb7Rh").Should().BeFalse();

        }

    }
}
