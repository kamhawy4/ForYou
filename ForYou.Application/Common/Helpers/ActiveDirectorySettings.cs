using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Application.Common.Helpers
{
    public class ActiveDirectorySettings
    {
        public string Domain { get; set; }
        public string Container { get; set; }
        public string LDAPUrl { get; set; }
        public string IsProduction { get; set; }
        public string Url { get; set; }
        public string SKey { get; set; }
        public string DomainAddress { get; set; }
        public string ADAddress { get; set; }
        public string ADUsername { get; set; }
        public string ADPassword { get; set; }
    }
}