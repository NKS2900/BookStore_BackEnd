using BookStoreModel.UserModels;
using System;

namespace BookStoreBusinessLayer.IBusinessLayer
{
    public interface IUserBusiness
    {
       UserModel AddUser(UserModel model);

        UserModel LoginUser(LoginModel model);

        string GenerateTokens(string userEmail);
    }
}
