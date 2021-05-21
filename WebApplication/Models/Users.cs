using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace WebProject.Models
{
  
    public class Users
    {
        [Key]
        public int UserId{get;set;}

        public int Password { get; set; }

        public string Email { get; set; }

        bool RememberMe { get; set; }
        public List<Orders> Orders { get; set; }





    }
}
