using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using FluentAssertions;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TechTalk.SpecFlow;
using System.Web.Script.Serialization;

namespace RESTSharpFW.Helpers
{
    public class RESTHelpers
    {

        public static IRestResponse OPTIONSNoAuth(string url, string resource)
        {
            var client = new RestClient(url);

            var request = new RestRequest(resource, Method.OPTIONS);

            // execute the request
            IRestResponse response = client.Execute(request);

            return response;

        }

        public static IRestResponse GETNoAuth(string url, string resource)
        {
            var client = new RestClient(url);
            
            var request = new RestRequest(resource, Method.GET);

            // execute the request
            IRestResponse response = client.Execute(request);

            return response;

        }

        public static IRestResponse GETBasicAuthentication(string url, string resource, string userName, string password)
        {
            var client = new RestClient(url);
            client.Authenticator = new HttpBasicAuthenticator(userName, password);

            var request = new RestRequest(resource, Method.GET);

            // execute the request
            IRestResponse response = client.Execute(request);

            return response;

        }

        public static IRestResponse GETWithOAUTH(string url, string resource,
            string token)
        {
            var client = new RestClient(url);
            
            var request = new RestRequest(resource, Method.GET);

            request.AddHeader("Authorization", "Bearer " + token);

            // execute the request
            IRestResponse response = client.Execute(request);

            return response;

        }

        public static IRestResponse GETPlaylist(string url, string resource,
            string token)
        {
            var client = new RestClient(url);

            var request = new RestRequest(resource + "/" + ScenarioContext.Current.Get<string>("NewPlaylistID"), Method.GET);

            request.AddHeader("Authorization", "Bearer " + token);

            // execute the request
            IRestResponse response = client.Execute(request);

            return response;

        }

        public static IRestResponse PUTNoAuth(string url, string resource, string body)
        {
            var client = new RestClient(url);
            
            var request = new RestRequest(resource, Method.PUT);

            // execute the request
            IRestResponse response = client.Execute(request);

            return response;

        }

        public static IRestResponse PUTBasicAuth(string url, string resource,
            string userName, string password, string body)
        {
            var client = new RestClient(url);
            client.Authenticator = new HttpBasicAuthenticator(userName, password);

            var request = new RestRequest(resource, Method.PUT);
            request.AddBody(body);

            // execute the request
            IRestResponse response = client.Execute(request);

            return response;

        }

        public static IRestResponse PUTPlaylistWithAuthHeader(string url, string resource,
            string token, string body)
        {
            var client = new RestClient(url);

            var request = new RestRequest(resource, Method.POST);

            //OAUTH Token
            request.AddHeader("Authorization", "Bearer " + token);
            request.AddHeader("Content-type", "application/json");
            
            //add Playlist ID as Query Parameter
            request.AddQueryParameter("PlaylistID", ScenarioContext.Current.Get<string>("NewPlaylistID"));

            var jBody = GetJSONStringFromFile(body);

            //Add Body
            request.AddParameter("application/json; charset=utf-8",
                jBody, ParameterType.RequestBody);

            // execute the request
            IRestResponse response = client.Execute(request);

            return response;

        }

        public static IRestResponse POST(string url, string resource,
            string clientID = "", string clientSecret = "")
        {
            var client = new RestClient(url);
            
            var request = new RestRequest(resource, Method.POST);
            request.AddParameter("grant_type", "client_credentials");

            if (clientID != "" || clientSecret != "")
            {
                request.AddParameter("client_id", clientID);
                request.AddParameter("client_secret", clientSecret);
            }

            // execute the request
            IRestResponse response = client.Execute(request);

            return response;

        }

        public static IRestResponse GETOAUTH(string url, string resource,
            string clientID)
        {
            var client = new RestClient(url);

            var request = new RestRequest(resource, Method.GET);

            request.AddQueryParameter("client_id", clientID);
            request.AddQueryParameter("redirect_uri", ConfigurationManager.AppSettings["Redirect_URI"]);
            request.AddQueryParameter("response_type", ConfigurationManager.AppSettings["Response_Type"]);
            request.AddQueryParameter("scope", ConfigurationManager.AppSettings["Scope"]);


            // execute the request
            IRestResponse response = client.Execute(request);

            return response;

        }

        public static IRestResponse POSTWithOAUTHToken(string url, string resource, string token)
        {
            var client = new RestClient(url);

            var request = new RestRequest(resource, Method.POST);
            //request.AddParameter("grant_type", "client_credentials");

            //OAUTH Token
            request.AddParameter("Authorization", "Bearer " + token);

            // execute the request
            IRestResponse response = client.Execute(request);

            return response;

        }
         
        public static IRestResponse POSTOAUTHHeaderToken(string url, string resource, 
            string token, string body)
        {
            var client = new RestClient(url);

            var request = new RestRequest(resource, Method.POST);

            //OAUTH Token
            request.AddHeader("Authorization", "Bearer " + token);
            request.AddHeader("Content-type", "application/json");

            var jBody = GetJSONStringFromFile(body);

            //Add Body
            request.AddParameter("application/json; charset=utf-8", 
                jBody, ParameterType.RequestBody);

            // execute the request
            IRestResponse response = client.Execute(request);

            return response;

        }

        public static IRestResponse POSTAddTracksToPlaylist(string url, string resource,
            string token)
        {
            var client = new RestClient(url);

            var request = new RestRequest(resource + "/" + ScenarioContext.Current.Get<string>("NewPlaylistID") + "/tracks", Method.POST);

            //OAUTH Token
            request.AddHeader("Authorization", "Bearer " + token);
            request.AddHeader("Content-type", "application/json");

            request.AddQueryParameter("uris", ConfigurationManager.AppSettings["AddTracksQueryParameters"]);

            
            // execute the request
            IRestResponse response = client.Execute(request);

            return response;

        }
      

        public static IRestResponse POSTBasicAuth(string url, string resource, 
            string userName, string password, string body)
        {
            var client = new RestClient(url);
            client.Authenticator = new HttpBasicAuthenticator(userName, password);

            var request = new RestRequest(resource, Method.POST);
            request.AddBody(body);

            // execute the request
            IRestResponse response = client.Execute(request);

            return response;

        }

        public static IRestResponse DELETETrackFromPlaylist(string url, string resource,
           string token, string body)
        {
            var client = new RestClient(url);

            var request = new RestRequest(resource + "/" + ScenarioContext.Current.Get<string>("NewPlaylistID") + "/tracks", Method.DELETE);

            //OAUTH Token
            request.AddHeader("Authorization", "Bearer " + token);
            request.AddHeader("Content-type", "application/json");

            var jBody = GetJSONStringFromFile(body);

            //Add Body
            request.AddParameter("application/json; charset=utf-8",
                jBody, ParameterType.RequestBody);


            // execute the request
            IRestResponse response = client.Execute(request);

            return response;

        }

        public static IRestResponse DELETENoAuth(string url, string resource)
        {
            var client = new RestClient(url);
            
            var request = new RestRequest(resource, Method.DELETE);
            
            // execute the request
            IRestResponse response = client.Execute(request);

            return response;

        }

        public static IRestResponse DELETEBasicAuth(string url, string resource,
            string userName, string password)
        {
            var client = new RestClient(url);
            client.Authenticator = new HttpBasicAuthenticator(userName, password);

            var request = new RestRequest(resource, Method.DELETE);

            // execute the request
            IRestResponse response = client.Execute(request);

            return response;

        }

        
        public static void Is200OKResponseNoContent(IRestResponse response)
        {
            response.Content.Should().BeEmpty();
            response.StatusDescription.Should().Be("OK");
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        public static void Is200OKResponse(IRestResponse response)
        {
            response.Content.Should().NotBeNullOrEmpty();
            response.StatusDescription.Should().Be("OK");
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        public static void Is201CreatedResponse(IRestResponse response)
        {
            response.Content.Should().NotBeNullOrEmpty();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
            response.StatusDescription.Should().Be("Created");
        }

        public static void Is202AcceptedResponse(IRestResponse response)
        {
            response.Content.Should().NotBeNullOrEmpty();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Accepted);
        }

        public static void Is302FoundResponse(IRestResponse response)
        {
            response.Content.Should().NotBeNullOrEmpty();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Found);
        }

        public static void Is302RedirectResponse(IRestResponse response)
        {
            response.Content.Should().NotBeNullOrEmpty();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Redirect);
        }

        public static void Is304NotModifiedResponse(IRestResponse response)
        {
            response.Content.Should().NotBeNullOrEmpty();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotModified);
        }

        public static void Is400BadRequestResponse(IRestResponse response)
        {
            response.Content.Should().NotBeNullOrEmpty();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }

        public static void Is401UnauthorizedResponse(IRestResponse response)
        {
            response.Content.Should().NotBeNullOrEmpty();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Unauthorized);
        }

        public static void Is403ForbiddenResponse(IRestResponse response)
        {
            response.Content.Should().NotBeNullOrEmpty();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Forbidden);
        }

        public static void Is404NotFoundResponse(IRestResponse response)
        {
            response.Content.Should().NotBeNullOrEmpty();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }

        public static void Is500InternalServerErrorResponse(IRestResponse response)
        {
            response.Content.Should().NotBeNullOrEmpty();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.InternalServerError);
        }

        public static void Is502BadGatewayResponse(IRestResponse response)
        {
            response.Content.Should().NotBeNullOrEmpty();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadGateway);
        }

        public static void Is503ServiceUnavailableResponse(IRestResponse response)
        {
            response.Content.Should().NotBeNullOrEmpty();
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.ServiceUnavailable);
        }


        public static void CompareJSON(string JSONFromAPI, string JSONFile)
        {
            //write the response JSON to the Console
            Console.WriteLine(ScenarioContext.Current.Get<string>(JSONFromAPI));

            //Parse the JSON response to a JObject
            JObject jobjReturnedFromAPI = JObject.Parse(ScenarioContext.Current.Get<string>(JSONFromAPI));

            JToken.DeepEquals(jobjReturnedFromAPI, GetJSONBodyFromFile(JSONFile))
                .Should().BeTrue();
        }

        public static void ContainsJSON(string JSONFromAPI, string JSONFile)
        {
            //write the response JSON to the Console
            Console.WriteLine(ScenarioContext.Current.Get<string>(JSONFromAPI));

            //Parse the JSON response to a JObject
            JObject jobjReturnedFromAPI = JObject.Parse(ScenarioContext.Current.Get<string>(JSONFromAPI));

            
            JObject.DeepEquals(jobjReturnedFromAPI, GetJSONBodyFromFile(JSONFile))
                .Should().BeTrue();
        }

        public static JObject GetJSONBodyFromFile(string JSONFile)
        {
            //Parse the JSON file to a JObject
            JObject jobjFromJSONFile;

            var dir = Environment.CurrentDirectory;

            using (var sr = new StreamReader(Path.Combine(Environment.CurrentDirectory, @"JSONFiles/", JSONFile)))
            {
                var reader = new JsonTextReader(sr);
                jobjFromJSONFile = JObject.Load(reader);
            }

            return jobjFromJSONFile;
        }

        public static JObject GetJObject(string json)
        {
            
            var jobjFromJSON = JObject.Parse(json); 
            

            return jobjFromJSON;
        }

        public static JObject GetJSONStringFromFile(string JSONFile)
        {
            //Parse the JSON file to a JObject
            JObject jobjFromJSONFile;

            var dir = Environment.CurrentDirectory;

            using (var sr = new StreamReader(Path.Combine(Environment.CurrentDirectory, @"JSONFiles/", JSONFile)))
            {
                var reader = new JsonTextReader(sr);
                jobjFromJSONFile = JObject.Load(reader);
            }

            return jobjFromJSONFile;
        }
    }
}
