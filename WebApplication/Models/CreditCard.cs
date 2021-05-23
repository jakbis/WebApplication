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
        public string NumberCard { get; set; }

        public string name { get; set; }
        private int Date { get; set; }
        private int Csv { get; set; }
        [Key, ForeignKey("NumberOrder"), Column(Order = 1)]//השלים ולבדוק
        public Orders OrderId { get; set; }
    }
}
