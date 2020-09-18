using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebDAL.DataModels
{
    public class Items
    {
        [Key]
        [Required(ErrorMessage ="Please enter item id"),MaxLength(500)]
        [DataType(DataType.Text,ErrorMessage = "Item id must be a string value")]
        [Display(Name ="Item Id")]
        public string ItemId { get; set; }

        [Required(ErrorMessage = "Please enter item title"), MaxLength(500)]
        [DataType(DataType.Text, ErrorMessage = "Item title must be a string value")]
        [Display(Name = "Item title")]
        [Index(IsUnique = true)]
        public string ItemTitle { get; set; }

        [Required(ErrorMessage = "Please enter item description"), MaxLength(1000)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Item Description")]
        [AllowHtml]
        public string ItemDescription { get; set; }

        [Required(ErrorMessage = "Please enter item image link"), MaxLength(500)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Item Image")]
        [AllowHtml]
        public string ItemImage { get; set; }

        [Display(Name = "Status")]
        public bool BidStatus { get; set; }

        [Display(Name = "Auction start date")]
        public DateTime BidStartDate { get; set; }

        [Required(ErrorMessage = "Please enter auction end date")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Auction end date")]
        public DateTime BidEndDate { get; set; }

        [Required(ErrorMessage = "Please enter current price of the item")]
        [DataType(DataType.Currency),Range(0,int.MaxValue,ErrorMessage ="Please enter correct value")]
        [Display(Name = "Current Bid")]
        public float BidIncrement { get; set; }

        [Required(ErrorMessage = "Please enter minimun bid price")]
        [DataType(DataType.Currency), Range(0, int.MaxValue, ErrorMessage = "Please enter correct value")]
        [Display(Name = "Minimum bid")]
        public float MinimumBid { get; set; }

        [Required(ErrorMessage = "Please choose category of the item")]
        [Display(Name = "Category Id")]
        public string CategoryId { get; set; }

        [Display(Name = "Seller ID")]
        public string UserId { get; set; }


        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        [ForeignKey("UserId")]
        public virtual Users Users { get; set; }

        public virtual ICollection<BidLog> BidLogs { get; set; }

    }
}
