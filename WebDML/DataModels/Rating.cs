using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WebDAL.DataModels
{
    public class Rating
    {
        [Key, Column(Order = 0)]
        public string FromId { get; set; }

        [Key, Column(Order = 1)]
        public string ToId { get; set; }

        public int Rate { get; set; }

        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }

        [DataType(DataType.DateTime)]
        public string Created { get; set; }

        [ForeignKey("FromId")]
        public virtual Users FromUser { get; set; }

        [ForeignKey("ToId")]
        public virtual Users ToUser { get; set; }
    }
}
