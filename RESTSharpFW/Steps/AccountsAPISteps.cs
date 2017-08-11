﻿using System;
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
            IRestResponse response = RESTHelpers.POSTNoAuth(
               ConfigurationManager.AppSettings["AccountsAPIURL"].ToString(),
               ConfigurationManager.AppSettings["TokenResource"].ToString(),
               ConfigurationManager.AppSettings["ClientID"].ToString(),
               ConfigurationManager.AppSettings["ClientSecret"].ToString());

            var accessToken = JsonConvert.DeserializeObject<AccessToken>(response.Content);

            ScenarioContext.Current.Set<string>("AccountToken", accessToken.Access_Token);

        }


    }
}
