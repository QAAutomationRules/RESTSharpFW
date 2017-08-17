using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using RestSharp;
using RESTSharpFW.Helpers;
using TechTalk.SpecFlow;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RESTSharpFW.Data;

namespace RESTSharpFW.Steps
{
    

[Binding]
    public sealed class AccountsAPISteps
    {
        

        [Given(@"I get a valid token back from the Accounts API")]
        public void GivenIGetAValidTokenBackFromTheAccountsAPI()
        {
            IRestResponse response = RESTHelpers.POST(
               ConfigurationManager.AppSettings["AccountsAPIURL"].ToString(),
               ConfigurationManager.AppSettings["TokenResource"].ToString(),
               ConfigurationManager.AppSettings["ClientID"].ToString(),
               ConfigurationManager.AppSettings["ClientSecret"].ToString());

            var accessToken = JsonConvert.DeserializeObject<AccessToken>(response.Content);

            ScenarioContext.Current.Set(accessToken.Access_Token, "AccountToken");

        }

        [Given(@"I get an OAuth Token from the Accounts API")]
        public void GivenIGetAnOAuthTokenFromTheAccountsAPI()
        {
            IRestResponse response = RESTHelpers.GETOAUTH(
                ConfigurationManager.AppSettings["AccountsAPIURL"].ToString(),
                ConfigurationManager.AppSettings["AuthorizeResource"].ToString(),
                ConfigurationManager.AppSettings["ClientID"].ToString());

            //var modifyToken = JsonConvert.DeserializeObject<ModifyToken>(response.Content);

            //ScenarioContext.Current.Set(modifyToken, "ModifyToken");
        }



    }
}
