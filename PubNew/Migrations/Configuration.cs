namespace PubNew.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using PubNew.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<PubNew.DAL.PubContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            //AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(PubNew.DAL.PubContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            var users = new List<User>
            {
                new User{ Id="0001", UserName = "admin"  , Email = "admin@newcafe.com"  ,
                    Password ="adminadmin" , RegisterDate = DateTime.Parse("2012-01-01") ,
                    PasswordHash = User.HashPassword("adminadmin"),
                    SecurityStamp = Guid.NewGuid().ToString()},

                new User{ Id="0002", UserName = "ken"  , Email = "ken123@email.com"    ,
                    Password ="ken123456" , RegisterDate = DateTime.Parse("2018-12-01"),
                    PasswordHash =User.HashPassword("ken123456"),
                    SecurityStamp = Guid.NewGuid().ToString()},

                new User{ Id="0003", UserName = "Jay"  , Email = "jay123@email.com"    ,
                    Password ="Jay123456" , RegisterDate = DateTime.Parse("2019-02-01"),
                    PasswordHash =User.HashPassword("Jay123456"),
                    SecurityStamp = Guid.NewGuid().ToString()},

                new User{ Id="0004", UserName = "List" , Email = "list3@email.com"     ,
                    Password = "LL123456456" , RegisterDate = DateTime.Parse("2019-03-01") },

                new User{ Id="0005",UserName = "Kan"  , Email = "kan789@email.com"    ,
                    Password ="kkan123456", RegisterDate = DateTime.Parse("2019-04-01") },

                new User{ Id="0006",UserName = "Zeta" , Email = "kan789@email.com"    ,
                    Password ="kkan123456", RegisterDate = DateTime.Parse("2018-12-01") },

                new User{ Id="0007",UserName = "kenny"  , Email = "keneny@email.com"    ,
                    Password ="ken123456" , RegisterDate = DateTime.Parse("2018-12-01") },

                new User{ Id="0008",UserName = "JayChow"  , Email = "jaychow@email.com"    ,
                    Password ="Jay123456" , RegisterDate = DateTime.Parse("2019-02-01") },

                new User{ Id="0009",UserName = "ListFan" , Email = "ListFan@email.com"     ,
                    Password ="LL123456"  , RegisterDate = DateTime.Parse("2019-03-01") },

                new User{ Id="0010",UserName = "Kanya"  , Email = "Kanya@email.com"    ,
                    Password ="kkan123456", RegisterDate = DateTime.Parse("2019-04-01") },

                new User{ Id="0011",UserName = "Luck" , Email = "Luck@email.com"    ,
                    Password ="kkan123456", RegisterDate = DateTime.Parse("2018-12-01") },

            };

            //foreach (User u in users)
            //{
            //    var userInDataBase = context.Users.FirstOrDefault();
            //    if (userInDataBase == null)
            //    {
            //        context.Users.AddOrUpdate(p => p.Id, u);
            //    }
            //}
            users.ForEach(s => context.Users.AddOrUpdate(p => p.UserName, s));
            SaveChanges(context);
            //context.SaveChanges();


            var items = new List<Item>
            {
                new Item{ItemName = "Old Fashioned" ,
                    Description = "The Old Fashioned is as classic as they come, and perfect for anyone who likes their whiskey drinks on the sweeter side. Rye will make it spicier." ,
                    Category = "drink" ,Price = 5,
                    isAvailable = true,
                    ItemArt = "/Content/images/OldFashioned.jpg"},

                new Item{ItemName = "Negroni" ,
                    Description = "The Negroni is the epitome of summer drinking: sweet, sun-kissed, and refreshing" ,
                    Category = "drink" ,Price = 9,
                    isAvailable = true,
                    ItemArt = "/Content/images/Negroni.jpg"},

                new Item{ItemName = "Whiskey Sour" ,
                    Description = "For those nights when you want to cleanse your palate, opt for a puckery Whiskey Sour. Specify bourbon for this one." ,
                    Category = "drink" ,Price = 9,
                    isAvailable = true,
                    ItemArt = "/Content/images/WhiskeySour.jpg"},

                new Item{ItemName = "Daiquiri" ,
                    Description = "Speaking of summertime cocktails, the Daiquiri is a citrusy marriage of rum and lime (and the preferred drink of Ernest Hemingway). Strained is preferred." ,
                    Category = "drink" ,Price = 11,
                    isAvailable = true,
                    ItemArt = "/Content/images/Daiquiri.jpg"},

                new Item{ItemName = "Manhattan" ,
                    Description = "While quality whiskey is important, the key to a great Manhattan is the sweet vermouth. So always ask for Carpano Antica. Trust us, it will make all the difference." ,
                    Category = "drink" ,Price = 4,
                    isAvailable = true,
                    ItemArt = "/Content/images/Manhattan.jpg"},

                new Item{ItemName = "Dry Martini" ,
                    Description = "Stir vermouth and gin with cracked ice, strain into a chilled cocktail glass, and garnish with an olive." ,
                    Category = "drink" ,Price = 4,
                    isAvailable = true,
                    ItemArt = "/Content/images/DryMartini.jpg"},

                new Item{ItemName = "Espresso Martini" ,
                    Description = "Shake ingredients with ice until chilled, then strain into a martini glass. Garnish with espresso beans." ,
                    Category = "drink" ,Price = 4,
                    isAvailable = true,
                    ItemArt = "/Content/images/EspressoMartini.jpg"},

                new Item{ItemName = "Margarita",
                    Description = "Rub the rim of a chilled cocktail glass with lime juice and dip in coarse salt. Shake tequila, Cointreau, lime juice, and ice in a mixing glass, then strain into the salted glass over ice.",
                    Category = "drink" ,Price = 4,
                    isAvailable = true,
                    ItemArt = "/Content/images/Margarita.jpg"},

                new Item{ItemName = "Aperol Spritz",
                    Description = "The Aperol Spritz gets a bad rap for being bitter and basic. But for daytime drinking, you really can't beat it. Just ask all the bar patrons crowding the patio around you, Spritzes in hand.",
                    Category = "drink" ,Price = 9,
                    isAvailable = true,
                    ItemArt = "/Content/images/AperolSpritz.jpg"},



                new Item{ItemName = "Blueberry Muffin" ,
                    Description = "Blueberry Muffin" ,
                    Category = "snack" ,
                    Price = 4,
                    isAvailable = true,
                    ItemArt = "/Content/images/BlueberryMuffin.jpg"},
                new Item{ItemName = "French Butter Croissant" ,
                    Description = "French Butter Croissant" ,
                    Category = "snack" ,
                    Price = 6,
                    ItemArt = ""},
                new Item{ItemName = "Sausage Roll" ,
                    Description = "Sausage Roll" ,
                    Category = "snack" ,
                    Price = 5,
                    isAvailable = true,
                    ItemArt = "/Content/images/SausageRoll.jpg"},
                new Item{ItemName = "Mushroom Cheese Pocket" ,
                    Description = "Mushroom Cheese Pocket" ,
                    Category = "snack" ,
                    Price = 4,
                    ItemArt = "/Content/images/MushroomCheesePocket.jpg"},
            };


            items.ForEach(s => context.Items.AddOrUpdate(p => p.ItemName, s));
            //SaveChanges(context);
            context.SaveChanges();

            var orders = new List<Order>
            {
                new Order{UserID = users.Single(s => s.UserName == "ken").Id ,
                    CreatDate = DateTime.Parse("2019-04-01") , Stauts = "done" , TotalPrice = 10},
                new Order{UserID = users.Single(s => s.UserName == "ken").Id ,
                    CreatDate = DateTime.Parse("2019-04-02") , Stauts = "done" , TotalPrice = 10 },
                new Order{UserID = users.Single(s => s.UserName == "Jay").Id ,
                    CreatDate = DateTime.Parse("2019-04-02") , Stauts = "done" , TotalPrice = 10},
                new Order{UserID = users.Single(s => s.UserName == "Zeta").Id ,
                    CreatDate = DateTime.Parse("2019-04-01") , Stauts = "done" , TotalPrice = 10},
                new Order{UserID = users.Single(s => s.UserName == "Luck").Id ,
                    CreatDate = DateTime.Parse("2019-04-01") , Stauts = "done" , TotalPrice = 16},
                new Order{UserID = users.Single(s => s.UserName == "kenny").Id ,
                    CreatDate = DateTime.Parse("2019-04-02") , Stauts = "done" , TotalPrice = 24 },
                new Order{UserID = users.Single(s => s.UserName == "ken").Id ,
                    CreatDate = DateTime.Parse("2019-04-02") , Stauts = "done" , TotalPrice = 20},
                new Order{UserID = users.Single(s => s.UserName == "List").Id ,
                    CreatDate = DateTime.Parse("2019-04-01") , Stauts = "done" , TotalPrice = 73},
            };

            var orderItems = new List<OrderItem>
            {
                new OrderItem
                {
                    ItemID = items.Single(s => s.ItemName =="Old Fashioned").ItemID ,
                    OrderID = 1, Quantity = 2 , Price = items.Single(s => s.ItemName =="Old Fashioned").Price * 2
                },
                new OrderItem
                {
                    ItemID = items.Single(s => s.ItemName =="Negroni").ItemID ,
                    OrderID = 2, Quantity = 2 , Price = items.Single(s => s.ItemName =="Old Fashioned").Price * 2
                }
            };

            foreach (Order o in orders)
            {
                var orderInDataBase = context.Orders.FirstOrDefault();
                if (orderInDataBase == null)
                {
                    context.Orders.AddOrUpdate(p => p.OrderID, o);
                }
            }
            SaveChanges(context);

            if (!context.Roles.Any(r => r.Name == "AppAdmin"))
            {
                var role = new IdentityRole { Id = "000", Name = "AppAdmin" };

                context.Roles.Add(role);
                SaveChanges(context);
                
            }


            var user = users.Single(s => s.UserName == "admin");
            var ro = context.Roles.Single(r => r.Name == "AppAdmin");
            var userR = new IdentityUserRole { RoleId = ro.Id, UserId = user.Id };
            context.UserRoles.Add(userR);
            SaveChanges(context);
        }

        private void SaveChanges(DbContext context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                ); // Add the original exception as the innerException
            }
        }

    }
}
