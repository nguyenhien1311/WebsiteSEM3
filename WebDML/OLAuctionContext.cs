﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDML.DataModels;

namespace WebDML
{
    public class OLAuctionContext : DbContext
    {
        public OLAuctionContext() : base("name=Connection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<OLAuctionContext,Migrations.Configuration>("Connection"));
        }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<BidLog> BidLogs { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Administrator> Administrators { get; set; }
    }
}