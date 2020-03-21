using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CpanelUapi.Handler
{
    interface ApiInterface
    {
        RestClient Client { get; set; }
        UApi Uapi {get;set;}
        void setUapi(UApi uapi);
        string getRequest(string path,Dictionary<string, dynamic> parameters);
        JToken parseResult(string response);
        JToken get(string path, Dictionary<string, dynamic> parameters);
    }
}
