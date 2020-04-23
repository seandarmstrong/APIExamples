using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using APIExamples.Models;
using System.Net.Http;
using APIExamples.API_Models;

namespace APIExamples.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index(string firstName)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.icndb.com");
            var response = await client.GetAsync("jokes/random");
            var joke = await response.Content.ReadAsAsync<Joke>();
            return View(joke);
        }

        public async Task<IActionResult> Jokes()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.icndb.com");
            var response = await client.GetAsync("jokes/random/10");
            var jokes = await response.Content.ReadAsAsync<JokeList>();
            return View(jokes);
        }

        [HttpPost]
        public async Task<IActionResult> Forecast(string lat, string lon)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://forecast.weather.gov");
            client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; GrandCircus/1.0)");
            var modifiedEndPoint = "MapClick.php?lat=" + lat + "&lon=" + lon + "&FcstType=json";
            var response = await client.GetAsync(modifiedEndPoint);
            var forecast = await response.Content.ReadAsAsync<Weather>();
            return View(forecast);
        }

        public async Task<IActionResult> Privacy()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.openbrewerydb.org");
            var response = await client.GetAsync("breweries");
            var breweries = await response.Content.ReadAsAsync<List<Brewery>>();

            return View(breweries);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
