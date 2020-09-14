using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDML.DataModels
{
    public class Administrator
    {
        [Key]
        [Required(ErrorMessage ="Please enter admin id")]
        [Display(Name ="Admin ID")]
        public string AdminId { get; set; }
        [Required(ErrorMessage = "Please enter login name")]
        [Display(Name = "Login Name")]
        public string LoginName { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public DateTime Created { get; set; }

        public bool Status { get; set; }
    }
}
