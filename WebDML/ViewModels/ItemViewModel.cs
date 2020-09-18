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

        [Display(Name = "Item Id")]
        public string ItemId { get; set; }


        [Display(Name = "Item Title")]
        public string ItemTitle { get; set; }

        [Display(Name = "Item Description")]
        public string ItemDescription { get; set; }


        [Display(Name = "Item Image")]
        public string ItemImage { get; set; }

        [Display(Name = "Status")]
        public bool BidStatus { get; set; }

        [Display(Name = "Stat")]
        public DateTime BidStartDate { get; set; }

        [Display(Name = "End")]
        public DateTime BidEndDate { get; set; }

        [Display(Name = "Current Bid")]
        public float BidIncrement { get; set; }

        [Display(Name = "Minimum bid")]
        public float MinimumBid { get; set; }

        [Display(Name = "Category ")]
        public string CategorynName { get; set; }

        [Display(Name = "Seller ")]
        public string UserName { get; set; }
    }
}
