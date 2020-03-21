using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpanelUapi
{
    public class UApi
    {
        public string CpanelHostname { get; set; }
        public string CpanelUsername { get; set; }
        public string CpanelPassword { get; set; }

        public UApi(string cpanelHostname)
        {
            CpanelHostname = cpanelHostname;
        }

        public void authenticate(string cpanelUsername, string cpanelPassword)
        {
            CpanelUsername = cpanelUsername;
            CpanelPassword = cpanelPassword;
        }
    }
}
