using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reservations.Models
{
    public class Hotel
    {
        [Key]
        public int Id {  get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Street { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string City { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Country { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public double Rating { get; set; }

        [Column(TypeName = "bit")]
        public bool RoomsAvailable { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
