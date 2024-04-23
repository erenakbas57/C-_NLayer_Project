using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.DependencyResolvers.Ninject
{
    public class InstanceFactory
    {
        // GetInstance metodu, projenin başlangıcında çalıştırılır ve
        // projenin bağımlılıklarını çözümlemek için kullanılır.
        public static T GetInstance<T>()
        {
            var kernel = new StandardKernel(new BusinessModule()); // StandardKernel, bir modülü yüklemek için kullanılır.
            return kernel.Get<T>(); // Get metodu, bir türü çözümlemek için kullanılır.
        }
    }
}
