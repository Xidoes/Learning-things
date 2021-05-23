using RestaurantAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext;
        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if(_dbContext.Database.CanConnect())        //Check if we're able to connect to database
            {
                if (!_dbContext.Restaurants.Any())                         //Check if restaurants table is empty
                {
                    var restaurants = GetRestaurants();
                    _dbContext.Restaurants.AddRange(restaurants);
                    _dbContext.SaveChanges();
                }
            }
        }
        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Name = "KFC",
                    Category = "Fast Food",
                    Description = "KFC (Kentucky Friec Chicken), American fast food chain",
                    ContactEmail = "contact@kfc.com",
                    HasDeliver = true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Nashville Hot Chicken",
                            Price = 10.30M,
                        },

                        new Dish()
                        {
                            Name = "Chicken Nuggets",
                            Price = 5.30M,
                        },
                    },
                    Address = new Address()
                    {
                        City = "Szczecin",
                        Street = "Niepodległości 15",
                        PostalCode = "70-001"
                    }

                },
                new Restaurant()
                {
                    Name = "McDonald",
                    Category = "Fast Food",
                    Description = "American fast food chain",
                    ContactEmail = "contact@mcdonald.com",
                    HasDeliver = true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "2forYou",
                            Price = 3.50M,
                        },

                        new Dish()
                        {
                            Name = "BigMac",
                            Price = 5.70M,
                        },
                    },
                    Address = new Address()
                    {
                        City = "Szczecin",
                        Street = "Niepodległości 16",
                        PostalCode = "70-002"
                    }

                },
                new Restaurant()
                {
                    Name = "Pizza Pasta i Basta",
                    Category = "Italian Food",
                    Description = "Local Pasta and Pizza restaurant",
                    ContactEmail = "contact@PPiB.com",
                    HasDeliver = true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Marinara",
                            Price = 18.90M,
                        },

                        new Dish()
                        {
                            Name = "Napoli",
                            Price = 25.90M,
                        },
                        new Dish()
                        {
                            Name = "Napolitana",
                            Price = 28.90M,
                        },
                        new Dish()
                        {
                            Name = "Tiramisu",
                            Price = 14.90M,
                        },
                    },
                    Address = new Address()
                    {
                        City = "Szczecin",
                        Street = "Klonowica",
                        PostalCode = "71-222"
                    }

                },
            };
            return restaurants;
        }
    }
}
