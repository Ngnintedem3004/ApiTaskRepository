using managementtaskexercice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace managementtaskexercice.Application.Contracts.Users.Authenticate
{
    public interface   IAsyncAddUserIdClaim<TUser> where TUser : User
    {
        public Task AddUserIdClaimAsync(TUser user,Claim claim);
    }
}
