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
    public sealed class GETArtistsStepscs
    {
        [When(@"I execute the GET Artists request")]
        public void WhenIExecuteTheGETArtistsRequest()
        {
            IRestResponse response = RESTHelpers.GETWithOAUTH(ConfigurationManager.AppSettings["SpotifyURL"].ToString(),
               ConfigurationManager.AppSettings["ArtistsResource"].ToString(),
               ScenarioContext.Current.Get<string>("AccountToken"));

            RESTHelpers.ValidResponse(response);

            ScenarioContext.Current.Add("ArtistsJSON", response.Content);
        }


        [Then(@"the Artists are displayed correctly in the JSON that is returned")]
        public void ThenTheArtistsAreDisplayedCorrectlyInTheJSONThatIsReturned()
        {
            RESTHelpers.CompareJSON("ArtistsJSON", "ArtistsJSON.json");
        }

    }
}
