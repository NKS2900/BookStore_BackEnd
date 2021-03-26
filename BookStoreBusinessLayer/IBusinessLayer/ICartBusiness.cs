using BookStoreModel.BookModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreBusinessLayer.IBusinessLayer
{
    public interface ICartBusiness
    {
        CartModel AddToCart(CartModel model);

        IEnumerable<CartResponse> GetCart(int userId);

        bool DeletCartItem(int cartId);

        CartModel UpdateBookCount(CartModel model);
    }
}
