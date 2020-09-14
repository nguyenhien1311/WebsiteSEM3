using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebDML.DataModels
{
    public class Category
    {
        [Key]
        [Required(ErrorMessage ="Please, Enter category id!"),MaxLength(500)]
        [DataType(DataType.Text)]
        [Display(Name ="Category ID")]
        public string CategoryId { get; set; }
        [Required(ErrorMessage = "Please, Enter category name!"),MaxLength(100)]
        [DataType(DataType.Text,ErrorMessage ="Name can't not be number")]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
        [Display(Name = "Category Description")]
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public ICollection<Items> Items { get; set; }
    }
}
