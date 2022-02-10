using Castle.DynamicProxy;
using Core.CrossCuttingConcern.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Caching
{

    //WHEN CacheRemoveAspect works ? When you update/delete/change your data. 
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        //we have to declare CacheRemoveAspect before our manipulative methods: Add,Delete,Update etc.
        public CacheRemoveAspect(string pattern) //For instance: ICarService.Get(), removes all caches that involve "Get" keyword. GetAll,GetById..etc.
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();//comes from Microsoft.Extensions.DependencyInjection.
        }


        //explanation: For instance, in ProductManager.cs file, use Add() method and add a new product.
        //Do not remove the former CacheAspect until our Add() method throws an extension. 
        //Because we only remove CacheAspect when there is a change taking place in our data.
        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
