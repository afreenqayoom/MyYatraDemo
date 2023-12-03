namespace Yatra.Models
{
    public class BookingViewModel
    {
        public string Email { get; set; }
        public string Mobileno { get; set; }
        public string[] Name { get; set; }=new string[0];   
        public string[] Lname { get; set; } = new string[0];    
    }
}
