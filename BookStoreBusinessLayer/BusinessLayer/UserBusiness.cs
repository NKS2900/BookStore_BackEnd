using BookStoreBusinessLayer.IBusinessLayer;
using BookStoreModel.UserModels;
using BookStoreRepository.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBusinessLayer.BusinessLayer
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserRepository repository;

        public UserBusiness(IUserRepository repository)
        {
            this.repository = repository;
        }

        public UserModel AddUser(UserModel model)
        {
            var result = repository.Register(model);
            return result;
        }

        public UserModel LoginUser(LoginModel model)
        {
            var result = repository.LoginUser(model);
            return result;
        }

        public string GenerateTokens(string userEmail)
        {
            var token = repository.GenerateTokens(userEmail);
            return token;
        }


    }
}
