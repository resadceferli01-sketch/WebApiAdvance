using WebApiAdvance.Core.DAL.Repositories.Concrete.EFCore;
using WebApiAdvance.DAL.EFcore;
using WebApiAdvance.Entities.Common;

namespace WebApiAdvance.DAL.Repositories.Concrete.Efcore
{
    public class EfProductRespository : EfBaseRepository<Product, ApiDbContext>
    {
        public EfProductRespository(ApiDbContext context) : base(context)
        {
        }
    }
}
