using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDML.ViewModels
{
   public class RateViewModel
    {
        public string FromUser { get; set; }

        public string ToUser { get; set; }

        public int Rate { get; set; }

        public string Comment { get; set; }

        public string Created { get; set; }
    }
}
