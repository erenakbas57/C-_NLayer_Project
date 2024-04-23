using Northwind.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataAccess.Abstract
{
    /*
    Dal nesneleri interface kullanırken şart koyduk.
    sınıf olması ve new'lenebilir olması gerektiğini belirttik. IEntity'den türeyen sınıflar olması şartı var
    Her dal nesnesi için tekrar tekrar yazmak yerine T tipi belirtip base sınıf yazdık. 
    */
    public interface IEntityRepository<T> where T:class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        
    }
}
