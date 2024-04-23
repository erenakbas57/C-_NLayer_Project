
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Abstract
{
    // Category nesnesi için veritabanı işlemlerini yapacak olan sınıf
    public interface ICategoryDal : IEntityRepository<Category>
    {

    }
}
