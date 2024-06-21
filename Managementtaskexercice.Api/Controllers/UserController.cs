using managementtaskexercice.Application.Contracts.Persistence;
using managementtaskexercice.Application.Contracts.Users.Authenticate;
using managementtaskexercice.Application.Contracts.Users.Login;
using managementtaskexercice.Application.Models;
using managementtaskexercice.Authentication;
using managementtaskexercice.Authentication.Extensions.Session;
using managementtaskexercice.Domain.Entities;
using managementtaskexercice.Persistence;
using managementtaskexercice.Persistence.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mysqlx.Session;
using System.Security.Claims;


namespace Managementtaskexercice.Api.Controllers
{

   // [Authorize(Policy = "UserOnly")]
    [Route("Api/[Controller]")]
    [ApiController]
    public class UserController:ControllerBase
    {
        private readonly IAsyncUserRepository _userRepository;
        private readonly IAuthenticate<Login> _authenticate;
        private readonly IGenerateToken _generateToken;
     
        public UserController(IAsyncUserRepository userRepository,IAuthenticate<Login> authenticate, IGenerateToken generateToken)
        {
            _userRepository = userRepository;
            _authenticate = authenticate;
            _generateToken = generateToken;
        }

        [HttpPost("/api/[controller]/sign up")]
        public async  Task<ActionResult<AppUser>> CreateUser( AppUser appUser)
        {
            await _userRepository.AddAsync(appUser);
            
           return CreatedAtAction(nameof(CreateUser), new { email = appUser.Email}); 
        }



        [HttpPost("/api/[controller]/sign in")]
        public async Task<ActionResult <string>> Login(Login Login)
        {
            var user = await _authenticate.SignInAsync(Login);
            if (user !=null)
            {
                HttpContext.Session.Set<User>("login",user);

                return _generateToken.CreateToken(User.Claims);
            }
            return Unauthorized();

        }


    }
}