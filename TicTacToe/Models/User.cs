using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe.Models
{
    public class User
    {
        [Key]
        public int ID{ get; set; }
        [Required]
        public string FirstName{ get; set; }
        [Required]
        public string LastName{ get; set; }
        [Required]
        public string UserName{ get; set; }
        [Required]
        public string Token{ get; set; }
    }
}
