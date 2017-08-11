using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using FluentAssertions;

namespace RESTSharpFW.Helpers
{
    public class RESTHelpers
    {

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

            request.AddParameter("Authorization", "Bearer " + token);

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

        public static IRestResponse POSTNoAuth(string url, string resource,
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

            response.Should().NotBeNull();
            response.StatusDescription.Should().Be("OK");

            return response;

        }

        public static IRestResponse POSTWithOAUTHToken(string url, string resource, string token)
        {
            var client = new RestClient(url);

            var request = new RestRequest(resource, Method.POST);
            request.AddParameter("grant_type", "client_credentials");

            //OAUTH Token
            request.AddParameter("Authorization", "Bearer " + token);

            // execute the request
            IRestResponse response = client.Execute(request);

            response.Should().NotBeNull();
            response.StatusDescription.Should().Be("OK");

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
    }
}
