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
    public sealed class GETCategoriesSteps
    {
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef

        [When(@"I execute the GET Categories API call")]
        public void WhenIExecuteTheGETCategoriesAPICall()
        {
            IRestResponse response = RESTHelpers.GETWithOAUTH(ConfigurationManager.AppSettings["SpotifyURL"].ToString(),
               ConfigurationManager.AppSettings["CategoriesResource"].ToString(),
               ScenarioContext.Current.Get<string>("AccountToken"));

            RESTHelpers.Is200OKResponse(response);

            ScenarioContext.Current.Add("CategoriesJSON", response.Content);
        }

        [Then(@"the JSON returned matches what is expected")]
        public void ThenTheJSONReturnedMatchesWhatIsExpected()
        {
            RESTHelpers.CompareJSON("CategoriesJSON", "CategoriesJSON.json");
        }

    }
}
