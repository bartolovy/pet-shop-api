using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShop.Data.Models
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            var scopeeee = applicationBuilder.ApplicationServices.CreateScope();
            AppDbContext context = scopeeee.ServiceProvider.GetRequiredService<AppDbContext>();

            if (!context.Categories.Any())
                context.Categories.AddRange(Categories.Select(c => c.Value));

            if (!context.Products.Any())
                context.Products.AddRange(
                    new Product 
                    { 
                        Name = "Product 1",
                        Price = 12.95,
                        NumberOfItemsInStock = 8,
                        Category = Categories["Category 1"]
                    }, 
                    new Product
                    {
                        Name = "Product 2",
                        Price = 42.45,
                        NumberOfItemsInStock = 11,
                        Category = Categories["Category 1"]
                    },
                    new Product
                    {
                        Name = "Product 3",
                        Price = 2.45,
                        NumberOfItemsInStock = 1,
                        Category = Categories["Category 1"]
                    },
                    new Product
                    {
                        Name = "Product 4",
                        Price = 21.45,
                        NumberOfItemsInStock = 6,
                        Category = Categories["Category 1"]
                    },
                    new Product
                    {
                        Name = "Product 5",
                        Price = 200.45,
                        NumberOfItemsInStock = 21,
                        Category = Categories["Category 2"]
                    },
                    new Product
                    {
                        Name = "Product 6",
                        Price = 312.45,
                        NumberOfItemsInStock = 51,
                        Category = Categories["Category 2"]
                    },
                    new Product
                    {
                        Name = "Product 7",
                        Price = 428.45,
                        NumberOfItemsInStock = 19,
                        Category = Categories["Category 2"]
                    },
                    new Product
                    {
                        Name = "Product 8",
                        Price = 88.45,
                        NumberOfItemsInStock = 8,
                        Category = Categories["Category 3"]
                    },
                    new Product
                    {
                        Name = "Product 9",
                        Price = 66.45,
                        NumberOfItemsInStock = 6,
                        Category = Categories["Category 3"]
                    },
                    new Product
                    {
                        Name = "Product 10",
                        Price = 2.45,
                        NumberOfItemsInStock = 1,
                        Category = Categories["Category 4"]
                    },
                    new Product
                    {
                        Name = "Product 11",
                        Price = 56.45,
                        NumberOfItemsInStock = 111,
                        Category = Categories["Category 4"]
                    },
                    new Product
                    {
                        Name = "Product 12",
                        Price = 33.45,
                        NumberOfItemsInStock = 221,
                        Category = Categories["Category 4"]
                    },
                    new Product
                    {
                        Name = "Product 13",
                        Price = 78.45,
                        NumberOfItemsInStock = 21,
                        Category = Categories["Category 5"]
                    },
                    new Product
                    {
                        Name = "Product 14",
                        Price = 124.45,
                        NumberOfItemsInStock = 3,
                        Category = Categories["Category 5"]
                    },
                    new Product
                    {
                        Name = "Product 15",
                        Price = 231.45,
                        NumberOfItemsInStock = 9,
                        Category = Categories["Category 5"]
                    },
                    new Product
                    {
                        Name = "Product 16",
                        Price = 27.45,
                        NumberOfItemsInStock = 12,
                        Category = Categories["Category 6"]
                    },
                    new Product
                    {
                        Name = "Product 17",
                        Price = 72.45,
                        NumberOfItemsInStock = 3,
                        Category = Categories["Category 6"]
                    }
                    );

            context.SaveChanges();
        }
        private static Dictionary<string, Category> categories;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var genresList = new Category[]
                    {
                        new Category { Name = "Category 1"},
                        new Category { Name = "Category 2"},
                        new Category { Name = "Category 3"},
                        new Category { Name = "Category 4"},
                        new Category { Name = "Category 5"},
                        new Category { Name = "Category 6"}
                    };

                    categories = new Dictionary<string, Category>();

                    foreach (Category genre in genresList)
                    {
                        categories.Add(genre.Name, genre);
                    }
                }

                return categories;
            }
        }
    }
}
