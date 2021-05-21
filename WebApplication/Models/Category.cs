using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebProject.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<Recipe> Recipes { get; set; }

        [Required]
        [DisplayName("Image")]
        public string ImagePath { get; set; }

    }
}
