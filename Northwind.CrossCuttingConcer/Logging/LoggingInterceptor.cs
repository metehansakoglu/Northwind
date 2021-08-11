using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Extensions.Interception;

namespace Northwind.CrossCuttingConcer.Logging
{
    public class LoggingInterceptor:SimpleInterceptor
    {
        protected override void BeforeInvoke(IInvocation invocation)
        {
            //Loglama framework'ünün loglama işlemleri yapılacak.
          //  invocation.Request.Method.Name
            base.BeforeInvoke(invocation);
        }

        protected override void AfterInvoke(IInvocation invocation)
        {
            base.AfterInvoke(invocation);
        }
    }
}
