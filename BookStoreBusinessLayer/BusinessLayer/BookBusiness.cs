using BookStoreBusinessLayer.IBusinessLayer;
using BookStoreModel.BookModels;
using BookStoreRepository.IRepository;
using System.Collections.Generic;

namespace BookStoreBusinessLayer.BusinessLayer
{
    public class BookBusiness : IBookBusiness
    {
        private readonly IBookRepository repository;
        public BookBusiness(IBookRepository repository)
        {
            this.repository = repository;
        }
        public BookModel AddBook(BookModel model)
        {
            var result = repository.AddBook(model);
            return result;
        }

        public IEnumerable<BookModel> GetBook()
        {
            var result = repository.GetBook();
            return result;
        }
    }
}
