using DataLayer;

namespace BusinessLayer.Implementations
{
    public class ProductRepository : Repository
    {
       public ProductRepository (ApplicationContext context): base(context)
        {
        }
    }
}
