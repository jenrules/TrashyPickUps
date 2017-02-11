using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Trash.Models
{
    public class PaymentModel
    {
        public int ID { get; set; }
        public int Payment { get; set; }
        public Customer Customer { get; set; }
        public int CustomerID { get; set; }
    }
}