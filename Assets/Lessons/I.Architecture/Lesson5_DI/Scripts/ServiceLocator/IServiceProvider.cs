using System;
using System.Collections.Generic;

namespace Lessons.Architecture.DI
{
    public interface IServiceProvider
    {
        IEnumerable<(Type, object)> ProvideServices();
    }
}