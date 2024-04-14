using Elementary;

namespace Game.GameEngine.Mechanics
{
    public sealed class Component_GetName : IComponent_GetName
    {
        public string Name
        {
            get { return this.name.Current; }
        }

        private readonly IValue<string> name;

        public Component_GetName(IValue<string> name)
        {
            this.name = name;
        }

        public Component_GetName(string name)
        {
            this.name = new Value<string>(name);
        }
    }
}