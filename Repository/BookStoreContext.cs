using BookStoreModel.BookModels;
using BookStoreModel.UserModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreRepository
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        { 

        }

        public DbSet<UserModel> UserTable { get; set; }
        
        public DbSet<BookModel> BookTable { get; set; }

        public DbSet<CartModel> CartTable { get; set; }

    }
}
