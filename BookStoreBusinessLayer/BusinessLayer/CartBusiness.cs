using BookStoreBusinessLayer.IBusinessLayer;
using BookStoreModel.BookModels;
using BookStoreRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBusinessLayer.BusinessLayer
{
    public class CartBusiness : ICartBusiness
    {
        private readonly ICartRepository repository;

        public CartBusiness(ICartRepository repository)
        {
            this.repository = repository;
        }

        public CartModel AddToCart(CartModel model)
        {
            var result = repository.AddToCart(model);
            return result;
        }

        public IEnumerable<CartResponse> GetCart(int userId)
        {
            var result = repository.GetCart(userId);
            return result;
        }

        public bool DeletCartItem(int cartId)
        {
            bool result = repository.DeletCartItem(cartId);
            return result;
        }

        public CartModel UpdateBookCount(CartModel model)
        {
            var result = repository.UpdateBookCount(model);
            return result;
        }
    }
}
