using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace RESTSharpFW.Steps
{
    [Binding]
    public sealed class SpotifyAPISteps
    {
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef

        [Given(@"I have a URL to the Spotify API")]
        public void GivenIHaveAURLToTheSpotifyAPI()
        {
            ScenarioContext.Current.Add("SpotifyAPIURL", ConfigurationManager.AppSettings["SpotifyURL"]);
        }

    }
}
