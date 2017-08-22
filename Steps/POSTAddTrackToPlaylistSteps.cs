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
    public sealed class POSTAddTrackToPlaylistSteps
    {
        [Then(@"I Add a Track To the New Playlist")]
        public void ThenIAddATrackToTheNewPlaylist()
        {
            IRestResponse response = RESTHelpers.POSTAddTracksToPlaylist(
               ConfigurationManager.AppSettings["SpotifyURL"].ToString(),
               ConfigurationManager.AppSettings["PlayListResource"].ToString(),
               ConfigurationManager.AppSettings["ModifyToken"]
               );

            RESTHelpers.Is201CreatedResponse(response);

            ScenarioContext.Current.Add("POSTPlayListTracksJSONResponse", response.Content);
        }

    }
}
