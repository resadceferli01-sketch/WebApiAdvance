using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApiAdvance.Core.DAL.Repositories.Concrete.EFCore;
using WebApiAdvance.DAL.EFcore;
using WebApiAdvance.DAL.Repositories.Abstract;
using WebApiAdvance.Entities.Common;

namespace WebApiAdvance.DAL.Repositories.Concrete.Efcore
{
    public class EfCategoryRepository : EfBaseRepository<Category, ApiDbContext>
    {
        public EfCategoryRepository(ApiDbContext context) : base(context)
        {
        }
    }

}
