using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace WebProject.Models
{
    public class Orders
    {
        [Key]
        public int NumberOrder { get; set; }
        public Users UserId { get; set; }
        public string DateOrder { get; set; }

        public int RecipeId { get; set; }

        public List<Recipe> Recipes { get; set; }


    }
}

