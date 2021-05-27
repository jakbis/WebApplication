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
        
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public int Password { get; set; }
       
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        bool KeepmeSignedin { get; set; }
        
        public List<Orders> Orders { get; set; }





    }
}
