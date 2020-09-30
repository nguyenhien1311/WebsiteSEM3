using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDML.ViewModels
{
  public  class ItemViewModel
    {

        public string ItemId { get; set; }

        public string ItemTitle { get; set; }

        public string ItemDescription { get; set; }

        public string ItemImage { get; set; }

        public bool BidStatus { get; set; }

        public DateTime BidStartDate { get; set; }

        public DateTime BidEndDate { get; set; }

        public float BidIncrement { get; set; }

        public float MinimumBid { get; set; }

        public string CategorynName { get; set; }

        public string UserName { get; set; }

        public float UserRate { get; set; }

    }
}
