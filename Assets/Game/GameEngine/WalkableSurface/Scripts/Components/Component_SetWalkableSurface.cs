using Elementary;

namespace Game.GameEngine
{
    public sealed class Component_SetWalkableSurface : IComponent_SetWalkableSurface
    {
        private readonly IVariable<IWalkableSurface> variable;

        public Component_SetWalkableSurface(IVariable<IWalkableSurface> variable)
        {
            this.variable = variable;
        }

        public void SetSurface(IWalkableSurface surface)
        {
            this.variable.Current = surface;
        }
    }
}