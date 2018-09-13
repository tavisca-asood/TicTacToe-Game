using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe.Models;

namespace TicTacToe
{
    public class AuthorizeAttribute : ResultFilterAttribute, IActionFilter
    {
        private static string _current = string.Empty;
        private static List<string> _users = new List<string>();
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string apiKey = context.HttpContext.Request.Headers["apikey"].ToString();
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new UnauthorizedAccessException("Api Key not passed!");
            }
            else
            {
                using (TicTacToeEntity entity = new TicTacToeEntity())
                {
                    if(entity.Users.FirstOrDefault(x=>x.Token==apiKey)==null)
                    {
                        throw new UnauthorizedAccessException("Invalid API Key!");
                    }
                }
            }
            if(apiKey==_current)
            {
                throw new InvalidOperationException("Please wait for the other player's turn");
            }
            if(_users.Count==2&&!_users.Contains(apiKey))
            {
                throw new InvalidOperationException("Only 2 users are allowed to play the game at a time");
            }
            _current = apiKey;
            if(_users.Count!=2)
            _users.Add(apiKey);
        }
    }
}
