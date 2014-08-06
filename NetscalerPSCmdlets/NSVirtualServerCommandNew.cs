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
    [Cmdlet("New", "NSVirtualServer")]
    public class NSVirtualServerCommandNew : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public PSCredential Credential { get; set; }

        [Parameter(Mandatory = true)]
        public string IPAddress { get; set; }

        [Parameter(Mandatory = true)]
        public string Name { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter UseSSL { get; set; }

        [Parameter(Mandatory = true)]
        public string VIPAddress { get; set; }

        protected override void ProcessRecord()
        {
            nitro_service nitroService = new nitro_service(this.IPAddress, !(bool)this.UseSSL ? "HTTP" : "HTTPS");
            if (!(nitroService.login(this.Credential.UserName, this.Credential.GetNetworkCredential().Password).sessionid != ""))
                return;
            if ((uint)lbvserver.add(nitroService, new lbvserver()
            {
                port = new ushort?((ushort)80),
                ipv46 = this.VIPAddress,
                name = this.Name,
                servicetype = "HTTP"
            }).errorcode <= 0U)
            {
                lbvserver _lbvserver = lbvserver.get(nitroService, this.Name);
                if (_lbvserver != null)
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
                    nitroService.save_config();
                    this.WriteObject((object)nsVirtualServer);
                }
            }
        }
    }
}
