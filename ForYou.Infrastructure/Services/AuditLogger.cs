using ForYou.Application.Services.Interfaces;
using ForYou.Domain.Contracts;
using ForYou.Domain.Entities;
using ForYou.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Application.Services.Services
{
    public class AuditLogger : IAuditLogger
    {

        private readonly PostDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuditLogger(PostDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
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

            _context.AuditLog.Add(auditLog);
            await _context.SaveChangesAsync();
        }

        private string GetDeviceDetails(HttpContext context)
        {
            // You can use third-party libraries to parse device details from User-Agent or implement your own parser
            return context?.Request?.Headers["User-Agent"].ToString();
        }
    }
}
