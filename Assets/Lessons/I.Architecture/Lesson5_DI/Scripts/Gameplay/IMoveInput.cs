using System;
using UnityEngine;

namespace Lessons.Architecture.DI
{
    public interface IMoveInput
    {
        event Action<Vector2> OnMove;
    }
}