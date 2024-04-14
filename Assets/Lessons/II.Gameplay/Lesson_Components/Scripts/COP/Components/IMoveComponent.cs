using UnityEngine;

namespace Lessons.Architecture.Components
{
    public interface IMoveComponent
    {
        void Move(Vector3 vector);
    }
}