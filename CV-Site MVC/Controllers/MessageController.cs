using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CV_Site_MVC.Models;
using System.Net.Http;
using System.Text.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CV_Site_MVC.Controllers
{
    public class MessageController : Controller
    {
        private HttpClient _httpClient;

        public MessageController(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("message");
            string data = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            List<Message> listofMessage = JsonSerializer.Deserialize<List<Message>>(data, options)
                .OrderBy(mess => mess.Message_Sender).ToList();

            ViewBag.Meddelande = "Meddelanden";
            return View(listofMessage);

        }



    }
}

