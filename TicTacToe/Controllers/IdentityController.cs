using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using TicTacToe.Models;

namespace TicTacToe.Controllers
{
    [Route("")]
    [Route("api/values")]
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        [Log]
        public string Get()
        {
            return "TicTacToe Game";
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [Log]
        public ActionResult Get(int id)
        {
            return null;
        }

        // POST api/values
        [HttpPost]
        [Log]
        public ActionResult<string> Post([FromBody]JObject input)
        {
            string firstName = input.GetValue("FirstName").ToString();
            string lastName = input.GetValue("LastName").ToString();
            string userName = input.GetValue("UserName").ToString();
            string token = CreateMD5(userName);
            User user = new User()
            {
                FirstName = firstName,
                LastName = lastName,
                UserName = userName,
                Token = token
            };
                SQLServer.Instance.AddUser(user);
            return Ok(token);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [Log]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [Log]
        public void Delete(int id)
        {
        }

        private static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
