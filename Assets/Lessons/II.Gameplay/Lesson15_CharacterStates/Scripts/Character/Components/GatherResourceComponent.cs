using System;
using Lessons.Gameplay.Interaction;
using Lessons.Utils;

namespace Lessons.Character.Components
{
    public interface IGatherResourceComponent
    {
        event Action<GatherResourceCommand> OnStopped;
        
        void StartGather(GatherResourceCommand command);
    }
    
    public sealed class GatherResourceComponent : IGatherResourceComponent
    {
        public event Action<GatherResourceCommand> OnStopped
        {
            add { this.process.OnStopped += value; }
            remove { this.process.OnStopped -= value; }
        }

        private readonly IAtomicProcess<GatherResourceCommand> process;

        public GatherResourceComponent(IAtomicProcess<GatherResourceCommand> process)
        {
            this.process = process;
        }

        public void StartGather(GatherResourceCommand command)
        {
            this.process.Start(command);
        }
    }
}