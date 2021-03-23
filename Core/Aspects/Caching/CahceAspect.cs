using Core.CrossCuttingConcerns;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Core.Utilities.IoC;
using Castle.DynamicProxy;
using System.Linq;

namespace Core.Aspects.Caching
{
    public class CahceAspect:MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManeger;

        public CahceAspect(int duration=60)
        {
            _duration = duration;
            _cacheManeger = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }
        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            if (_cacheManeger.IsAdd(key))
            {
                invocation.ReturnValue = _cacheManeger.Get(key);
            }
            invocation.Proceed();
            _cacheManeger.Add(key, invocation.ReturnValue, _duration);
        }
    }
}
