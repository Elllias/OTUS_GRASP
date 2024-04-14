using System.Collections.Generic;

namespace Lessons.Architecture.DI
{
    public interface IGameListenerProvider
    {
        IEnumerable<IGameListener> ProvideListeners();
    }
}