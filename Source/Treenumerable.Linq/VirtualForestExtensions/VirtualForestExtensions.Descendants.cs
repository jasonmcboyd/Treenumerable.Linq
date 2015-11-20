using System;
using System.Collections.Generic;
using System.Linq;

namespace Treenumerable.Linq
{
    public static partial class VirtualForestExtensions
    {
        public static IVirtualForest<T> Descendants<T>(
            this IVirtualForest<T> forest,
            Func<T, bool> predicate)
        {
            return forest.ShallowCopy(roots => forest.TreeWalker.GetDescendants(roots, predicate));
        }
    }
}
