using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDAL.DataModels
{
    public class Orders
    {
        [Key]
        public string OrderId { get; set; }
        public string UserId { get; set; }
        public string ItemId { get; set; }
        public double Price { get; set; }
        public bool Status { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime Created { get; set; }

        [ForeignKey("UserId")]
        public virtual Users Users { get; set; }
        [ForeignKey("ItemId")]
        public virtual Items  Items { get; set; }
    }
}
