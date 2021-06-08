using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebProject.Models;

namespace WebApplication.Models
{
    public class Branches
    {
        [Key]
        public int BranchId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public float lat { get; set; }

        public float lng { get; set; }

        public int UserId { get; set; } = 1000;

        public List<Users> Users { get; set; }




    }
}
