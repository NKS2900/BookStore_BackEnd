using BookStoreModel.BookModels;
using BookStoreRepository.IRepository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStoreRepository.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext bookStoreContext;

        public BookRepository(BookStoreContext bookStoreContext)
        {
            this.bookStoreContext = bookStoreContext;
        }

        public BookModel AddBook(BookModel model)
        {
            try
            {
                bookStoreContext.BookTable.Add(model);
                var save = bookStoreContext.SaveChanges();
                if (save > 0)
                {
                    return model;
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception("Error while Registration " + e.Message);
            }
        }

        public IEnumerable<BookModel> GetBook()
        {
            try
            {
                IEnumerable<BookModel> getBooks=bookStoreContext.BookTable.Where(e => e.BookId > 0).ToList();
                if (getBooks != null)
                {
                    return getBooks;
                }
                return null;
            }
            catch(Exception e)
            {
                throw new Exception("Error while Registration " + e.Message);
            }
        }
    }
}
