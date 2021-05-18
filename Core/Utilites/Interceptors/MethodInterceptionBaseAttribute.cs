
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilites.Interceptors
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method,AllowMultiple =true,Inherited =true)] //Classlar ve metodlar kullanabilsin. Birden fazla yazılabilir. Inherit edildiği alt classlar kullanabilsin
    public abstract class MethodInterceptionBaseAttribute:Attribute,IInterceptor
    {
        public int Priority { get; set; } //Hangisi önce çalışsın. (Loglama, Cache, Transaction gibi)

        public virtual void Intercept(IInvocation invocation) //Virtual yaptık. Değiştirebilmemiz için
        {
            
        }
    }
}

