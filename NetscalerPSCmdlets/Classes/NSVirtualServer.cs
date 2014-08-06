using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetscalerPSCmdlets.Classes
{
    public class NSVirtualServer
    {
        public string Name { get; set; }

        public string IP { get; set; }

        public string IPMask { get; set; }

        public string IPPattern { get; set; }

        public string ServiceType { get; set; }

        public string Type { get; set; }
    }
}
