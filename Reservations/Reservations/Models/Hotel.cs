using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reservations.Models
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Street { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string City { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Country { get; set; }

        // FK
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        // FK - nav
        public Category Category { get; set; }

        // Rooms - nav
        public ICollection<Room> Rooms { get; set; }
    }
}
