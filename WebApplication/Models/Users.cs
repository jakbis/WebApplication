using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace WebProject.Models
{

    public enum UserType
    {
        Client,
        Admin
    }
  
    public class Users
    {
        [Key]
        public int UserId{get;set;}
        
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public int Password { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = "fill";
        
        bool KeepmeSignedin { get; set; }
        
        public List<Orders> Orders { get; set; }

        public UserType Type { get; set; } = UserType.Client;

    }
}
