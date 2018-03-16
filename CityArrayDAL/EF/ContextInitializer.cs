using CityArrayDAL.Identity;
using CityArrayDAL.Model;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CityArrayDAL.EF
{
    class ContextInitializer : DropCreateDatabaseAlways<CityArrayContext>
    {
        protected override void Seed(CityArrayContext context)
        {
            Console.WriteLine(context.Database.Connection.ConnectionString);

            var roleManager = new AppRoleManager(new AppRoleStore(context));
            var userManager = new AppUserManager(new AppUserStore(context));

            var roleUser = new AppRole { Name = "User" };
            var roleAdmin = new AppRole { Name = "Admin" };

            roleManager.Create(roleUser);
            roleManager.Create(roleAdmin);

            var userAdmin = new AppUser { Email = "alexshovkoplyas@gmail.com", UserName = "Administrator" };
            userManager.Create(userAdmin, "admin123");
            userManager.AddToRole(userAdmin.Id, "Admin");

            var users = new AppUser[] {
                new AppUser { Email = "Alex1@gmail.com", UserName = "Alex1@gmail.com" },
                new AppUser { Email = "Alex2@gmail.com", UserName = "Alex2@gmail.com" },
                new AppUser { Email = "Alex3@gmail.com", UserName = "Alex3@gmail.com" },
                new AppUser { Email = "Alex4@gmail.com", UserName = "Alex4@gmail.com" },
                new AppUser { Email = "Alex5@gmail.com", UserName = "Alex5@gmail.com" },
            };

            for (int i = 0; i < users.Length; i++)
            {
                var t2 = userManager.Create(users[i], "user123");
                userManager.AddToRole(users[i].Id, "User");
            }

            context.SaveChanges();

            var countries = new Country[]
            {
                new Country{Name = "Ukraine"},
                new Country{Name = "Austria"},
                new Country{Name = "England"},
                new Country{Name="Czech Republic"}
            };

            context.Countries.AddRange(countries);

            var people = new Person[]
            {
                new Person
                {
                    FirstName = "Alex",
                    LastName = "First",
                    NickName = "Alex First",
                    BirthDay = new DateTime(1980,1,5),
                    Nationality = countries[0],
                    AppUser = users[0],
                    AddDay = DateTime.Today
                },
                new Person
                {
                    FirstName = "Alex",
                    LastName = "Second",
                    NickName = "Alex Second",
                    BirthDay = new DateTime(1990,3,5),
                    Nationality = countries[1],
                    AppUser = users[1],
                    AddDay = DateTime.Today
                },
                new Person
                {
                    FirstName = "Alex",
                    LastName = "First",
                    NickName = "Alex Third",
                    BirthDay = new DateTime(2000,6,5),
                    Nationality = countries[0],
                    AppUser = users[2],
                    AddDay = DateTime.Today
                },
                new Person
                {
                    FirstName = "Alex",
                    LastName = "Forth",
                    NickName = "Alex Forth",
                    BirthDay = new DateTime(1987,1,5),
                    Nationality = countries[2],
                    AppUser = users[3],
                    AddDay = DateTime.Today
                },
                new Person
                {
                    FirstName = "Alex",
                    LastName = "Fifth",
                    NickName = "Alex Fifth",
                    BirthDay = new DateTime(1994,12,5),
                    Nationality = countries[1],
                    AppUser = users[4],
                    AddDay = DateTime.Today
                }
            };

            context.People.AddRange(people);

            context.SaveChanges();

            var cities = new City[]
            {
                new City
                {
                    Name = "Kyiv",
                    Country = countries.First(c=>c.Name == "Ukraine"),
                    IsCapital=true,
                    Latitude= 50.45466M,
                    Longitude=  30.5238M
                },
                new City
                {
                    Name = "Lviv",
                    Country = countries.First(c=>c.Name == "Ukraine"),
                    IsCapital = false,
                    Latitude = 49.83826M,
                    Longitude = 24.02324M
                },
                new City
                {
                    Name = "Odessa",
                    Country = countries.First(c=>c.Name == "Ukraine"),
                    IsCapital = false,
                    Latitude = 46.47747M,
                    Longitude = 30.73262M
                },
                new City
                {
                    Name = "Prague",
                    Country = countries.First(c=>c.Name == "Czech Republic"),
                    IsCapital = true,
                    Latitude = 50.08804M,
                    Longitude = 14.42076M
                },
                new City
                {
                    Name = "Vienna",
                    Country = countries.First(c=>c.Name == "Austria"),
                    IsCapital = true,
                    Latitude = 48.20849M,
                    Longitude = 16.37208M
                },
                new City
                {
                    Name = "Salzburg",
                    Country = countries.First(c=>c.Name == "Austria"),
                    IsCapital = false,
                    Latitude = 47.79941M,
                    Longitude = 13.04399M
                }
            };

            context.Cities.AddRange(cities);

            context.SaveChanges();

            var reviews = new Review[]
            {
                new Review
                {
                    City = cities.First(c=>c.Name == "Kyiv"),
                    Person = people[0],
                    Rating = 5,
                    CreationDate=DateTime.Today.AddMonths(-12),
                    CityDescription="Beer, Beer, Vodka",
                    Comments = new List<Comment>
                    {
                        new Comment
                        {
                            Message="Nice",
                            Person=people[1],
                            PostDate = DateTime.Today.AddMonths(-9),
                        },
                        new Comment
                        {
                            Message="Agree",
                            Person=people[2],
                            PostDate = DateTime.Today.AddMonths(-6),
                        },
                        new Comment
                        {
                            Message="Yes",
                            Person=people[3],
                            PostDate = DateTime.Today.AddMonths(-3),
                        },
                    }
                },
                new Review
                {
                    City = cities.First(c=>c.Name == "Kyiv"),
                    Person = people[1],
                    Rating = 3,
                    CreationDate=DateTime.Today.AddMonths(-8),
                    CityDescription="Cheep",
                },
                new Review
                {
                    City = cities.First(c=>c.Name == "Lviv"),
                    Person = people[4],
                    Rating = 4,
                    CreationDate=DateTime.Today.AddMonths(-12),
                    CityDescription="Beautiful",
                },
                new Review
                {
                    City = cities.First(c=>c.Name == "Prague"),
                    Person = people[4],
                    Rating = 5,
                    CreationDate=DateTime.Today,
                    CityDescription="Europe",
                }
            };

            context.Reviews.AddRange(reviews);
            
            context.SaveChanges();
        }
    }

}
