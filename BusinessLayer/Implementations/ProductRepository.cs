using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Implementations
{
   public class ProductRepository : Repository
    {
       public ProductRepository (ApplicationContext context): base(context)
        {
        }
    }
}
