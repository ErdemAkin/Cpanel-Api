using CpanelUapi.Handler;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace CpanelUapi.Api
{
    class Ftp : ApiAbstract
    {
        // List All Ftp Accounts
        public JToken GetFtpAccounts()
        {
            Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>();
            parameters["include_acct_types"] = "main|sub";

            return get("Ftp/list_ftp", parameters);
        }

        // Lists the FTP server's active sessions
        public JToken ListFtpSessions()
        {
            Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>();

            return get("Ftp/list_sessions", parameters);
        }

        // Update FTP Account Password
        public JToken UpdateFtpAccountPassword(string username, string password, string domain = null)
        {
            Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>();
            parameters["user"] = username;
            parameters["pass"] = password;

            if (domain != null)
            {
                parameters["domain"] = domain;
            }

            return get("Ftp/passwd", parameters);
        }

        // Update FTP Account Quota
        public JToken UpdateFtpAccountQuota(string username, int quota, string domain = null)
        {
            Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>();
            parameters["user"] = username;
            parameters["quota"] = quota;

            if (domain != null)
            {
                parameters["domain"] = domain;
            }

            return get("Ftp/set_quota", parameters);
        }

        // Add FTP Account
        public JToken AddFtpAccount(string username, string password, string homedir = null, int quota = 0, string domain = null)
        {
            Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>();
            parameters["user"] = username;
            parameters["pass"] = password;
            parameters["quota"] = quota;

            if (homedir != null)
            {
                parameters["homedir"] = domain;
            }
            if (domain != null)
            {
                parameters["domain"] = domain;
            }

            return get("Ftp/add_ftp", parameters);
        }

        // Update FTP Account Quota
        public JToken DeleteFtpAccount(string username, int destroy = 0, string domain = null)
        {
            Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>();
            parameters["user"] = username;
            parameters["destroy"] = destroy;

            if (domain != null)
            {
                parameters["domain"] = domain;
            }

            return get("Ftp/delete_ftp", parameters);
        }
    }
}
