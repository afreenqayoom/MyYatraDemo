namespace Yatra.Models
{
    public class SearchFlightViewModel
    {
       
        public string DepartFrom { get; set; }
        public string DepartTo { get; set; }
        public DateOnly DepartDate { get; set; }
        public int TravellerCount { get; set; } = 1;
    }
}
