using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace cart_api.Controllers
{
    [Route("api/[controller]")]
    public class CartController : Controller
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
    }
}
