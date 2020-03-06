using TheVyshka.Auth.Interfaces;
using TheVyshka.Data;
using TheVyshka.Data.Converters;
using TheVyshka.Data.Dto;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TheVyshka.Auth.Services
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IJwtGenerator _jwt;

        public AuthService(SignInManager<User> sim, UserManager<User> um, IJwtGenerator jwt)
        {
            _signInManager = sim;
            _userManager = um;
            _jwt = jwt;
        }

        public async Task<object> Login(string email, string password)
        {
            if (email == null || password == null)
                return null;

            var result = await _signInManager.PasswordSignInAsync(email, password, false, false);

            if (result.Succeeded)
            {
                var appUser = await _userManager.FindByEmailAsync(email);
                return await _jwt.GenerateJwt(appUser);
            }
            return null;
        }

        
        public async Task<object> Register(UserDto item)
        {
            User user = UserConverter.Convert(item);
            var result = await _userManager.CreateAsync(user, item.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                await _userManager.AddToRoleAsync(user, "user");
                return await _jwt.GenerateJwt(user);
            }

            return null;
        }
    }



}
