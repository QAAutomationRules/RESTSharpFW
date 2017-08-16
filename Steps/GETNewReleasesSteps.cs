using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RESTSharpFW.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace RESTSharpFW.Steps
{
    [Binding]
    public sealed class GETNewReleasesSteps
    {
        [When(@"I execute a GET New Releases Request")]
        public void WhenIExecuteAGETNewReleasesRequest()
        {
            IRestResponse response = RESTHelpers.GETWithOAUTH(ConfigurationManager.AppSettings["SpotifyURL"].ToString(),
               ConfigurationManager.AppSettings["NewReleasesResource"].ToString(),
               ScenarioContext.Current.Get<string>("AccountToken"));

            RESTHelpers.ValidResponse(response);

            ScenarioContext.Current.Add("NewReleaseJSON", response.Content);
        }


        [Then(@"the New Release Json is returned from the Spotify API")]
        public void ThenTheNewReleaseJsonIsReturnedFromTheSpotifyAPI()
        {
            RESTHelpers.CompareJSON("NewReleaseJSON", "NewReleases.json");
        }

    }
}
