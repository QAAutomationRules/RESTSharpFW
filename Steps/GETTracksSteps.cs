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
    public sealed class GETTracksSteps
    {
        [When(@"I execute a GET Tracks request")]
        public void WhenIExecuteAGETTracksRequest()
        {
            IRestResponse response = RESTHelpers.GETWithOAUTH(ConfigurationManager.AppSettings["SpotifyURL"].ToString(),
               ConfigurationManager.AppSettings["TracksResource"].ToString(),
               ScenarioContext.Current.Get<string>("AccountToken"));

            RESTHelpers.IsValidOKResponse(response);

            ScenarioContext.Current.Add("TracksJSON", response.Content);
        }

        [Then(@"the Tracks are returned in the JSON")]
        public void ThenTheTracksAreReturnedInTheJSON()
        {
            RESTHelpers.CompareJSON("TracksJSON", "TracksJSON.json");
        }

    }
}
