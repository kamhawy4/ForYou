using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.SharedServices.Interfaces
{
    public interface IEmailService
    {
        Task<string> SendEmailAsync(string recipientEmail, string subject);
    }
}
