using System;
using System.Collections.Generic;
using System.Linq;

namespace Treenumerable.Linq
{
    public static partial class VirtualForestExtensions
    {
        public static IEnumerable<TResult> SelectMany<T, TResult>(
            this IVirtualForest<T> forest,
            Func<ITreeWalker<T>, T, IEnumerable<TResult>> selector)
        {
            return
                forest
                .Roots
                .SelectMany(x => selector(forest.TreeWalker, x));
        }

        public static IEnumerable<TResult> SelectMany<T, TResult>(
            this IVirtualForest<T> forest,
            Func<ITreeWalker<T>, T, int, IEnumerable<TResult>> selector)
        {
            return
                forest
                .Roots
                .SelectMany((x, i) => selector(forest.TreeWalker, x, i));
        }
    }
}
