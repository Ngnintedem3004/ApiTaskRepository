using managementtaskexercice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace managementtaskexercice.Application.Contracts.Users.Authenticate
{
    public interface IAuthenticate<TUser> where TUser : class
    {
        public Task<User> SignInAsync(TUser User);

    }
}
