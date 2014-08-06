using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace NetscalerPSCmdlets
{
    [RunInstaller(true)]
    public class NSPSSnapin : PSSnapIn
    {
        public override string Description
        {
            get
            {
                return "Citrix NetScaler PowerShell cmdlets based on the nitro API";
            }
        }

        public override string Name
        {
            get
            {
                return "Netscaler-CMDLets";
            }
        }

        public override string Vendor
        {
            get
            {
                return "John McBride";
            }
        }
    }
}
