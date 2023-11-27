using System.ComponentModel.DataAnnotations;

namespace Yatra.Models.Domain
{
    public class Traveller
    {
        [Key]
        public Guid FlightId { get; set; }
        public string Email { get; set; }
        public string Mobileno { get; set; }
        public string Name { get; set; }
        public string Lname { get; set; }
    }
}
