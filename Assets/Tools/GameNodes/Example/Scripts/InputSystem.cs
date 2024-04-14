using UnityEngine;

namespace GameNodes
{
    public sealed class InputSystem
    {
        public bool GetKey(KeyCode keyCode)
        {
            return Input.GetKey(keyCode);
        }
    }
}