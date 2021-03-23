using Core.CrossCuttingConcerns;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection ;
using Core.Utilities.IoC;
using Castle.DynamicProxy;

namespace Core.Aspects.Caching
{
   public  class CacheRemoveAspect:MethodInterception
    {
        public string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
         }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
