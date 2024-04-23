using FluentValidation;
using Northwind.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.Utilities
{
    // validator nesnesi ve entity nesnesi alır ve doğrulama yapar.
    // validator nesnesi nesne ye göre değişeceği için interface verdik.
    // entity nesnesine de her şeyi yollayabilmek için object verdik.
    public static class ValidationTools
    {
        public static void Validate(IValidator validator, object entity)
        {
            var validationContext = new ValidationContext<object>(entity);
            var result = validator.Validate(validationContext);
            if (result.Errors.Count > 0)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
