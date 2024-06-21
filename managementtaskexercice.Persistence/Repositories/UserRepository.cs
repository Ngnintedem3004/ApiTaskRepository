using managementtaskexercice.Application.Contracts.Persistence;
using managementtaskexercice.Application.Contracts.Users.Authenticate;
using managementtaskexercice.Application.Models;
using managementtaskexercice.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace managementtaskexercice.Persistence.Repositories
{
    public class UserRepository : BaseRepository,IAsyncUserRepository
    {
      private UserManager<User> _userManager;
        private IAsyncAddUserIdClaim<User> _addUserIdClaim;
        public UserRepository(ManagementtaskDbContext context,UserManager<User> userManager,IAsyncAddUserIdClaim<User> addUserIdClaim) : base(context)
        {
            _userManager = userManager;
            _addUserIdClaim = addUserIdClaim;
        }

        public  async Task AddAsync(AppUser appUser)
        {
            var user = new User
            {
                Email = appUser.Email,
                PasswordHash = appUser.Password,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
                UserName = appUser.Email

            };
            Claim claim = new Claim("UserId", user.Id);
            await _userManager.CreateAsync(user, appUser.Password);
          await   _addUserIdClaim.AddUserIdClaimAsync(user, claim);
            await _context.SaveChangesAsync();
        }

        
    }
}
