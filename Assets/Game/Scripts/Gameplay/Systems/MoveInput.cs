using UnityEngine;

namespace SampleGame
{
    public sealed class MoveInput : IMoveInput
    {
        private readonly InputConfig config;
        
        public MoveInput(InputConfig config)
        {
            this.config = config;
        }
        
        public Vector3 GetDirection()
        {
            Vector3 direction = Vector3.zero;
            
            if (Input.GetKey(config.forward))
            {
                direction.z = 1;
            }
            else if (Input.GetKey(config.back))
            {
                direction.z = -1;
            }

            if (Input.GetKey(config.left))
            {
                direction.x = -1;
            }
            else if (Input.GetKey(config.right))
            {
                direction.x = 1;
            }

            return direction;
        }
    }
}