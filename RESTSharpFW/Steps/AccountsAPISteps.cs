using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using RestSharp;
using RESTSharpFW.Helpers;
using TechTalk.SpecFlow;

namespace RESTSharpFW.Steps
{
    [Binding]
    public sealed class AccountsAPISteps
    {
        [Given(@"I create a valid POST request to use against the Accounts API")]
        public void GivenICreateAValidPOSTRequestToUseAgainstTheAccountsAPI()
        {

            IRestResponse response = RESTHelpers.POSTNoAuth(ConfigurationManager.AppSettings["AccountsAPIURL"],
                ConfigurationManager.AppSettings["TokenResource"], "grant_type=client_credentials&client_id=" + 
                ConfigurationManager.AppSettings["ClientID"] + "&client_secret=" + ConfigurationManager.AppSettings["ClientSecret"]);
            
            ScenarioContext.Current.Set("AccountToken", response.Content);

        }

    }
}
