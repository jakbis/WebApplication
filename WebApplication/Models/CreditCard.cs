using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject.Models


{
    public class CreditCard
    {
        [Key]
        [DataType(DataType.CreditCard)]
        public string NumberCard { get; set; }

        public string name { get; set; }
        public int Date { get; set; }
        public int Csv { get; set; }

        public string Kind { get; set; } = "Visa";

        [Key, ForeignKey("NumberOrder"), Column(Order = 1)]
        public Orders OrderId { get; set; }

        public string UserName { get; set; }


    }
}
