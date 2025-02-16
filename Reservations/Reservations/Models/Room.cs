using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Reservations.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "int")]
        public int RoomNumber { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Size { get; set; }

        [Column(TypeName = "bit")]
        public bool IsRented { get; set; }

        // FK
        [ForeignKey("Hotel")]
        public int HotelId { get; set; }
        // FK - nav
        public Hotel Hotel { get; set; }
    }
}
