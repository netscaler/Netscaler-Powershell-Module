using com.citrix.netscaler.nitro.resource.config.lb;
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
    [Cmdlet("Get", "NSVirtualServer")]
    public class NSVirtualServerCommandGet : Cmdlet
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
            List<NSVirtualServer> list = new List<NSVirtualServer>();
            foreach (lbvserver _lbvserver in lbvserver.get(service))
            {
                NSVirtualServer nsVirtualServer = new NSVirtualServer()
                {
                    Name = _lbvserver.name,
                    IP = _lbvserver.ipv46,
                    IPMask = _lbvserver.ipmask,
                    IPPattern = _lbvserver.ippattern,
                    ServiceType = _lbvserver.servicetype,
                    Type = _lbvserver.type
                };
                list.Add(nsVirtualServer);
            }
            this.WriteObject((object)list);
        }
    }
}
