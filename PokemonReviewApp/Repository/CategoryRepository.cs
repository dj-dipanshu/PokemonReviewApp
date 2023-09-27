using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
           _context = context;
        }
        public bool CategoryExists(int CategoryId)
        {
            return _context.Categories.Any(c => c.Id == CategoryId);
        }

        public bool CreateCategory(Category category)
        {
            //Change Tracker
            // add, updating, modifying,
            // connected vs disconnect
            // EntityState.Added 
            _context.Categories.Add(category);
            return Save();
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.Where(c => c.Id == id).FirstOrDefault();
        }

        public ICollection<Pokemon> GetPokemonByCategory(int CategoryId)
        {
            return _context.PokemonCategories.Where(c => c.CategoryID == CategoryId).Select(c => c.Pokemon).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
