using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Core.Aspects.Transaction
{
  public   class TranscationScopeAspect:MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
          using(TransactionScope transcationScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();
                    transcationScope.Complete();
                }
                catch (System.Exception e)
                {
                    transcationScope.Dispose();
                    throw;
                }
            }
        }
    }
}
