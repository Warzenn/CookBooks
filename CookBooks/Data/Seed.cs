using CookBook.Model;
using CookBook.Model.Enums;
using CookBooks.Data;
using CookBooks.Model;

namespace CookBook.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.Recipes.Any())
                {
                    context.Recipes.AddRange(new List<Recipe>()
                    {
                        new Recipe()
                        {
                            Name = "Prvni recept",
                            Description = "Super mnamka podavana na chlebu",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Rating = 10,
                            Category = RecipeCategory.MainDishes,
                            RecipeDifficultyLevel = RecipeDifficultyLevel.easy,

                            Instructions = new List<Instructions>()
                            {
                                new Instructions {Instruction = "Prvni instukce"},
                                new Instructions {Instruction = "Druha instrukce"},
                                new Instructions {Instruction = "Treti instrukce"}
                            },

                            Ingredients = new List<Ingredients>()
                            {
                                new Ingredients {Ingredient = "1/2 vejce 1"},
                                new Ingredients {Ingredient = "1/2 mouky 1"},
                                new Ingredients {Ingredient = "1/2 vody 1"}
                            }

                        },

                        new Recipe()
                            {

                                Name = "Druhyrecept",
                                Description = "Super mnamka podavana na chlebu 2",
                                Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                                Rating = 10,
                                Category = RecipeCategory.MainDishes,
                                RecipeDifficultyLevel = RecipeDifficultyLevel.easy,

                                Instructions = new List<Instructions>()
                                   {
                                    new Instructions {Instruction = "Prvni 2 instukce"},
                                    new Instructions {Instruction = "Druha 2 instrukce"},
                                    new Instructions {Instruction = "Treti 2 instrukce"}
                                },
                                Ingredients = new List<Ingredients>()
                                {
                                new Ingredients {Ingredient = "1/2 vejce 1"},
                                new Ingredients {Ingredient = "1/2 mouky 1"},
                                new Ingredients {Ingredient = "1/2 vody 1"}
                                }
                            },
                        new Recipe()
                            {

                                Name = "Treti recept",
                                Description = "Super mnamka podavana na chlebu 3",
                                Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                                Rating = 10,
                                Category = RecipeCategory.MainDishes,
                                RecipeDifficultyLevel = RecipeDifficultyLevel.easy,

                                Instructions = new List<Instructions>()
                                   {
                                    new Instructions {Instruction = "Prvni 3 instukce"},
                                    new Instructions {Instruction = "Druha 3 instrukce"},
                                    new Instructions {Instruction = "Treti 3 instrukce"}
                                },

                                Ingredients = new List<Ingredients>()
                                {
                                new Ingredients {Ingredient = "1/2 vejce 1"},
                                new Ingredients {Ingredient = "1/2 mouky 1"},
                                new Ingredients {Ingredient = "1/2 vody 1"}
                                }
                            },
                    }); ;
                    context.SaveChanges();
                }
            }
        }
    }
}