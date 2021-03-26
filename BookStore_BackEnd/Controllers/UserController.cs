using BookStoreBusinessLayer.IBusinessLayer;
using BookStoreModel.UserModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookStore_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAllHeaders")]
    public class UserController : Controller
    {
        private readonly IUserBusiness business;

        public UserController(IUserBusiness business)
        {
            this.business = business;
        }

        [HttpPost]
        [Route("register")]
        public IActionResult RegisterUser([FromBody] UserModel model)
        {
            try
            {
                var result = this.business.AddUser(model);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "User Registration Successfull", Data = result });
                }
                return this.NotFound(new { Status = false, Message = "Error While Adding User Data" });
            }
            catch (Exception e)
            { 
                return this.BadRequest(new { Status = false, Message = e.Message });
            }
        }

        [HttpPost]
        [Route("login")]
        public IActionResult LoginUsers([FromBody] LoginModel model)
        {
            try 
            {
                var result = business.LoginUser(model);
                
                if (result != null)
                {
                    var token = business.GenerateTokens(model.Email);
                    return this.Ok(new { Status = true, Message = "Login Successfull.", Data = result, Token = token }); 
                }
                return this.NotFound(new { Status = false, Message = "Error While Login!!!" });
            }
            catch (Exception e)
            {  
                return this.BadRequest(new { Status = false, Message = e.Message });
            }
        }
    }
}
