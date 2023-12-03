using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Net.Http;
using Yatra.Data;
using Yatra.Models;
using Yatra.Models.Domain;

namespace Yatra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyFlightsApiController : ControllerBase
    {
        private readonly YatraDbContext yatraDbContext; 

        public MyFlightsApiController(YatraDbContext yatraDbContext)
        {
            this.yatraDbContext= yatraDbContext;    
        }
        [HttpGet("GetFilteredFlights")]

        // public IActionResult GetFilteredFlights(string departFrom, string departTo, DateTime departDate)
        public IActionResult GetFilteredFlights([FromQuery] string departFrom, [FromQuery] string departTo, [FromQuery] DateTime departDate)
        {
            try
            {
                DateTime dateTimeDepartDate = DateTime.ParseExact(departDate.ToString("dd-MM-yyyy"), "dd-MM-yyyy", CultureInfo.InvariantCulture);
                // DateTime dateTimeDepartDate = DateTime.Parse(departDate.ToString());
                //string formattedDepartDate = dateTimeDepartDate.ToString("yyyy-MM-dd");
                //dateTimeDepartDate = DateTime.ParseExact(formattedDepartDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                var filteredFlights = FilterFlights(departFrom,departTo,dateTimeDepartDate);

                return Ok(filteredFlights);
            }
            catch (Exception ex)
            {
               
                return StatusCode(500, "Internal Server Error");
            }
        }

        private List<Flights> FilterFlights(string departFrom,string departTo,DateTime departDate)
        {
           
            var filteredFlights = yatraDbContext.Flights
                .Where(f =>
                    f.FlightFrom == departFrom &&
                    f.FlightTo == departTo &&
                   f.FlightDate.Date== departDate.Date
                    )
                .ToList();

            return filteredFlights;
        }
    }
}
