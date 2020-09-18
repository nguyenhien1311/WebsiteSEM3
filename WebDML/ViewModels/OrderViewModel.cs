using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDML.ViewModels
{
    public class OrderViewModel
    {
        public string OrderId { get; set; }
        public string User { get; set; }
        public string Item { get; set; }
        public double Price { get; set; }
        public bool Status { get; set; }
        public DateTime Created { get; set; }
    }
}
