using AspNetCore.ServiceRegistration.Dynamic;
using ForYou.Application.Contracts;
using ForYou.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Domain.Contracts
{
    public interface IAuditLogRepository<AuditLog>
    {
        Task  LogAsync(string action, string userId, string details = null);

    }
}
