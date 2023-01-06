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

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
            var antal = _dbContext.Messages.Where(x => x.Message_Reciever.Id == id).Count(l => l.Read == false);
            ViewData["Antal meddelande"] = antal;

            HttpResponseMessage response = await _httpClient.GetAsync("message");
            string data = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            List<Message> listofMessage = JsonSerializer.Deserialize<List<Message>>(data, options).Where(x => x.SentTo == id).ToList();

            List<MessageViewModel> list = new List<MessageViewModel>();
            foreach(var message in listofMessage)
            {
                string sender = message.SentFrom;
                string userNameSender = _dbContext.Users.Where(x => x.Id == sender).Select(x => x.UserName).FirstOrDefault();
                string reciever = message.SentTo;
                string userNameReciever = _dbContext.Users.Where(x => x.Id == reciever).Select(x => x.UserName).FirstOrDefault();
                string text = message.Text;
                bool read = message.Read;
                int messageID = message.Id;


                MessageViewModel model = new MessageViewModel();
                model.Sender = userNameSender;
                model.Reciever = userNameReciever;
                model.Text = text;
                model.Read = read;
                model.ID = messageID;

                list.Add(model);
                list.Reverse();
                   

                

            }
            ViewBag.Meddelande = "Meddelanden";
            return View(list);

        }

        private string currentUserId()
        {
            ClaimsPrincipal currentUser = this.User;
            return currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
        }


    }
}

