using BookStoreModel.BookModels;
using BookStoreRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BookStoreRepository.Repository
{
    public class CartRepository  : ICartRepository
    {
        private readonly BookStoreContext bookStoreContext;

        public CartRepository(BookStoreContext bookStoreContext)
        {
            this.bookStoreContext = bookStoreContext;
        }

        public CartModel AddToCart(CartModel model)
        {
            try
            {
                bookStoreContext.CartTable.Add(model);
                var save = bookStoreContext.SaveChanges();
                if (save > 0)
                {
                    return model;
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception("Error while AddToCart " + e.Message);
            }
        }

        public IEnumerable<CartResponse> GetCart(int userId)
        {
            try
            {
                List<CartResponse> getResult = new List<CartResponse>();
                var result = from BookModel in bookStoreContext.BookTable
                             join CartModel in bookStoreContext.CartTable
                             on BookModel.BookId equals CartModel.BookId

                             select new CartResponse()
                             {
                                 BookId = BookModel.BookId,
                                 BookName = BookModel.BookName,
                                 AuthorName = BookModel.BookAuthor,
                                 BookPrice = BookModel.BookPrize,
                                 BookCount = CartModel.BookCount,
                                 BookImage = BookModel.BookImage,
                                 BookDescription = BookModel.BookDescription,
                                 CartId = CartModel.CartId,
                                 UserId = CartModel.UserId,
                             };

                foreach (var data in result)
                {
                    if (data.UserId == userId)
                    {
                        getResult.Add(data);
                    }
                }
                return getResult;
            }
            catch (Exception e)
            {
                throw new Exception("Error while Get_Cart_Item " + e.Message);
            }
        }

        public bool DeletCartItem(int cartId)
        {
            try
            {
                var deletCartItem = bookStoreContext.CartTable.Find(cartId);
                if (deletCartItem != null)
                {
                    bookStoreContext.CartTable.Remove(deletCartItem);
                    bookStoreContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw new Exception("Error while Deleting Cart Item " + e.Message);
            }
        }

        public CartModel UpdateBookCount(CartModel model)
        {
            try
            {
                var update = bookStoreContext.CartTable.Where(x => x.CartId == model.CartId).FirstOrDefault();
                update.BookCount = model.BookCount;
                bookStoreContext.Update(update);
                var result = bookStoreContext.SaveChanges();
                if (result > 0)
                {
                    return update;
                }
                return null;

            }
            catch (Exception e)
            {
                throw new Exception("Error while Updating Book Quntity!!!");
            }
        }
    }
}
