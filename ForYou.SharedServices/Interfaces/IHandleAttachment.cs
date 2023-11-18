using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ForYou.SharedServices.Interfaces
{
    public interface IHandleAttachment
    {
        Task<string> Upload(IFormFile attachment);
    }
}
