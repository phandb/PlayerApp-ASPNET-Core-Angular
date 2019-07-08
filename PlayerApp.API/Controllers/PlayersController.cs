using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlayerApp.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace PlayerApp.API.Controllers
{
    //http://localhost:5000/api/
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly DataContext _context;
        public PlayersController(DataContext context)
        {
            _context = context;
        }

        // GET api/players
        //By default, all methods are created synchronously that means only one
        //accessable at a time.  That is not really convenient.
        //We have to convert to asynschronous methods so that many users
        //can access a method at the same time.
         [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetPlayers()
        {
            var players = await _context.Players.ToListAsync();

            return Ok(players);
        }

        // GET api/players/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public  async Task<IActionResult> GetPlayer(int id)
        {
            var player = await _context.Players.FirstOrDefaultAsync(x => x.Id == id);

            return Ok(player);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
