using CpanelUapi.Api;
using CpanelUapi.Factory;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace CpanelUapi
{
    class CpanelUapi
    {
        static void Main(string[] args)
        {
            UApi uapi = new UApi("http://94.199.200.65:2082/execute");
            uapi.authenticate("alierde1", "Erdem1905+");

            UapiFactory factory = new UapiFactory();
            Ftp ftp = (Ftp)factory.CallApi("Ftp");
            ftp.setUapi(uapi);

            try
            {
                JToken listFtp = ftp.GetFtpAccounts();
                foreach (var item in listFtp)
                {
                    Console.WriteLine(item.SelectToken("type") + " : " + item.SelectToken("user") + " : " + item.SelectToken("homedir"));
                }
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
