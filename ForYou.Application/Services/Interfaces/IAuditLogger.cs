using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Application.Services.Interfaces
{
    public interface IAuditLogger
    {
        Task LogAsync(string action, string userId, string details = null);

    }
}
