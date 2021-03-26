using BookStoreModel.BookModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRepository.IRepository
{
    public interface ICartRepository
    {
        CartModel AddToCart(CartModel model);

        IEnumerable<CartResponse> GetCart(int userId);

        bool DeletCartItem(int cartId);

        CartModel UpdateBookCount(CartModel model);
    }
}
