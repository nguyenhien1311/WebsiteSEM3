using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDAL.DataModels
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
        [EmailAddress(ErrorMessage ="Email invalid!")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter phone number")]
        [Phone(ErrorMessage ="Phone number invalid!")]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter username")]
        [DataType(DataType.Text)]
        [MinLength(6, ErrorMessage = "User name need atleast {0} charactor")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password need atleast {0} charactor")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public bool Status { get; set; }

        public int Rate { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime Created { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Updated { get; set; }

        public virtual ICollection<Items> Items { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }

        public virtual ICollection<BidLog> BidLogs { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
