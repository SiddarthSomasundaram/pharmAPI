using JWTAPI.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTAPI.Provider
{
    public interface IAuthProvider
    {
        public string GenerateJSONWebToken(CustomerDetail userInfo, IConfiguration _config);
        public dynamic AuthenticateUser(CustomerDetail login);
    }
}
