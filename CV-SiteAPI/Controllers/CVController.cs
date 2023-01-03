using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CV_SiteAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CV_SiteAPI.Controllers
{
    [Route("api/cv")]
    [ApiController]
    public class SiteController : ControllerBase
    {
        private SiteContext _siteContext;
        public SiteController(SiteContext siteContext)
        {
            _siteContext = siteContext;
        }

        [HttpGet]
        public List<CV> Get()
        {
            return _siteContext.cVs.ToList();
        }

        [HttpGet("{ID}")]
        public CV Get(int ID)
        {
            return _siteContext.cVs.Find(ID);

        }

        //// GET: api/values
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}


        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}

