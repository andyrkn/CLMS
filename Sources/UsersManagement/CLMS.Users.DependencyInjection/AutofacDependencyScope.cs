using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using CLMS.Users.CrossCuttingConcerns;
using EnsureThat;

namespace CLMS.Users.DependencyInjection
{
    public class AutofacDependencyScope : IDependencyScope
    {
        private readonly ILifetimeScope scope;

        public AutofacDependencyScope(ILifetimeScope scope)
        {
            EnsureArg.IsNotNull(scope);
            this.scope = scope;
        }

        public T Resolve<T>()
        {
            return scope.Resolve<T>();
        }

        public IEnumerable<T> ResolveAll<T>()
            where T : class
        {
            return scope.Resolve<IEnumerable<T>>();
        }

        public IEnumerable<T> ResolveWhere<T>(Func<Type, bool> typePredicate) where T : class
        {
            return ResolveAll<T>().Where(t => typePredicate(t.GetType()));
        }

        public object Resolve(Type serviceType)
        {
            return scope.Resolve(serviceType);
        }
    }
}