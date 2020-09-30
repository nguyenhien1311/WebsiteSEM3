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
            IList<Items> lst_Item = new List<Items>() {
                new Items{ ItemId = "IT01" , ItemTitle="Nike Shoes",ItemDescription="a Shoes ",ItemImage="~/Areas/Admin/Assests/images/Items/1.jpg",BidStatus=false,BidStartDate=DateTime.Now,BidEndDate=DateTime.Now.AddDays(2),BidIncrement=50000,MinimumBid=2,CategoryId="SH", UserId="USER01" },
                new Items{ ItemId = "IT02" , ItemTitle="Hunder X Shoes",ItemDescription="a Shoes ",ItemImage="~/Areas/Admin/Assests/images/Items/2.jpg",BidStatus=false,BidStartDate=DateTime.Now,BidEndDate=DateTime.Now.AddDays(2),BidIncrement=100000,MinimumBid=1,CategoryId="SH", UserId="USER02" },
                new Items{ ItemId = "IT03" , ItemTitle="Adidas Shoes",ItemDescription="a Shoes ",ItemImage="~/Areas/Admin/Assests/images/Items/3.jpg",BidStatus=true,BidStartDate=DateTime.Now,BidEndDate=DateTime.Now.AddDays(2),BidIncrement=200000,MinimumBid=2,CategoryId="SH", UserId="USER03" },
                new Items{ ItemId = "IT04" , ItemTitle="Soccer Shoes",ItemDescription="a Shoes ",ItemImage="~/Areas/Admin/Assests/images/Items/4.jpg",BidStatus=true,BidStartDate=DateTime.Now,BidEndDate=DateTime.Now.AddDays(2),BidIncrement=250000,MinimumBid=1,CategoryId="SH", UserId="USER02" },
                new Items{ ItemId = "IT05" , ItemTitle="iPhone Xs max",ItemDescription="a phone ",ItemImage="~/Areas/Admin/Assests/images/Items/5.jpg",BidStatus=true,BidStartDate=DateTime.Now,BidEndDate=DateTime.Now.AddDays(2),BidIncrement=250000,MinimumBid=2,CategoryId="MP", UserId="USER03" },
                new Items{ ItemId = "IT06" , ItemTitle="iPhone 8 plus",ItemDescription="a phone ",ItemImage="~/Areas/Admin/Assests/images/Items/6.jpg",BidStatus=true,BidStartDate=DateTime.Now,BidEndDate=DateTime.Now.AddDays(2),BidIncrement=200000,MinimumBid=3,CategoryId="MP", UserId="USER03" },
                new Items{ ItemId = "IT07" , ItemTitle="iPhone 11Pro max",ItemDescription="a phone ",ItemImage="~/Areas/Admin/Assests/images/Items/7.jpg",BidStatus=true,BidStartDate=DateTime.Now,BidEndDate=DateTime.Now.AddDays(2),BidIncrement=100000,MinimumBid=2,CategoryId="MP", UserId="USER01" },
                new Items{ ItemId = "IT08" , ItemTitle="iPhone Xr",ItemDescription="a phone ",ItemImage="~/Areas/Admin/Assests/images/Items/8.jpg",BidStatus=true,BidStartDate=DateTime.Now,BidEndDate=DateTime.Now.AddDays(2),BidIncrement=50000,MinimumBid=1,CategoryId="MP", UserId="USER02" },
                new Items{ ItemId = "IT09" , ItemTitle="Bulldog Pom's Insurance",ItemDescription="a Insurrance ",ItemImage="~/Areas/Admin/Assests/images/Items/9.jpg",BidStatus=true,BidStartDate=DateTime.Now,BidEndDate=DateTime.Now.AddDays(2),BidIncrement=100000,MinimumBid=3,CategoryId="IR", UserId="USER01" },
                new Items{ ItemId = "IT10" , ItemTitle="Yohe 981 Fullface Helmets",ItemDescription="a Insurrance ",ItemImage="~/Areas/Admin/Assests/images/Items/10.jpg",BidStatus=true,BidStartDate=DateTime.Now,BidEndDate=DateTime.Now.AddDays(2),BidIncrement=100000,MinimumBid=2,CategoryId="IR", UserId="USER03" },
                new Items{ ItemId = "IT11" , ItemTitle="EGO E7 Helmets",ItemDescription="a Insurrance ",ItemImage="~/Areas/Admin/Assests/images/Items/11.jpg",BidStatus=true,BidStartDate=DateTime.Now,BidEndDate=DateTime.Now.AddDays(2),BidIncrement=250000,MinimumBid=1,CategoryId="IR", UserId="USER02" },
                new Items{ ItemId = "IT12" , ItemTitle="Bulldog Pom's Insurance 2",ItemDescription="a Insurrance ",ItemImage="~/Areas/Admin/Assests/images/Items/12.jpg",BidStatus=true,BidStartDate=DateTime.Now,BidEndDate=DateTime.Now.AddDays(2),BidIncrement=50000,MinimumBid=1,CategoryId="IR", UserId="USER01" },
                new Items{ ItemId = "IT13" , ItemTitle="Sh Motorcycle",ItemDescription="a Motorcycle ",ItemImage="~/Areas/Admin/Assests/images/Items/13.jpg",BidStatus=true,BidStartDate=DateTime.Now,BidEndDate=DateTime.Now.AddDays(2),BidIncrement=150000,MinimumBid=2,CategoryId="MT", UserId="USER02" },
                new Items{ ItemId = "IT14" , ItemTitle="Ducati 959 Motorbike",ItemDescription="a Motorbike ",ItemImage="~/Areas/Admin/Assests/images/Items/14.jpg",BidStatus=true,BidStartDate=DateTime.Now,BidEndDate=DateTime.Now.AddDays(2),BidIncrement=50000,MinimumBid=3,CategoryId="MT", UserId="USER03" },
                new Items{ ItemId = "IT15" , ItemTitle="R15 Motorbike",ItemDescription="a Motorbike ",ItemImage="~/Areas/Admin/Assests/images/Items/15.jpg",BidStatus=true,BidStartDate=DateTime.Now,BidEndDate=DateTime.Now.AddDays(2),BidIncrement=250000,MinimumBid=3,CategoryId="MT", UserId="USER01" },
                new Items{ ItemId = "IT16" , ItemTitle="Exciter Motorcycle",ItemDescription="a Motorcycle ",ItemImage="~/Areas/Admin/Assests/images/Items/16.jpg",BidStatus=true,BidStartDate=DateTime.Now,BidEndDate=DateTime.Now.AddDays(2),BidIncrement=200000,MinimumBid=2,CategoryId="MT", UserId="USER01" },
                new Items{ ItemId = "IT17" , ItemTitle="silver Watch",ItemDescription="a watch ",ItemImage="~/Areas/Admin/Assests/images/Items/17.jpg",BidStatus=true,BidStartDate=DateTime.Now,BidEndDate=DateTime.Now.AddDays(2),BidIncrement=300000,MinimumBid=3,CategoryId="SW", UserId="USER01" },
                new Items{ ItemId = "IT18" , ItemTitle="hublot Watch",ItemDescription="a watch ",ItemImage="~/Areas/Admin/Assests/images/Items/18.jpg",BidStatus=true,BidStartDate=DateTime.Now,BidEndDate=DateTime.Now.AddDays(2),BidIncrement=250000,MinimumBid=1,CategoryId="SW", UserId="USER03" },
                new Items{ ItemId = "IT19" , ItemTitle="rolex Watch",ItemDescription="a watch ",ItemImage="~/Areas/Admin/Assests/images/Items/19.jpg",BidStatus=true,BidStartDate=DateTime.Now,BidEndDate=DateTime.Now.AddDays(2),BidIncrement=50000,MinimumBid=1,CategoryId="SW", UserId="USER02" },
                new Items{ ItemId = "IT20" , ItemTitle="casio Watch",ItemDescription="a watch ",ItemImage="~/Areas/Admin/Assests/images/Items/20.jpg",BidStatus=true,BidStartDate=DateTime.Now,BidEndDate=DateTime.Now.AddDays(2),BidIncrement=100000,MinimumBid=2,CategoryId="SW", UserId="USER01" },
                new Items{ ItemId = "IT21" , ItemTitle="wooden bracelet",ItemDescription="a Jewelry ",ItemImage="~/Areas/Admin/Assests/images/Items/21.jpg",BidStatus=true,BidStartDate=DateTime.Now,BidEndDate=DateTime.Now.AddDays(2),BidIncrement=50000,MinimumBid=2,CategoryId="JL", UserId="USER02" },
                new Items{ ItemId = "IT22" , ItemTitle="fancy bracelet",ItemDescription="a Jewelry ",ItemImage="~/Areas/Admin/Assests/images/Items/22.jpg",BidStatus=false,BidStartDate=DateTime.Now,BidEndDate=DateTime.Now.AddDays(2),BidIncrement=200000,MinimumBid=3,CategoryId="JL", UserId="USER01" },
                new Items{ ItemId = "IT23" , ItemTitle="western gold",ItemDescription="a Jewelry ",ItemImage="~/Areas/Admin/Assests/images/Items/23.jpg",BidStatus=false,BidStartDate=DateTime.Now,BidEndDate=DateTime.Now.AddDays(2),BidIncrement=50000,MinimumBid=3,CategoryId="JL", UserId="USER03" },
                new Items{ ItemId = "IT24" , ItemTitle="wooden ring",ItemDescription="a Jewelry ",ItemImage="~/Areas/Admin/Assests/images/Items/24.jpg",BidStatus=true,BidStartDate=DateTime.Now,BidEndDate=DateTime.Now.AddDays(2),BidIncrement=150000,MinimumBid=3,CategoryId="JL", UserId="USER01" }

        };
            IList<Category> lst_Cat = new List<Category>()
            {
                new Category{ CategoryId ="SH", CategoryName="Shoes",Description="Shoes for different purposes" },
                new Category{ CategoryId ="MP", CategoryName="Smart Phone",Description="Phone for apple lovers" },
                new Category{ CategoryId ="IR", CategoryName="Insurrance",Description="Wind shield, dust for users" },
                new Category{ CategoryId ="MT", CategoryName="Motorcycle ",Description="High speech lovers" },
                new Category{ CategoryId ="SW", CategoryName="Sport Watches",Description="Watch for sport lovers" },
                new Category{ CategoryId ="JL", CategoryName="Jewelry",Description="Glass high quality" },

            };
            IList<Users> lst_User = new List<Users>() {
                new Users { UserId="USER01",FirstName = "Nguyễn Hữu",LastName="Hiền",Email="Hien01@gmail.com",Phone="0120000009",Rate=5,UserName="hienhien",Password="hien2000",Status=true,Created= DateTime.Now},
                new Users { UserId="USER02",FirstName = "Vũ Minh",LastName="Đạt",Email="Vuminhdat@gmail.com",Phone="0120000007",Rate=5,UserName="datdat",Password="dat2000",Status=true,Created= DateTime.Now},
                new Users { UserId="USER03",FirstName = "Trần Thế",LastName="Duyệt",Email="antiVNG@gmail.com",Phone="0120000006",Rate=5,UserName="duyetdp",Password="duyet2000",Status=true,Created= DateTime.Now}
            };
            IList<Orders> lst_Order = new List<Orders>() {
            new Orders{OrderId="OD01",UserId="USER02" ,ItemId= "IT01",Price=100000,Status=true,Created=DateTime.Now},
            new Orders{OrderId="OD02",UserId="USER03" ,ItemId= "IT02",Price=110000,Status=true,Created=DateTime.Now},
            new Orders{OrderId="OD03",UserId="USER01" ,ItemId= "IT23",Price=100000,Status=true,Created=DateTime.Now},
            new Orders{OrderId="OD04",UserId="USER02" ,ItemId= "IT22",Price=210000,Status=true,Created=DateTime.Now}
            };
            IList<Rating> lst_Rating = new List<Rating>();
            IList<BidLog> lst_Log = new List<BidLog>() {
            new BidLog{ ItemId="IT01",UserId="USER02",BidPrice=100000, BidDate =DateTime.Now },
            new BidLog{ ItemId="IT02",UserId="USER03",BidPrice=110000, BidDate =DateTime.Now },
            new BidLog{ ItemId="IT23",UserId="USER01",BidPrice=100000, BidDate =DateTime.Now },
            new BidLog{ ItemId="IT22",UserId="USER02",BidPrice=210000, BidDate =DateTime.Now },
            };
            IList<Administrator> lst_Admin = new List<Administrator>() {
                new Administrator { AdminId="AD01",LoginName = "admin",Password="admin",Status=true,Created= DateTime.Now},
                new Administrator { AdminId="AD02",LoginName = "dat09",Password="admin",Status=true,Created= DateTime.Now},
                new Administrator { AdminId="AD03",LoginName = "duyet",Password="admin",Status=true,Created= DateTime.Now}
            };

            // add all seed data to db and save, use AddOrUpdate to avoid dupplicate data
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
