using System;
using JetBrains.Annotations;

namespace Lessons.Architecture.DI
{
    [MeansImplicitUse]
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Field)]
    public sealed class InjectAttribute : Attribute
    {
    }
}