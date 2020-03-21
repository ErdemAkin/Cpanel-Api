using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;

namespace CpanelUapi.Handler
{
    class ApiAbstract : ApiInterface
    {
        public RestClient Client { get; set; }
        public UApi Uapi { get; set; }

        public void setUapi(UApi uapi)
        {
            Uapi = uapi;
            Client = new RestClient(uapi.CpanelHostname);
            Client.Authenticator = new HttpBasicAuthenticator(uapi.CpanelUsername, uapi.CpanelPassword);
        }

        public string getRequest(string path, Dictionary<string, dynamic> parameters)
        {
            var request = new RestRequest(path);
            foreach (KeyValuePair<string, dynamic> item in parameters)
            {
                request.AddParameter(item.Key, item.Value, ParameterType.QueryString);
            }

            IRestResponse response = Client.Get(request);
            return response.Content;
        }

        public JToken parseResult(string response)
        {
            if (response is null)
            {
                throw new NullReferenceException("Unknown error occured");
            }

            if(! isValidJson(response))
            {
                System.IO.File.WriteAllText("C:\\Users\\erdem\\Desktop\\test.html", response);
                throw new Exception("Bilinmeyen Hata");
            }

            JObject parsejson = JObject.Parse(response);

            if (parsejson.SelectToken("status") != null && parsejson.SelectToken("status").ToString() == "0")
            {
                throw new Exception(parsejson.SelectToken("errors").ToString());
            }

            return parsejson.SelectToken("data");
        }

        public JToken get(string path, Dictionary<string, dynamic> parameters)
        {
            string response = this.getRequest(path, parameters);

            return this.parseResult(response);
        }

        protected bool isValidJson(string strInput)
        {
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || //For object
                (strInput.StartsWith("[") && strInput.EndsWith("]"))) //For array
            {
                try
                {
                    var obj = JToken.Parse(strInput);
                    return true;
                }
                catch (JsonReaderException jex)
                {
                    return false;
                }
                catch (Exception ex) //some other exception
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


    }
}
