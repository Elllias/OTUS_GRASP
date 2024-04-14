using System;
using JetBrains.Annotations;

namespace Lessons.Architecture.DI
{
    [MeansImplicitUse]
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class ListenerAttribute : Attribute
    {
    }
}