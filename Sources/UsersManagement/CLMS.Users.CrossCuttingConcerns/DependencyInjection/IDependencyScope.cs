using System;
using System.Collections.Generic;

namespace CLMS.Users.CrossCuttingConcerns
{
    public interface IDependencyScope
    {
        T Resolve<T>();

        IEnumerable<T> ResolveAll<T>()
            where T : class;

        IEnumerable<T> ResolveWhere<T>(Func<Type, bool> typePredicate)
            where T : class;

        object Resolve(Type serviceType);
    }
}