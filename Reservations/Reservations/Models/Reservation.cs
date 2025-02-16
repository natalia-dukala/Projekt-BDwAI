using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Reservations.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }

        [Column(TypeName = "date")]
        public DateTime CheckInDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime CheckOutDate { get; set; }
        
        // FK - Room
        [ForeignKey("Room")]
        public int RoomId { get; set; }
        // FK - Room nav
        public virtual Room Room { get; set; }

        // FK - User
        [ForeignKey("User")]
        public string UserId { get; set; }
        // FK - User nav
        public User User { get; set; }
    }
}
