using CookBook.Model;
using CookBook.Model.Enums;
using System.Threading.Tasks.Sources;

namespace CookBooks.Interfaces
{
    public interface IRecipeRepository
    {
        Task<IEnumerable<Recipe>> GetAll();
        Task<Recipe> GetByIdAsync (int id);
        Task<IEnumerable<Recipe>> GetRecipeByCategory(RecipeCategory category);
        Task<IEnumerable<Recipe>> GetRecipeByDifficulty(RecipeDifficultyLevel difficulty);

        bool Add(Recipe recipe);
        bool Update(Recipe recipe);
        bool Delete(Recipe recipe);
        bool Save();



    }
}
