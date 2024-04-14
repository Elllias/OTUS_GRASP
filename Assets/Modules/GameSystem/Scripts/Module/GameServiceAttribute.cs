using System;
using JetBrains.Annotations;

namespace GameSystem
{
    ///FOR ADVANCED GAME ARCHITECTURE
    [MeansImplicitUse(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.Access)]
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class GameServiceAttribute : Attribute
    {
    }
}