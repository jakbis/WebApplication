using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace WebProject.Models
{
    public class Recipe
    {
        [Key]
        public  int RecipeId { get; set; }
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
            
        public string ImagePath { get; set; }

        public string Body { get; set; }

        public int Price { get; set; }

        public string Video { get; set; }
        public string Howtomake { get; set; }

    
    }
    
}
