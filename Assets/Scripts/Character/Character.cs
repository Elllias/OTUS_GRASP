using APIs;
using Atomic.Elements;
using Atomic.Objects;
using UnityEngine;

namespace Character
{
    public class Character : AtomicEntity
    {
        [SerializeField] private CharacterCore _characterCore;
        
        [Get(CharacterAPI.MOVE_DIRECTION)]
        private AtomicVariable<Vector3> _moveDirection;

        private void Awake()
        {
            _characterCore.Construct(this);
        }

        private void Update()
        {
            _characterCore.Update(Time.deltaTime);
        }
    }
}
