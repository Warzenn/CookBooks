using CookBook.Model;
using CookBook.Model.Enums;
using CookBooks.Data;
using CookBooks.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace CookBooks.Repository
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly ApplicationDbContext _context;

        public RecipeRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Recipe>> GetAll()
        {
            return await _context.Recipes.Include(i => i.Ingredients).Include(j => j.Instructions).ToListAsync();

        }

        public async Task<Recipe> GetByIdAsync(int id)
        {
            //return await _context.Recipes.Where(i => i.RecipeId == id).SingleOrDefaultAsync();
            return await _context.Recipes.Include(i => i.Ingredients).Include(j => j.Instructions).Where(i => i.Id  == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Recipe>> GetRecipeByCategory(RecipeCategory category)
        {
            return await _context.Recipes.Include(r => r.RecipeCategory).Where(i => i.RecipeCategory == category).ToListAsync();
        }

        public async Task<IEnumerable<Recipe>> GetRecipeByDifficulty(RecipeDifficultyLevel difficulty)
        {
            return await _context.Recipes.Include(r => r.RecipeDifficultyLevel).Where(i => i.RecipeDifficultyLevel == difficulty).ToListAsync();
        }

        public bool Add(Recipe recipe)
        {
            _context.Add(recipe);   // Generate SQL
            return Save();          // Send SQL to db
        }

        public bool Delete(Recipe recipe)
        {
            _context.Remove(recipe);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Recipe recipe)
        {
            _context.Update(recipe);
            return Save();
        }

       
    }
}
