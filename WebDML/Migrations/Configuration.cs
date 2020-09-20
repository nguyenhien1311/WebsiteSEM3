namespace WebDAL.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using WebDAL.DataModels;
    internal sealed class Configuration : DbMigrationsConfiguration<OLAuctionContext>
    {
        public Configuration()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(OLAuctionContext context)
        {
            // create list data for all table and insert some seed data
            IList<Items> lst_Item = new List<Items>();
            IList<Category> lst_Cat = new List<Category>();
            IList<Users> lst_User = new List<Users>() {
                new Users { UserId="USER01",FirstName = "Nguyễn Hữu",LastName="Hiền",Email="Hien01@gmail.com",Phone="0120000009",Rate=5,UserName="hienhien",Password="hien2000",Status=true,Created=DateTime.Now},
                new Users { UserId="USER02",FirstName = "Vũ Minh",LastName="Đạt",Email="Vuminhdat@gmail.com",Phone="0120000007",Rate=5,UserName="datdat",Password="dat2000",Status=true,Created=DateTime.Now},
                new Users { UserId="USER03",FirstName = "Trần Thế",LastName="Duyệt",Email="antiVNG@gmail.com",Phone="0120000006",Rate=5,UserName="duyetdp",Password="duyet2000",Status=true,Created=DateTime.Now}
            };
            IList<Orders> lst_Order = new List<Orders>();
            IList<Rating> lst_Rating = new List<Rating>();
            IList<BidLog> lst_Log = new List<BidLog>();
            IList<Administrator> lst_Admin = new List<Administrator>() {
                new Administrator { AdminId="AD01",LoginName = "admin",Password="admin",Status=true,Created=DateTime.Now},
                new Administrator { AdminId="AD02",LoginName = "dat09",Password="admin",Status=true,Created=DateTime.Now},
                new Administrator { AdminId="AD03",LoginName = "duyet",Password="admin",Status=true,Created=DateTime.Now}
            };

            // add all seed data to db and save
            foreach (var item in lst_Item)
            {
               context.Items.AddOrUpdate(item);
            }
            foreach (var item in lst_Cat)
            {
                context.Categories.AddOrUpdate(item);
            }
            foreach (var item in lst_User)
            {
                context.Users.AddOrUpdate(item);
            }
            foreach (var item in lst_Order)
            {
                context.Orders.AddOrUpdate(item);
            }
            foreach (var item in lst_Log)
            {
                context.BidLogs.AddOrUpdate(item);
            }
            foreach (var item in lst_Rating)
            {
                context.Ratings.AddOrUpdate(item);
            }
            foreach (var item in lst_Admin)
            {
                context.Administrators.AddOrUpdate(item);
            }
           
            base.Seed(context);
        }
    }
}
