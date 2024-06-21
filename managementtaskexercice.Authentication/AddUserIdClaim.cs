using managementtaskexercice.Application.Contracts.Users.Authenticate;
using managementtaskexercice.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace managementtaskexercice.Authentication
{
    public class AddUserIdClaim : IAsyncAddUserIdClaim<User>
    {
        private UserManager<User> _userManager;
      
        public AddUserIdClaim(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task AddUserIdClaimAsync(User user,Claim claim)
        {
             await _userManager.AddClaimAsync(user, claim);
           
        }

      
    }
}
