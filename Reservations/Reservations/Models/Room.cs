using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reservations.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Hotel")]
        public int HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }

        [Column(TypeName = "int")]
        public int RoomNumber { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Size { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal PricePerNight { get; set; }

        [Column(TypeName = "bit")]
        public bool Available { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
