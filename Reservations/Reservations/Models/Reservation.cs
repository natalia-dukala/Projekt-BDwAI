using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Reservations.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }

        [Column(TypeName = "date")]
        public DateTime CheckInDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime CheckOutDate { get; set; }

        [ForeignKey("DefaultUser")]
        public string UserId { get; set; }
        public virtual DefaultUser User { get; set; }
    }
}
