using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Globalization;
using Yatra.Data;
using Yatra.Models;
using Yatra.Models.Domain;
namespace Yatra.Controllers
{
    public class FlightsController : Controller
    {
        private readonly YatraDbContext yatraDbContext;
        private readonly IHttpClientFactory _httpClientFactory;

        public FlightsController(YatraDbContext yatraDbContext , IHttpClientFactory httpClientFactory)
        {
            this.yatraDbContext = yatraDbContext;
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Flights()
        {
            return View();
        }
       [HttpGet]
        public async Task<IActionResult> Flights(SearchFlightViewModel model)
        {


            
            if (model != null && model.TravellerCount > 0 && !string.IsNullOrWhiteSpace(model.DepartFrom))
            {
                TempData["TravellerCount"] = model.TravellerCount;
               
                var filteredFlights = await GetFilteredFlightsFromApi(model);
                var viewModel = new FlightsViewModel
                {
                    Flights = filteredFlights,
                    SearchFlightViewModel = model
                };
                return View(viewModel);
            }
            TempData["TravellerCount"] = 1;
            var allflights = await yatraDbContext.Flights.ToListAsync();
            return View(new FlightsViewModel { Flights = allflights });
        }
        private async Task<List<Flights>> GetFilteredFlightsFromApi(SearchFlightViewModel model)
        {

           // DateTime dateTimeDepartDate = DateTime.ParseExact(model.DepartDate.ToString("dd-MM-yyyy"), "dd-MM-yyyy", CultureInfo.InvariantCulture);

            //string formattedDepartDate = dateTimeDepartDate.ToString("yyyy-MM-dd");
            //dateTimeDepartDate = DateTime.ParseExact(formattedDepartDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            var apiBaseUrl = "https://localhost:7287"; 
            //var apiBaseUrl = "http://afreenqayoom-001-site1.atempurl.com";
            var apiEndpoint = $"/api/MyFlightsApi/GetFilteredFlights?departFrom={model.DepartFrom}&departTo={model.DepartTo}&departDate={model.DepartDate}";

            using var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(apiBaseUrl);

            var response = await client.GetAsync(apiEndpoint);

            if (!response.IsSuccessStatusCode)
            {
                
                return new List<Flights>();
            }

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Flights>>(content);
        }
    }
}
