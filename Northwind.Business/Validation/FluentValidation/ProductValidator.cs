using FluentValidation;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.Validation.FluentValidation
{
    // ProductValidator, Product nesnesi için doğrulama kurallarını belirler.
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Ürün adı boş olamaz.");
            RuleFor(p => p.CategoryId).NotEmpty().WithMessage("Kategori boş olamaz.");
            RuleFor(p => p.QuantityPerUnit).NotEmpty().WithMessage("Birim fiyatı boş olamaz.");
            RuleFor(p => p.UnitPrice).NotEmpty().WithMessage("Fiyat boş olamaz.");
            RuleFor(p => p.UnitsInStock).NotEmpty().WithMessage("Stok adedi boş olamaz.");

            RuleFor(p => p.UnitPrice).GreaterThan(0).WithMessage("Fiyat 0'dan büyük olmalıdır.");
            RuleFor(p => p.UnitsInStock).GreaterThanOrEqualTo((short)0).WithMessage("Stok adedi 0'dan büyük olmalıdır.");
            RuleFor(p => p.QuantityPerUnit).Length(0, 20).WithMessage("Birim fiyatı en fazla 20 karakter olabilir.");

        }
    }
}
