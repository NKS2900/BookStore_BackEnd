using BookStoreModel.UserModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreModel.BookModels
{
    public class CartModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartId { get; set; }

        //[ForeignKey("BookModel")]
        public int BookId { get; set; }

        //[ForeignKey("UserModel")]
        public int UserId { get; set; }

        public int BookCount { get; set; }

        //[ForeignKey("BookId")]
        //public virtual BookModel BookModel { get; set; }

        //[ForeignKey("UserId")]
        //public virtual UserModel UserModel { get; set; }
    }
}
