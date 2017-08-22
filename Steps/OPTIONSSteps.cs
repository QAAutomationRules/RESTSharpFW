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
    public sealed class OPTIONSSteps
    {
        [When(@"I execute an Options request")]
        public void WhenIExecuteAnOptionsRequest()
        {
            IRestResponse response = RESTHelpers.OPTIONSNoAuth
                (
                    ConfigurationManager.AppSettings["SpotifyURL"].ToString(),
                    ConfigurationManager.AppSettings["MeURL"].ToString()
                );

            RESTHelpers.Is200OKResponseNoContent(response);
        }

        [Then(@"the supported HTTP Verbs are returned")]
        public void ThenTheSupportedHTTPVerbsAreReturned()
        {
            
        }

    }
}
