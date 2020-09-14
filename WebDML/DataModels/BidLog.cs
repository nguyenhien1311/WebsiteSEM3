﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDML.DataModels
{
   public class BidLog
    {
        [Key,Column(Order = 0)]
        public string ItemId { get; set; }

        [Key, Column(Order = 1)]
        public string UserId { get; set; }

        public float BidPrice { get; set; }

        public DateTime BidDate { get; set; }

        [ForeignKey("UserId")]
        public virtual Users Users { get; set; }

        [ForeignKey("ItemId")]
        public virtual Items Items { get; set; }
    }
}