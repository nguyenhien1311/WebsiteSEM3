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
                new Items{ ItemId = "IT01" , ItemTitle="silver Watch",ItemDescription="a watch ",ItemImage="~/Areas/Admin/Assests/images/Items/1.jpg",BidStatus=true,BidStartDate=DateTime.Now,BidEndDate=DateTime.Now.AddDays(2),BidIncrement=50000,MinimumBid=2,CategoryId="SW", UserId="USER01" },
                new Items{ ItemId = "IT02" , ItemTitle="hublot Watch",ItemDescription="a watch ",ItemImage="~/Areas/Admin/Assests/images/Items/2.jpg",BidStatus=true,BidStartDate=DateTime.Now,BidEndDate=DateTime.Now.AddDays(2),BidIncrement=100000,MinimumBid=1,CategoryId="SW", UserId="USER02" },
                new Items{ ItemId = "IT03" , ItemTitle="rolex Watch",ItemDescription="a watch ",ItemImage="~/Areas/Admin/Assests/images/Items/3.jpg",BidStatus=true,BidStartDate=DateTime.Now,BidEndDate=DateTime.Now.AddDays(2),BidIncrement=200000,MinimumBid=2,CategoryId="SW", UserId="USER03" },
                new Items{ ItemId = "IT04" , ItemTitle="casio Watch",ItemDescription="a watch ",ItemImage="~/Areas/Admin/Assests/images/Items/4.jpg",BidStatus=true,BidStartDate=DateTime.Now,BidEndDate=DateTime.Now.AddDays(2),BidIncrement=250000,MinimumBid=1,CategoryId="SW", UserId="USER02" },
                new Items{ ItemId = "IT05" , ItemTitle="iPhone Xs max",ItemDescription="a phone ",ItemImage="~/Areas/Admin/Assests/images/Items/5.jpg",BidStatus=true,BidStartDate=DateTime.Now,BidEndDate=DateTime.Now.AddDays(2),BidIncrement=250000,MinimumBid=2,CategoryId="MP", UserId="USER03" },
                new Items{ ItemId = "IT06" , ItemTitle="iPhone 8 plus",ItemDescription="a phone ",ItemImage="~/Areas/Admin/Assests/images/Items/6.jpg",BidStatus=true,BidStartDate=DateTime.Now,BidEndDate=DateTime.Now.AddDays(2),BidIncrement=200000,MinimumBid=3,CategoryId="MP", UserId="USER03" },
                new Items{ ItemId = "IT07" , ItemTitle="iPhone 11Pro max",ItemDescription="a phone ",ItemImage="~/Areas/Admin/Assests/images/Items/7.jpg",BidStatus=true,BidStartDate=DateTime.Now,BidEndDate=DateTime.Now.AddDays(2),BidIncrement=100000,MinimumBid=2,CategoryId="MP", UserId="USER01" },
                new Items{ ItemId = "IT08" , ItemTitle="iPhone Xr",ItemDescription="a phone ",ItemImage="~/Areas/Admin/Assests/images/Items/8.jpg",BidStatus=true,BidStartDate=DateTime.Now,BidEndDate=DateTime.Now.AddDays(2),BidIncrement=50000,MinimumBid=1,CategoryId="MP", UserId="USER02" },
                new Items{ ItemId = "IT09" , ItemTitle="bmw i8 Car",ItemDescription="a car ",ItemImage="~/Areas/Admin/Assests/images/Items/9.jpg",BidStatus=true,BidStartDate=DateTime.Now,BidEndDate=DateTime.Now.AddDays(2),BidIncrement=100000,MinimumBid=3,CategoryId="CAR", UserId="USER01" },
                new Items{ ItemId = "IT10" , ItemTitle="mercedes c300 Car",ItemDescription="a car ",ItemImage="~/Areas/Admin/Assests/images/Items/10.jpg",BidStatus=true,BidStartDate=DateTime.Now,BidEndDate=DateTime.Now.AddDays(2),BidIncrement=100000,MinimumBid=2,CategoryId="CAR", UserId="USER03" },
                new Items{ ItemId = "IT11" , ItemTitle="maybach 650 Car",ItemDescription="a car ",ItemImage="~/Areas/Admin/Assests/images/Items/11.jpg",BidStatus=true,BidStartDate=DateTime.Now,BidEndDate=DateTime.Now.AddDays(2),BidIncrement=250000,MinimumBid=1,CategoryId="CAR", UserId="USER02" },
                new Items{ ItemId = "IT12" , ItemTitle="lamborghini Car",ItemDescription="a car ",ItemImage="~/Areas/Admin/Assests/images/Items/12.jpg",BidStatus=true,BidStartDate=DateTime.Now,BidEndDate=DateTime.Now.AddDays(2),BidIncrement=50000,MinimumBid=1,CategoryId="CAR", UserId="USER01" },
                new Items{ ItemId = "IT13" , ItemTitle="Sh Motorcycle",ItemDescription="a Motorcycle ",ItemImage="~/Areas/Admin/Assests/images/Items/13.jpg",BidStatus=true,BidStartDate=DateTime.Now,BidEndDate=DateTime.Now.AddDays(2),BidIncrement=150000,MinimumBid=2,CategoryId="MT", UserId="USER02" },
                new Items{ ItemId = "IT14" , ItemTitle="Ducati 959 Motorbike",ItemDescription="a Motorbike ",ItemImage="~/Areas/Admin/Assests/images/Items/14.jpg",BidStatus=true,BidStartDate=DateTime.Now,BidEndDate=DateTime.Now.AddDays(2),BidIncrement=50000,MinimumBid=3,CategoryId="MT", UserId="USER03" },
                new Items{ ItemId = "IT15" , ItemTitle="R15 Motorbike",ItemDescription="a Motorbike ",ItemImage="~/Areas/Admin/Assests/images/Items/15.jpg",BidStatus=true,BidStartDate=DateTime.Now,BidEndDate=DateTime.Now.AddDays(2),BidIncrement=250000,MinimumBid=3,CategoryId="MT", UserId="USER01" },
                new Items{ ItemId = "IT16" , ItemTitle="Exciter Motorcycle",ItemDescription="a Motorcycle ",ItemImage="~/Areas/Admin/Assests/images/Items/16.jpg",BidStatus=true,BidStartDate=DateTime.Now,BidEndDate=DateTime.Now.AddDays(2),BidIncrement=200000,MinimumBid=2,CategoryId="MT", UserId="USER01" },
                new Items{ ItemId = "IT17" , ItemTitle="Nike Shoes",ItemDescription="a Shoes ",ItemImage="~/Areas/Admin/Assests/images/Items/17.jpg",BidStatus=true,BidStartDate=DateTime.Now,BidEndDate=DateTime.Now.AddDays(2),BidIncrement=300000,MinimumBid=3,CategoryId="SH", UserId="USER01" },
                new Items{ ItemId = "IT18" , ItemTitle="Hunder X Shoes",ItemDescription="a Shoes ",ItemImage="~/Areas/Admin/Assests/images/Items/18.jpg",BidStatus=true,BidStartDate=DateTime.Now,BidEndDate=DateTime.Now.AddDays(2),BidIncrement=250000,MinimumBid=1,CategoryId="SH", UserId="USER03" },
                new Items{ ItemId = "IT19" , ItemTitle="Adidas Shoes",ItemDescription="a Shoes ",ItemImage="~/Areas/Admin/Assests/images/Items/19.jpg",BidStatus=true,BidStartDate=DateTime.Now,BidEndDate=DateTime.Now.AddDays(2),BidIncrement=50000,MinimumBid=1,CategoryId="SH", UserId="USER02" },
                new Items{ ItemId = "IT20" , ItemTitle="Soccer Shoes",ItemDescription="a Shoes ",ItemImage="~/Areas/Admin/Assests/images/Items/20.jpg",BidStatus=true,BidStartDate=DateTime.Now,BidEndDate=DateTime.Now.AddDays(2),BidIncrement=100000,MinimumBid=2,CategoryId="SH", UserId="USER01" },
                new Items{ ItemId = "IT21" , ItemTitle="Louis vuitton Handbag",ItemDescription="a Handbag ",ItemImage="~/Areas/Admin/Assests/images/Items/21.jpg",BidStatus=true,BidStartDate=DateTime.Now,BidEndDate=DateTime.Now.AddDays(2),BidIncrement=50000,MinimumBid=2,CategoryId="WB", UserId="USER02" },
                new Items{ ItemId = "IT22" , ItemTitle="Louis vuitton long Wallet",ItemDescription="a Wallet ",ItemImage="~/Areas/Admin/Assests/images/Items/22.jpg",BidStatus=true,BidStartDate=DateTime.Now,BidEndDate=DateTime.Now.AddDays(2),BidIncrement=200000,MinimumBid=3,CategoryId="WB", UserId="USER01" },
                new Items{ ItemId = "IT23" , ItemTitle="Louis vuitton Wallet",ItemDescription="a Wallet ",ItemImage="~/Areas/Admin/Assests/images/Items/23.jpg",BidStatus=true,BidStartDate=DateTime.Now,BidEndDate=DateTime.Now.AddDays(2),BidIncrement=50000,MinimumBid=3,CategoryId="WB", UserId="USER03" },
                new Items{ ItemId = "IT24" , ItemTitle="Louis vuitton Women's Wallet",ItemDescription="a Wallet ",ItemImage="~/Areas/Admin/Assests/images/Items/24.jpg",BidStatus=true,BidStartDate=DateTime.Now,BidEndDate=DateTime.Now.AddDays(2),BidIncrement=150000,MinimumBid=3,CategoryId="WB", UserId="USER01" }

        };
            IList<Category> lst_Cat = new List<Category>() {
                new Category{ CategoryId ="SW", CategoryName="Sport Watches",Description="Watch for sport lovers" },
                new Category{ CategoryId ="MP", CategoryName="Smart Phone",Description="Phone for apple lovers" },
                new Category{ CategoryId ="CAR", CategoryName="Car",Description="Run by 4 wheels" },
                new Category{ CategoryId ="MT", CategoryName="Motorcycle ",Description="High speech lovers" },
                new Category{ CategoryId ="SH", CategoryName="Shoes",Description="Shoes for different purposes" },
                new Category{ CategoryId ="WB", CategoryName="Wallet Bag",Description="High-end handbags and business bags" }
            };
            IList<Users> lst_User = new List<Users>() {
                new Users { UserId="USER01",FirstName = "Nguyễn Hữu",LastName="Hiền",Email="Hien01@gmail.com",Phone="0120000009",Rate=5,UserName="hienhien",Password="hien2000",Status=true,Created= DateTime.Now},
                new Users { UserId="USER02",FirstName = "Vũ Minh",LastName="Đạt",Email="Vuminhdat@gmail.com",Phone="0120000007",Rate=5,UserName="datdat",Password="dat2000",Status=true,Created= DateTime.Now},
                new Users { UserId="USER03",FirstName = "Trần Thế",LastName="Duyệt",Email="antiVNG@gmail.com",Phone="0120000006",Rate=5,UserName="duyetdp",Password="duyet2000",Status=true,Created= DateTime.Now}
            };
            IList<Orders> lst_Order = new List<Orders>();
            IList<Rating> lst_Rating = new List<Rating>();
            IList<BidLog> lst_Log = new List<BidLog>();
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
