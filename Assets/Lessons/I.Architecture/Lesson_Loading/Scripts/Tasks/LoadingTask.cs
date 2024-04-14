using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Lessons.Architecture.Loading
{
    public abstract class LoadingTask : ScriptableObject
    {
        public abstract UniTask<Result> Do();
        
        public struct Result
        {
            public bool success;
            public string error;
        }
    }
}