using Sirenix.OdinInspector;
using UnityEngine;

namespace Elementary
{
    [AddComponentMenu("Elementary/States/State")]
    public class MonoState : MonoBehaviour
    {
        [Title("Methods")]
        [GUIColor(0, 1, 0)]
        [Button("Enter")]
        public virtual void Enter()
        {
        }

        [GUIColor(0, 1, 0)]
        [Button("Exit")]
        public virtual void Exit()
        {
        }
    }
}