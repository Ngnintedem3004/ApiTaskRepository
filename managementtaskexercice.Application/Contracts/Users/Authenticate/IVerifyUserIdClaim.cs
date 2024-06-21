using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace managementtaskexercice.Application.Contracts.Users.Authenticate
{
    public  interface  IVerifyUserIdClaim
    {
        Claim HasUserIdClaim();
    }
}
