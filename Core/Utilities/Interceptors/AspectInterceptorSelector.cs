using Castle.DynamicProxy;
using Core.Aspects.Autofac.Performance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute> //retrieve all class attributes
               (true).ToList();
            var methodAttributes = type.GetMethod(method.Name) //retrieve all method attributes
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
            classAttributes.AddRange(methodAttributes); //add method attributes to class attributes list.
            classAttributes.Add(new PerformanceAspect(5)); //send me a warning if any method's execution process takes longer than 5 sec.
            /* classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));*/ //involve all log actions to system automatically.

            return classAttributes.OrderBy(x => x.Priority).ToArray(); //return attributes by priority number 


        }
    }
}
