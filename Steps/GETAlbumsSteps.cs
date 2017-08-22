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
    public sealed class GETAlbumsSteps
    {
        [When(@"I execute the GET Albums request")]
        public void WhenIExecuteTheGETAlbumsRequest()
        {
            IRestResponse response = RESTHelpers.GETWithOAUTH(ConfigurationManager.AppSettings["SpotifyURL"].ToString(),
               ConfigurationManager.AppSettings["AlbumsResource"].ToString(),
               ScenarioContext.Current.Get<string>("AccountToken"));

            RESTHelpers.Is200OKResponse(response);

            ScenarioContext.Current.Add("AlbumsJSON", response.Content);

        }

        [Then(@"the Albums are returned in the JSON Data")]
        public void ThenTheAlbumsAreReturnedInTheJSONData()
        {
            RESTHelpers.CompareJSON("AlbumsJSON", "AlbumsJSON.json");
        }


    }
}
