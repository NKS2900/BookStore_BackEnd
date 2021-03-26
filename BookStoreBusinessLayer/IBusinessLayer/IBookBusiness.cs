using BookStoreModel.BookModels;
using System.Collections.Generic;

namespace BookStoreBusinessLayer.IBusinessLayer
{
    public interface IBookBusiness
    {
        BookModel AddBook(BookModel model);

        IEnumerable<BookModel> GetBook();
    }
}
