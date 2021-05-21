using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace WebProject.Models


{
    public class OrderDetails
    {
        [Key]
        public int OrderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string addressOrder { get; set; }
        public string PhoneNumberOrder { get; set; }
        public List<Recipe> Recipes { get; set; }
        public int PriceOrder { get; set; }
        public CreditCard CreditCardOrder { get; set; }

    }
}
