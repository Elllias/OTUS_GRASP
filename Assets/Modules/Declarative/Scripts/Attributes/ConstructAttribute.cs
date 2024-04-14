using System;
using JetBrains.Annotations;

namespace Declarative
{
    [MeansImplicitUse]
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class ConstructAttribute : Attribute
    {
    }
}