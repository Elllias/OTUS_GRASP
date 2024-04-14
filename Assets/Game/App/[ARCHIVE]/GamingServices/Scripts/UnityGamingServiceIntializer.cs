using System;
using Unity.Services.Core;
using Unity.Services.Core.Environments;

namespace Game.App
{
    public sealed class UnityGamingServiceIntializer
    {
        private const string k_Environment = "production";
       
        public void Initialize(Action onSuccess, Action onError)
        {
            try
            {
                var options = new InitializationOptions()
                    .SetEnvironmentName(k_Environment);
                
                UnityServices
                    .InitializeAsync(options)
                    .ContinueWith(_ => onSuccess());
            }
            catch (Exception)
            {
                onError();
            }
        }
    }
}