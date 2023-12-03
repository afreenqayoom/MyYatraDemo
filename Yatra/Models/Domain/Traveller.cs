using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yatra.Models.Domain
{
    public class Traveller
    {
        [Key]
        public Guid TravellerID { get; set; }

        public string Email { get; set; }
        public string Mobileno { get; set; }
        public string Name { get; set; }
        public string Lname { get; set; }
        public string FlightID {  get; set; }
        [ForeignKey("FlightID")]
        public virtual Flights Flight { get; set; }
    }
}
