using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repository.Model;
using Share.Helper;
using Share.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class AuthenticateService
    {
        private readonly UserManager<User> userManager;
        private readonly AppSettings _appSettings;

        public AuthenticateService(UserManager<User> userManager, AppSettings _appSettings)
        {
            this.userManager = userManager;
            this._appSettings = _appSettings;
        }
        public async Task<User> RegisterUserAuth (RegisterUser registerUser)
        {
            var user = new User
            {
                Email = registerUser.Email,
                UserName = registerUser.Name,
                Name = registerUser.Name,
                Surname = registerUser.Surname,
            };

            var result = await userManager.CreateAsync(user, registerUser.Password);
            if (!result.Succeeded)
            {
                throw new ArgumentException();
            }
            return user;
                
        }

        public async Task<string> LoginUser(LoginUser loginUser)
        {
            var user = await userManager.FindByNameAsync(loginUser.Email);
            if (user != null && await userManager.CheckPasswordAsync(user, loginUser.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Secret));

                var token = new JwtSecurityToken(
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );


                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                return tokenString;
            }
            return null;
            
        }
    }
}
