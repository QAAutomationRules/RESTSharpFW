using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace RESTSharpFW.Helpers
{
    public class RESTHelpers
    {

        public IRestResponse GET(string url)
        {
            var client = new RestClient(url);
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest("resource/{id}", Method.POST);

            // execute the request
            IRestResponse response = client.Execute(request);

            return response;

        }

        public IRestResponse PUT(string url)
        {
            var client = new RestClient(url);
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest("resource/{id}", Method.POST);

            // execute the request
            IRestResponse response = client.Execute(request);

            return response;

        }

        public IRestResponse POST(string url)
        {
            var client = new RestClient(url);
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest("resource/{id}", Method.POST);

            // execute the request
            IRestResponse response = client.Execute(request);

            return response;

        }

        public IRestResponse DELETE(string url)
        {
            var client = new RestClient(url);
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest("resource/{id}", Method.POST);
            
            // execute the request
            IRestResponse response = client.Execute(request);

            return response;

        }
    }
}
