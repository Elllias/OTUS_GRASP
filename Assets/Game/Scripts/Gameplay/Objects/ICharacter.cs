using UnityEngine;

namespace SampleGame
{
    public interface ICharacter
    {
        void Move(Vector3 direction, float deltaTime);

        Vector3 GetPosition();
    }
}