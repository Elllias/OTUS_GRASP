using UnityEngine;

namespace Lessons.Architecture.Loading
{
    public sealed class AuthSocialStartable : IAppStartable
    {
        void IAppStartable.Start()
        {
            Social.localUser.Authenticate(success => Debug.Log($"LOAD SOCIAL {success}"));
        }
    }
}