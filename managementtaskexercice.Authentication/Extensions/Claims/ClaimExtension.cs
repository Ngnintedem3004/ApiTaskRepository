using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace managementtaskexercice.Authentication.Extensions.Claims
{
    public static  class ClaimExtension
    {
        public static Claim  HasIdClaim(this IEnumerable<Claim> Claims )
        {
            return Claims.First(t=>t.Type=="UserId");
        }
    }
}
