using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CV_SiteAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CV_SiteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private SiteContext _siteContext;
        public MessageController(SiteContext siteContext)
        {
            _siteContext = siteContext;
        }

        [HttpGet]
        public List<Message> Get()
        {
            return _siteContext.Messages.ToList();
        }

        [HttpGet("{ID}")]
        public Message Get(int ID)
        {
            return _siteContext.Messages.Find(ID);

        }

        [HttpPost]
        public void Post(Message message)
        {
            if (ModelState.IsValid)
            {
                _siteContext.Messages.Add(message);
                _siteContext.SaveChanges();
            }
        }

        [HttpPut("{id}")]
        public void Put([FromBody] Message message)
        {
            if (ModelState.IsValid)
            {
                _siteContext.Messages.Update(message);
                _siteContext.SaveChanges();
            }
        }
    }
}

