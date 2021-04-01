using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Core.Utilities.Interceptors
{

    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            //classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger))); //loglama altyapısı hazır olduğu zaman, bu satır sayesinde tüm projenin loglanması sağlanır. 3 sene hiç log kullanmamışsan bile bu satır sayesinde tüm projenin logunu alabilirsin. Ama önce loglama altyapısını hazırlamak gerekiyor.

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
