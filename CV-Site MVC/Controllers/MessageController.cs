using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CV_Site_MVC.Models;
using System.Net.Http;
using System.Text.Json;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.ViewFeatures;


namespace CV_Site_MVC.Controllers
{
    public class MessageController : Controller
    {
        private HttpClient _httpClient;
        private SiteContext _dbContext;

        public MessageController(HttpClient httpClient, SiteContext dbContext)
        {
            this._httpClient = httpClient;
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Message()
        {
            var id = currentUserId();
            var antal = _dbContext.Messages.Where(x => x.SentTo == id).Count(l => l.Read == false);
            ViewData["AntalMeddelande"] = antal;

            HttpResponseMessage response = await _httpClient.GetAsync("message");
            string data = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            List<Message> listofMessage = JsonSerializer.Deserialize<List<Message>>(data, options);

            List<Message> messages = listofMessage.Where(x => x.SentTo == id).ToList();
            messages.Reverse();
            ViewBag.Meddelande = "Meddelanden";
            return View(messages);
        }



        public IActionResult NewMessage(string id)
        {
            Message message = new Message();

            if (User.Identity.IsAuthenticated)
            {
                message.SentFrom = _dbContext.Users.Where(x => x.Id.Equals(currentUserId())).Select(y => y.UserName).First();
            }
            else
            {
                message.SentFrom = "Namn";
            }

            message.SentTo = id;

            return View(message);
        }

        public async Task<IActionResult> SendMessage (Message message)
        {
            message.Read = false;
            DateTime now = DateTime.Now;
            message.Date = now;

            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            string data = JsonSerializer.Serialize(message, option);
            var contentData = new StringContent(data, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await
                _httpClient.PostAsync($"message", contentData);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> messageRead(int id)
        {

            HttpResponseMessage response = await _httpClient.GetAsync($"Message/{id}");

            string data = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            Message message = JsonSerializer.Deserialize<Message>(data, options);

            if (message.Read == true)
            {
                message.Read = false;

            }
            else
            {
                message.Read = true;
              
            }

            string putData = JsonSerializer.Serialize(message);
            var contentData = new StringContent(putData, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage putResponse = await
                _httpClient.PutAsync($"Message/{message.Id}", contentData);

            return RedirectToAction("Message", "Message");
        }


         private string currentUserId()
        {
            ClaimsPrincipal currentUser = this.User;
            return currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
        }


    }
}

