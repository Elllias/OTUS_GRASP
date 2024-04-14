using System;
using System.Collections.Generic;

namespace AI.Iterators
{
    public static class IteratorFactory
    {
        public static IEnumerator<T> CreateIterator<T>(IteratorMode mode, T[] points)
        {
            if (mode == IteratorMode.CIRCLE)
            {
                return new CircleIterator<T>(points);
            }

            if (mode == IteratorMode.YOYO)
            {
                return new YoyoIterator<T>(points);
            }

            if (mode == IteratorMode.ONCE)
            {
                return new OnceIterator<T>(points);
            }

            throw new Exception($"Iterator {mode} is not found!");
        }
    }
}