using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete.EF;
using Northwind.Entities.Abstract;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Concrete
{
    public class EfProductDal: EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {

        /*
        Burada aslında get, add, update kodları vardı ama IEntityRepository içine aldık
        ve oradan buraya miras aldık. Bu yüzden burada tekrar yazmamıza gerek kalmadı.
        varlık ve context tipini belirterek aldığımız için burada sadece Product tipini belirttik.
        Başka varlıklar(tablolar) için tekrar tekrar yazmamıza gerek kalmadı.
        */ 
       

    }
}
