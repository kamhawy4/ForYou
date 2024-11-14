using ForYou.Application.Contracts;
using ForYou.Domain.Contracts;
using ForYou.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Infrastructure.Repositories
{
    public class AuditLogRepository : BaseRepository<AuditLog>, IAuditLogRepository<AuditLog>, IAsyncRepository<AuditLog>
    {

        protected readonly PostDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public AuditLogRepository(PostDbContext dbContext, IHttpContextAccessor httpContextAccessor) : base(dbContext)
        {
            {
                _dbContext = dbContext;
                _httpContextAccessor = httpContextAccessor;

            }

        }

        private string GetDeviceDetails(HttpContext context)
        {
            // You can use third-party libraries to parse device details from User-Agent or implement your own parser
            return context?.Request?.Headers["User-Agent"].ToString();
        }


        public async Task LogAsync(string action, string userId, string details = null)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var auditLog = new AuditLog
            {
                UserId = userId,
                Action = action,
                Timestamp = DateTime.UtcNow,
                IPAddress = httpContext?.Connection?.RemoteIpAddress?.ToString(),
                BrowserInfo = httpContext?.Request?.Headers["User-Agent"].ToString(),
                DeviceDetails = GetDeviceDetails(httpContext),
                Details = details
            };

            _dbContext.AuditLog.Add(auditLog);
            await _dbContext.SaveChangesAsync();
        }

    }
}
