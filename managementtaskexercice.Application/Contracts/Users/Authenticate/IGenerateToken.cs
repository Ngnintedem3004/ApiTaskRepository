using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace managementtaskexercice.Application.Contracts.Users.Login
{
    public interface IGenerateToken
    {
        public string CreateToken(IEnumerable<Claim> claims);
    }
}
