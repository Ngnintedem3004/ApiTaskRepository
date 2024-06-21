using managementtaskexercice.Application.Contracts.Users.Authenticate;
using managementtaskexercice.Application.Models;
using managementtaskexercice.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace managementtaskexercice.Authentication
{
    public  class Authenticate:IAuthenticate<Login>
    {
        private  SignInManager<User> _signInManager { get; set; }
        private UserManager<User> _userManager { get; set; }
        public Authenticate(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            
        }

        public async Task<User> SignInAsync(Login Login)
        {
            User  ?appUser = await _userManager.FindByEmailAsync(Login.Email);
            SignInResult result;
            if (appUser!=null)
            {
               result= await _signInManager.PasswordSignInAsync(appUser, Login.Password, false, false);
                if (result.Succeeded) {
                    return appUser;
                    
                }
                else
                {
                    return null!;
                }
            }
            return appUser!;
        }
    }
}
