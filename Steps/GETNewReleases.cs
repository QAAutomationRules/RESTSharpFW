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
    public sealed class GETNewReleases
    {
        [Given(@"I execute a GET New Releases Request")]
        public void GivenIExecuteAGETNewReleasesRequest()
        {
            IRestResponse response = RESTHelpers.GETWithOAUTH(ConfigurationManager.AppSettings["SpotifyURL"].ToString(),
               ConfigurationManager.AppSettings["NewReleasesResource"].ToString(),
               ScenarioContext.Current.Get<string>("AccountToken"));

            response.Content.Should().NotBeNullOrEmpty();
            response.StatusDescription.Should().Be("OK");

            ScenarioContext.Current.Add("NewReleaseJSON", response.Content);
        }

        [Then(@"the New Release Json is returned from the Spotify API")]
        public void ThenTheNewReleaseJsonIsReturnedFromTheSpotifyAPI()
        {
            Console.WriteLine(ScenarioContext.Current.Get<string>("NewReleaseJSON"));
            JObject jobj2;

            var dir = Environment.CurrentDirectory;

            using (var sr = new StreamReader(Path.Combine(Environment.CurrentDirectory, @"..\\RESTSharpFW\\JSONFiles\\", "NewReleases.json")))
            {
                var reader = new JsonTextReader(sr);
                jobj2 = JObject.Load(reader);
            }

            JObject jobj1 = JObject.Parse(ScenarioContext.Current.Get<string>("NewReleaseJSON"));

            JToken.DeepEquals(jobj1, jobj2).Should().BeTrue();

        }

    }
}
