using System;
using System.Linq;
using PetShop.Core.Entity;

namespace PetShop.Infrastructure.Data
{
    public class DBInitialiser
    {
        public static void SeedDB(PetShopContext ctx)
        {
            ctx.Database.EnsureCreated();
            if (!ctx.Pets.Any() && !ctx.Owners.Any())
            {
                var own = ctx.Owners.Add(new Owner()
                {
                    Birthdate = DateTime.Now,
                    Email = "yindoom@hotmail.com",
                    FirstName = "Bastian",
                    LastName = "Bønkel"
                }).Entity;

                var own2 = ctx.Owners.Add(new Owner()
                {
                    Birthdate = DateTime.Now,
                    Email = "yindoom@hotmail.com",
                    FirstName = "Naitsab",
                    LastName = "Bønkel"
                }).Entity;

                ctx.Pets.Add(new Pet()
                {
                    Birthdate = DateTime.Now,
                    Colour = "red",
                    Name = "Piggy",
                    Type = "Pig",
                    Price = 5000,
                    PreviousOwner = own2,
                    SellDate = DateTime.Now
                });
                ctx.Pets.Add(new Pet()
                {
                    Birthdate = DateTime.Now,
                    Colour = "Cream",
                    Name = "Miaw",
                    Type = "Cat",
                    Price = 5000,
                    PreviousOwner = own,
                    SellDate = DateTime.Now
                });
                ctx.Pets.Add(new Pet()
                {
                    Birthdate = DateTime.Now,
                    Colour = "Brown",
                    Name = "Woof",
                    Type = "Dog",
                    Price = 5000,
                    PreviousOwner = own,
                    SellDate = DateTime.Now
                });
                ctx.SaveChanges();
            }
        }
    }
}