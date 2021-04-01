using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))//gönderilen validatortype bir ivalidator değilse hata vermesi isteniyor
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        //reflection, birşeyleri çalışma anında çalıştırmak için kullanılır.Birşeyi newlerken runtime da yapmak istiyosan reflection kullanırsın, bunu reflection sağlar
        protected override void OnBefore(IInvocation invocation)//method interception içindeki onbefore methodu boş, dolayısıyla burada override yapıyoruz
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);//burası reflection
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
