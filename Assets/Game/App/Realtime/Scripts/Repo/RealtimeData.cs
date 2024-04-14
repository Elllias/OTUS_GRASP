using System;
using UnityEngine;

namespace Game.App
{
    [Serializable]
    public struct RealtimeData
    {
        /// <summary>
        ///     <para>Current time in UTC.</para> 
        /// </summary>
        [SerializeField]
        public long nowSeconds;
    }
}