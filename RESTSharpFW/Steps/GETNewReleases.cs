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
    public sealed class GETNewReleases
    {
        [Given(@"I execute a GET New Releases Request")]
        public void GivenIExecuteAGETNewReleasesRequest()
        {
            IRestResponse response = RESTHelpers.GETWithOAUTH(ConfigurationManager.AppSettings["SpotifyURL"].ToString(),
               ConfigurationManager.AppSettings["NewReleasesResource"].ToString(), 
               ScenarioContext.Current.Get<string>("AccountToken"));

            response.Content.Should().NotBeNullOrEmpty();
        }


        [Then(@"the New Release Json is returned from the Spotify API")]
        public void ThenTheNewReleaseJsonIsReturnedFromTheSpotifyAPI()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
