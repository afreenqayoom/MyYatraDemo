using System.ComponentModel.DataAnnotations;

namespace Yatra.Models.Domain
{
    public class Flights
    {
        [Key]
        public string FlightID { get; set; }
        public string FlightName { get; set; }

        public string FlightCode { get; set; }
        public DateTime FlightDate { get; set; }
        public string FlightFrom { get; set; }
        public string FlightTo { get; set;}
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string Duration { get; set;}
        public int Stops { get; set; }
        public int Price { get; set; }
        public bool Meals { get; set; }
        public int Emmisions { get; set; }

    }
}
