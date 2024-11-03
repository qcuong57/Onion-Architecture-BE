using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OA.Domain.Entities
{
    [Table("book_catalogues")]
    public class BookCatalogue
    {
        [Key]
        [Column("book_catalogue_id")]
        public int BookCatalogueId { get; set; }

        [Column("book_id")]
        [ForeignKey("id")]
        public required virtual int bookId { get; set; }

        [Column("catalogue_id")]
        [ForeignKey("id")]
        public required virtual int catalogueId { get; set; }
    }
}
