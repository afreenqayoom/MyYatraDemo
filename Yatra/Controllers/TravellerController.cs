using Microsoft.AspNetCore.Mvc;
using Yatra.Data;
using Yatra.Models;
using Yatra.Models.Domain;

namespace Yatra.Controllers
{
    public class TravellerController : Controller
    {
        private readonly YatraDbContext yatraDbContext;

        public TravellerController(YatraDbContext yatraDbContext)
        {
            this.yatraDbContext = yatraDbContext;
        }
        public IActionResult Details()
        {
          
            return View();
        }
        [HttpPost]
        public IActionResult Details(string flightId)
        {
            TempData["FlightId"] = flightId;

            return View();
        }
        public IActionResult Confirmation()
        {
            return View();
        }
       [HttpPost]  
        public async Task<IActionResult> ConfirmBooking(Traveller tmodel,BookingViewModel bmodel)
        {
            string flightId = TempData.TryGetValue("FlightId", out var tempFlightId) && tempFlightId is string id ? id : null;
            if (flightId != null) {
              
                for (int i = 0; i < bmodel.Name.Length; i++)
                { 
                    tmodel.TravellerID = Guid.NewGuid();
                    tmodel.FlightID = flightId;
                    tmodel.Email = bmodel.Email;
                    tmodel.Mobileno = bmodel.Mobileno;
                    tmodel.Name = bmodel.Name[i];
                    tmodel.Lname = bmodel.Lname[i]; 
                    await yatraDbContext.Travellers.AddAsync(tmodel);   
                    await yatraDbContext.SaveChangesAsync();    
                }
                    TempData.Remove("FlightId");
            }
            return Redirect("Confirmation");

        }
    }
}
