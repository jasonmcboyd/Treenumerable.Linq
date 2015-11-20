using System;
using System.Collections.Generic;
using System.Linq;

namespace Treenumerable.Linq
{
    public static partial class VirtualForestExtensions
    {
        public static IEnumerable<TResult> Select<T, TResult>(
            this IVirtualForest<T> forest,
            Func<ITreeWalker<T>, T, TResult> selector)
        {
            return
                forest
                .Roots
                .Select(x => selector(forest.TreeWalker, x));
        }

        public static IEnumerable<TResult> Select<T, TResult>(
            this IVirtualForest<T> forest,
            Func<ITreeWalker<T>, T, int, TResult> selector)
        {
            return
                forest
                .Roots
                .Select((x, i) => selector(forest.TreeWalker, x, i));
        }
    }
}
