using Northwind.Business.Abstract;
using Northwind.Business.Utilities;
using Northwind.Business.Validation.FluentValidation;
using Northwind.DataAccess.Abstract;
using Northwind.DataAccess.Concrete;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.Concrete
{
    public class ProductManager: IProductService
    {
        IProductDal productDal;

        public ProductManager(IProductDal productDal)
        {
            this.productDal = productDal;
        }

        public void Add(Product product)
        {
            ValidationTools.Validate(new ProductValidator(), product);
            productDal.Add(product);
        }

        public void Delete(Product selectedProduct)
        {
            
            productDal.Delete(selectedProduct);
        }

        public void Update(Product selectedProduct)
        {
            ValidationTools.Validate(new ProductValidator(), selectedProduct);
            productDal.Update(selectedProduct);
        }

        //productService kodu
        public List<Product> GetAll()
        {
            return productDal.GetAll();
        }

        public List<Product> GetProductsByCategory(int id)
        {
            return productDal.GetAll(p => p.CategoryId == id);
        }

        public List<Product> GetProductsByProductName(string text)
        {
            return productDal.GetAll(p => p.ProductName.ToLower().Contains(text.ToLower()));
        }

    }
}
