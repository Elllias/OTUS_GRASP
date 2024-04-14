using System;
using JetBrains.Annotations;

namespace Declarative
{
    [MeansImplicitUse]
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class SectionAttribute : Attribute
    {
    }
}