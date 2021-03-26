using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreModel.BookModels
{
    public class BookModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

        public string BookName { get; set; }

        public string BookDescription { get; set; }

        public string BookAuthor { get; set; }
    
        public string BookImage { get; set; }

        public int BookQuntity { get; set; }

        public int BookPrize { get; set; }
    }
}
