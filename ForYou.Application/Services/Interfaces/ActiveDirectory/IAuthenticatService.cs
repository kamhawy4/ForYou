using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Application.Services.Interfaces.ActiveDirectory
{
    public interface IAuthenticatService
    {
       Task<bool> IsAuthenticated(string username,string password);
    }
}
