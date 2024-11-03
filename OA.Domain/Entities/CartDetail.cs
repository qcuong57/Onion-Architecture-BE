using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace OA.Domain.Entities
{
    [Table("cart_details")]
    public class CartDetail
    {
        [Key]
        [Column("cart_detail_id")]
        public int CartDetailId { get; set; }

        [Column("cart_id")]
        [ForeignKey("id")]
        public required virtual int CartId { get; set; }

        [Column("book_id")]
        [ForeignKey("id")]
        public required virtual int BookId { get; set; }

        [Required]
        [Column("quantity")]
        public int Quantity { get; set; }

        [Required]
        [Column("price")]
        public double Price { get; set; }
    }
}
