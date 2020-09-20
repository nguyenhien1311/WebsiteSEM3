using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDAL.DataModels
{
    public class Administrator
    {
        [Key]
        [Required(ErrorMessage ="Please enter admin id")]
        [Display(Name ="Admin ID")]
        public string AdminId { get; set; }
        [Required(ErrorMessage = "Please enter login name")]
        [MinLength(5, ErrorMessage = "Login name need atleast {0} charactor")]
        [Display(Name = "Login Name")]
        public string LoginName { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        [MinLength(5, ErrorMessage = "Passsword need atleast {0} charactor")]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Created { get; set; }

        public bool Status { get; set; }
    }
}
