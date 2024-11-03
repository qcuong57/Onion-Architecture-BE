using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace  OA.Domain.Entities
{
    [Table("book_types")]
    public class BookType
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [Column("description")]
        public string Description { get; set; }

        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
