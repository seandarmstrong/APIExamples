using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using APIExamples.API_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;

namespace APIExamples.Controllers
{
    public class GuardianController : Controller
    {
        private IConfiguration _config;
        public GuardianController(IConfiguration config)
        {
            _config = config;
        }
        
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://content.guardianapis.com/");
            var endPoint = string.Format("search?q=snacks&api-key={0}&format=json", Secrets.ApiKey);
            var response = await client.GetStringAsync(endPoint);
            var result = JsonConvert.DeserializeObject<Guardian>(response);

            return View();
        }

        public IActionResult RestSharp()
        {
            var restClient = new RestClient("https://content.guardianapis.com");
            var firstWay = _config.GetSection("APIKey").Value;
            var firstWithMultipleSections = _config.GetSection("APIKeys").GetSection("Guardian").Value;
            var secondWay = _config.GetValue<string>("APIKey");
            var secondWithMultpleSections = _config.GetValue<string>("APIKeys:Guardian");
            var endPoint = string.Format("search?q=snacks&api-key={0}&format=json", firstWay);
            var request = new RestRequest(endPoint);
            request.AddHeader("Accept", "aaplication/json");
            var response = restClient.Get(request);
            var result = JsonConvert.DeserializeObject<Guardian>(response.Content);

            return View();
        }
    }
}