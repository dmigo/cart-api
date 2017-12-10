using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Api.Models;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class CartController : Controller
    {
        public CartController()
        {
            
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            var result = new Cart{
                Items = new []{
                    new CartItem{
                        Article = new ArticleShort{
                            Id=1
                        },
                        Quantity = 10
                    },
                    new CartItem{
                        Article = new ArticleShort{
                            Id=32167
                        },
                        Quantity = 2
                    },
                    new CartItem{
                        Article = new ArticleShort{
                            Id=1337
                        },
                        Quantity = 17
                    },
                }
            };

            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody]Cart cart)
        {
            return NotFound();
        }
    }
}
