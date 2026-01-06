using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApiAdvance.DAL.EFcore;
using WebApiAdvance.DAL.Repositories.Abstract;
using WebApiAdvance.Entities.Common;

namespace WebApiAdvance.DAL.Repositories.Concrete.Efcore
{
    public class EfCategoryRepository : ICategoryRepository
    {
        private readonly ApiDbContext _context;

        public EfCategoryRepository(ApiDbContext context)
        {
            _context = context;
        }

        public Task AddCategoryAsync(Category category)
        {
            _context.Categories.AddAsync(category);
            return Task.CompletedTask;
        }

        public void DeleteCategory(Guid id)
        {
          var catagory = _context.Categories.Find(id);
                _context.Categories.Remove(catagory);
            

        }

        public Task<Category> Get(Expression<Func<Category, bool>> filter, params string[] includes)
        {
            IQueryable<Category> query = GetQuery(includes);
            return query.Where(filter).FirstOrDefaultAsync();
        }

        public Task<List<Category>> GetAllCategoriesAsync(Expression<Func<Category, bool>> filter = null, params string[] includes)
        {
            IQueryable<Category> query = GetQuery(includes);

            return filter == null
                ?query.ToListAsync()
                :query.Where(filter)
                .ToListAsync();

        }



        public Task<List<Category>> GetAllPaginatedAsync(int page, int size, Expression<Func<Category, bool>> filter = null, params string[] includes)
        {
            IQueryable<Category> query = GetQuery(includes);

            return filter == null
                ? query.ToListAsync()
                : query.Where(filter).Skip((page - 1) * size).Take(size)
                .ToListAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateCategory(Category category)
        {
           _context.Categories.Update(category);
        }

        private IQueryable<Category> GetQuery(string[] includes)
        {
            IQueryable<Category> query = _context.Categories;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query;
        }

    }
}
