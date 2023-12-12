using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Application.Features.Authentication.Login
{
    public class LoginResponse
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string MobileNumebr { get; set; }
        public string Token { get; set; }
    }
}
