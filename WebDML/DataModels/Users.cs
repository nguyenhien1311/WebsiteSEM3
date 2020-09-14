using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDML.DataModels
{
   public class Users
    {
        [Key]
        [Required(ErrorMessage ="Please enter user id")]
        [DataType(DataType.Text)]
        [Display(Name ="User ID")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Please enter first name")]
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter last name")]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter user id")]
        [DataType(DataType.Text)]
        [Display(Name = "User ID")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter phone number")]
        [DataType(DataType.PhoneNumber),MaxLength(10)]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter username")]
        [DataType(DataType.Text)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public bool Status { get; set; }

        public int Rate { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

        public virtual ICollection<Items> Items { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }

        public virtual ICollection<BidLog> BidLogs { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
