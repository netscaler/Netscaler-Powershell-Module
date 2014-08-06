using com.citrix.netscaler.nitro.resource.config.ns;
using com.citrix.netscaler.nitro.service;
using NetscalerPSCmdlets.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace NetscalerPSCmdlets
{
    [Cmdlet("Get", "NSIP")]
    public class NSServerIPsCommandGet : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public PSCredential Credential { get; set; }

        [Parameter(Mandatory = true)]
        public string IPAddress { get; set; }

        public SwitchParameter UseSSL { get; set; }

        protected override void ProcessRecord()
        {
            nitro_service service = new nitro_service(this.IPAddress, !(bool)this.UseSSL ? "HTTP" : "HTTPS");
            if (!(service.login(this.Credential.UserName, this.Credential.GetNetworkCredential().Password).sessionid != ""))
                return;
            List<NSIP> list = new List<NSIP>();
            foreach (nsip nsip1 in nsip.get(service))
            {
                NSIP nsip2 = new NSIP()
                {
                    IP = nsip1.ipaddress,
                    State = nsip1.state,
                    Type = nsip1.type
                };
                list.Add(nsip2);
            }
            this.WriteObject((object)list);
        }
    }
}
