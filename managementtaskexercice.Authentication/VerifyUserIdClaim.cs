using managementtaskexercice.Application.Contracts.Users.Authenticate;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace managementtaskexercice.Authentication
{
    public class VerifyUserIdClaim : IVerifyUserIdClaim
    {

        private IHttpContextAccessor _httpContextAccessor;
        public VerifyUserIdClaim(IHttpContextAccessor httpContextAcessor)
        {
            _httpContextAccessor = httpContextAcessor;
        }

        public Claim HasUserIdClaim() => _httpContextAccessor.HttpContext.User.Claims.First(t => t.Type == "UserId");
    }
}
