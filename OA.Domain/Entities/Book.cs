using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OA.Domain.Entities
{
    [Table("books")]
    public class Book
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [Column("price")]
        public double Price { get; set; }

        [Required]
        [Column("author_id")]
        [ForeignKey("id")]
        public required virtual int AuthorId { get; set; }

        [Required]
        [Column("type_id")]
        [ForeignKey("id")]
        public required virtual int BookTypeId { get; set; }

        [Required]
        [Column("release_date")]
        public DateOnly ReleaseDate { get; set; }

        public virtual ICollection<BookCatalogue> BookCatalogues { get; set; } = new List<BookCatalogue>();

        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

        public virtual ICollection<CartDetail> CartDetails { get; set; } = new List<CartDetail>();
    }
}
