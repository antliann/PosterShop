using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PosterShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartsController : ControllerBase
    {
        private readonly PosterShopContext _context;

        public ChartsController(PosterShopContext context)
        {
            _context = context;
        }


        [HttpGet("JsonData")]
        public JsonResult JsonData()
        {
            var topics = _context.Topics.Include(g => g.Posters).ToList();
            List<object> jokerPoster = new List<object>();

            jokerPoster.Add(new[] { "Тема", "Количество" });

            foreach (var b in topics)
            {
                jokerPoster.Add(new object[] { b.Name, b.Posters.Count() });
            }
            return new JsonResult(jokerPoster);
        }

        [HttpGet("JsonPrices")]
        public JsonResult JsonPrices()
        {
            var topics = _context.Topics.Include(g => g.Posters).ToList();
            List<object> odin = new List<object>();

            odin.Add(new[] { "Тема", "Средняя цена, грн" });

            foreach (var b in topics)
            {
                int pricer = 0;
                int i = 0;
                foreach (var c in b.Posters) {
                    pricer += c.Price;
                    i++;
                }
                try {
                    odin.Add(new object[] { b.Name, pricer/i });
                } catch {
                    odin.Add(new object[] { b.Name, 0 });
                }
            }
            return new JsonResult(odin);
        }
    }
}