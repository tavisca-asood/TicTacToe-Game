using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe.Models;

namespace TicTacToe
{
    public class SQLServer
    {
        private static SQLServer _instance = null;
        private SQLServer() { }

        public static SQLServer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SQLServer();
                }
                return _instance;
            }
        }
        public void Log(Log log)
        {
            using (TicTacToeEntity entity = new TicTacToeEntity())
            {
                entity.Logs.Add(log);
                entity.SaveChanges();
            }
        }
        public void AddUser(User user)
        {
            using (TicTacToeEntity entity = new TicTacToeEntity())
            {
                if (entity.Users.FirstOrDefault(x => x.Token == user.Token) != null)
                {
                    return;
                }
                entity.Users.Add(
                    new User()
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        UserName = user.UserName,
                        Token = user.Token
                    });
                entity.SaveChanges();
            }
        }
    }
}
