using BookStoreModel.UserModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BookStoreRepository.Repository
{
    public class UserRepository : IUserRepository
    {
        public IConfiguration Configuration { get; }

        private readonly BookStoreContext bookStoreContext;

        public UserRepository(BookStoreContext bookStoreContext, IConfiguration Configuration)
        {
            this.bookStoreContext = bookStoreContext;
            this.Configuration = Configuration;
        }
        public UserModel Register(UserModel model)
        {
            try
            {
                bookStoreContext.UserTable.Add(model);
                var result = bookStoreContext.SaveChanges();
                if (result > 0)
                {
                    return model;
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception("Error while Registration " + e.Message);
            }
        }

        public UserModel LoginUser(LoginModel model)
        {
            try
            {
                var result = bookStoreContext.UserTable.Where<UserModel>(x => x.Email == model.Email && x.Password == model.Password).FirstOrDefault();
                if (result != null)
                {
                    return result;
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception("Error while login " + e.Message);
            }
        }

        public string GenerateTokens(string userEmail)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: new Claim[]
                {
                    new Claim(ClaimTypes.Name, userEmail)
                },
                notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                expires: new DateTimeOffset(DateTime.Now.AddMinutes(60)).DateTime,
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
