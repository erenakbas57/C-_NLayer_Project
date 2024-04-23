using Ninject.Modules;
using Northwind.Business.Abstract;
using Northwind.Business.Concrete;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete;
using Northwind.DataAccess.Concrete.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.DependencyResolvers.Ninject
{
    /*
     Dependency Injection (DI), Türkçe'ye "Bağımlılık Enjeksiyonu" olarak çevrilebilir. 
     Bu, bir yazılım bileşeninin, gereksinim duyduğu diğer bileşenleri 
     doğrudan oluşturmak yerine, dışarıdan bir kaynaktan (genellikle bir konteyner 
     veya bir yapılandırma dosyası) alması işlemidir.
     */
    public class BusinessModule : NinjectModule
    {
        // Load metodu, projenin başlangıcında çalıştırılır ve
        // projenin bağımlılıklarını çözümlemek için kullanılır.
        public override void Load()
        {
            // Bağlamanın yalnızca tek bir örneğinin oluşturulması gerektiğini
            // ve ardından sonraki tüm istekler için yeniden
            // kullanılması gerektiğini belirtir.
            Bind<IProductService>().To<ProductManager>().InSingletonScope(); // Bind metodu, bir türü bir uygulamaya bağlamak için kullanılır.
            Bind<ICategoryService>().To<CategoryManager>().InSingletonScope();

            Bind<IProductDal>().To<EfProductDal>().InSingletonScope();
            Bind<ICategoryDal>().To<EfCategoryDal>().InSingletonScope();
        }

    }
}
