using BookStoreModel.BookModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRepository.IRepository
{
    public interface IBookRepository
    {
        BookModel AddBook(BookModel model);

        IEnumerable<BookModel> GetBook();
    }
}
