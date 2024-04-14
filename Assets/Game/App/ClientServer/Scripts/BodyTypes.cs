// ReSharper disable UnassignedField.Global
// ReSharper disable NotAccessedField.Global

namespace Game.App
{
    public struct SignInRequest
    {
        public string userId;
        public string password;
    }

    public struct SignInResponse
    {
        public string token;
    }

    public struct SignUpResponse
    {
        public string userId;
        public string password;
        public string token;
    }
}