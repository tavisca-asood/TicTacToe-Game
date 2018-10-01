using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicTacToe.Models;

namespace TicTacToe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        // GET: api/Game
        [HttpGet]
        [Log]
        public string Get()
        {
            return Game.GetStatus();
        }

        // GET: api/Game/5
        [HttpGet("{id}", Name = "Get")]
        [Log]
        public void Get(int id)
        {
        }

        // POST: api/Game
        //[HttpPost]
        [HttpPost("{id}")]
        [Log]
        [Authorize]
        public void Post(int id)
        {
            Game.Move(id);
        }

        // PUT: api/Game/5
        [HttpPut("{id}")]
        [Log]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Log]
        public void Delete(int id)
        {
        }
    }
}
