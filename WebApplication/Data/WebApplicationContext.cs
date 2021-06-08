using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebProject.Models;
using WebApplication.Models;

namespace WebApplication.Data
{
    public class WebApplicationContext : DbContext
    {
        public WebApplicationContext (DbContextOptions<WebApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<WebProject.Models.Category> Category { get; set; }

        public DbSet<WebProject.Models.CreditCard> CreditCard { get; set; }

        public DbSet<WebProject.Models.OrderDetails> OrderDetails { get; set; }

        public DbSet<WebProject.Models.Recipe> Recipe { get; set; }

        public DbSet<WebProject.Models.Users> Users { get; set; }

        public DbSet<WebProject.Models.Orders> Orders { get; set; }

        public DbSet<WebApplication.Models.Branches> Branches { get; set; }
    }
}
