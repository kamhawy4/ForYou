using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Domain.Entities
{
    public class AuditLog
    {
        [Key]
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Action { get; set; }
        public DateTime Timestamp { get; set; }
        public string IPAddress { get; set; }
        public string BrowserInfo { get; set; }
        public string DeviceDetails { get; set; }
        public string Details { get; set; } // Additional details if needed
    }
}
