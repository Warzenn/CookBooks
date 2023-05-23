using CookBook.Model;
using CookBook.Model.Enums;
using CookBooks.Data;
using CookBooks.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Data
{
    public class Seed
    {
        public static async void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                var context = services.GetService<ApplicationDbContext>();
                var userManager = services.GetService<UserManager<AppUser>>();
                var roleManger = services.GetService<RoleManager<AppRole>>();

                if (await userManager.Users.AnyAsync()) return;

                var users = new List<AppUser>{
                    new AppUser{
                        Name= "John Wick",
                        UserName="john",
                        Email="xcvkp@example.com"
                    },
                    new AppUser{
                        Name= "Tom Cruise",
                        UserName="tom",
                        Email="tom@example.com"
                    },
                    new AppUser{
                        Name= "Billie Eilish",
                        UserName="bill",
                        Email="bill@example.com"
                    }
                };

                var roles = new List<AppRole>{
                    new AppRole{ Name = "Admin" },
                    new AppRole{ Name = "Member" }
                };

                foreach (var role in roles)
                {
                    await roleManger.CreateAsync(role);
                }

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "password");
                    await userManager.AddToRoleAsync(user, "Member");
                }

                var admin = new AppUser
                {
                    UserName = "admin",
                    Name = "Admin User"
                };

                await userManager.CreateAsync(admin, "adminpassword");
                await userManager.AddToRoleAsync(admin, "Admin");


                //context.Database.EnsureCreated();

                // if (!context.Recipes.Any())
                // {
                //     context.Recipes.AddRange(new List<Recipe>()
                //     {
                //         new Recipe()
                //         {
                //             Name = "Prvni recept",
                //             Description = "Super mnamka podavana na chlebu",
                //             Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                //             Rating = 10,
                //             CookTime = 120,
                //             Temperature = 200,
                //             Degree = Degree.Celsius,
                //             RecipeCategory = RecipeCategory.MainDishes,
                //             RecipeDifficultyLevel = RecipeDifficultyLevel.easy,

                //             Instructions = new List<Instructions>()
                //             {
                //                 new Instructions { Instruction = "Prvni instrukce 1" },
                //                 new Instructions { Instruction = "Druha instrukce 1" },
                //                 new Instructions { Instruction = "Treti instrukce 1" }
                //             },

                //             Ingredients = new List<Ingredients>()
                //             {
                //                 new Ingredients { Ingredient = "Prvni Ingredient 1" },
                //                 new Ingredients { Ingredient = "Druha Ingredient 1" },
                //                 new Ingredients { Ingredient = "Treti Ingredient 1" }
                //             }
                //         },

                //         new Recipe()
                //             {

                //                 Name = "Druhyrecept",
                //                 Description = "Super mnamka podavana na chlebu 2",
                //                 Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                //                 Rating = 10,
                //                 CookTime = 120,
                //                 Temperature = 200,
                //                 Degree = Degree.Celsius,
                //                 RecipeCategory = RecipeCategory.MainDishes,
                //                 RecipeDifficultyLevel = RecipeDifficultyLevel.easy,

                //                 Instructions = new List<Instructions>()
                //                 {
                //                     new Instructions { Instruction = "Prvni instrukce 2" },
                //                     new Instructions { Instruction = "Druha instrukce 2" },
                //                     new Instructions { Instruction = "Treti instrukce 2" }
                //                 },

                //                 Ingredients = new List<Ingredients>()
                //                 {
                //                     new Ingredients { Ingredient = "Prvni Ingredient 2" },
                //                     new Ingredients { Ingredient = "Druha Ingredient 2" },
                //                     new Ingredients { Ingredient = "Treti Ingredient 2" }
                //                 }
                //             },
                //         new Recipe()
                //             {

                //                 Name = "Treti recept",
                //                 Description = "Super mnamka podavana na chlebu 3",
                //                 Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                //                 Rating = 10,
                //                 CookTime = 20,
                //                 Temperature = 300,
                //                 Degree = Degree.Fahrenheit,

                //                 RecipeCategory = RecipeCategory.MainDishes,
                //                 RecipeDifficultyLevel = RecipeDifficultyLevel.easy,

                //                 Instructions = new List<Instructions>()
                //                 {
                //                     new Instructions { Instruction = "Prvni instrukce 3" },
                //                     new Instructions { Instruction = "Druha instrukce 3" },
                //                     new Instructions { Instruction = "Treti instrukce 3" }
                //                 },

                //                 Ingredients = new List<Ingredients>()
                //                 {
                //                     new Ingredients { Ingredient = "Prvni Ingredient 3" },
                //                     new Ingredients { Ingredient = "Druha Ingredient 3" },
                //                     new Ingredients { Ingredient = "Treti Ingredient 3" }
                //                 }


                //     } });
                // context.SaveChanges();
                // }
            }
        }
    }
}
