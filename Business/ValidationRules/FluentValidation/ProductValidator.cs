using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            //buradkai validationı product manager içinden çağırarak çalıştırıyoruz
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1); //.WithMessage("") diyerek burada özel mesajımı bastırmak için yazabiliriz.
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı"); //bu must kullanımı, hazırda olmayan bir kuralı eklemek istediğimizde kullandığımız komut.startwith a tamamen bize ait bir kural. onun methodunu oluşturmak gerekiyor.
        }

        private bool StartWithA(string arg)//arg gönderdiğimiz parametreyi, yani productname i temsil ediyor
        {
            return arg.StartsWith("A"); //bu fonskiyon bool tipinde olduğu için true yada false döndürmesi gerekiyor, ona göre bir kural yazıyoruz
        }
    }
}
