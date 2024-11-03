using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OA.Domain.Entities
{
    [Table("order_details")]
    public class OrderDetail {

        [Key]
        [Column("order_detail_id")]
        public int OrderDetailId { get; set; }

        [Column("order_id")]
        [ForeignKey("id")]
        public required virtual int OrderId { get; set; }

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
