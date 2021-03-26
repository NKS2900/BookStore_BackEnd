using BookStoreModel.UserModels;
using System;

namespace BookStoreRepository.Repository
{
    public interface IUserRepository
    {
        UserModel Register(UserModel model);

        UserModel LoginUser(LoginModel model);

        string GenerateTokens(string userEmail);
    }
}
