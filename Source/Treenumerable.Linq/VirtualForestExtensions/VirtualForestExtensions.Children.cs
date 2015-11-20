using System;
using System.Linq;

namespace Treenumerable.Linq
{
    public static partial class VirtualForestExtensions
    {
        public static IVirtualForest<T> Children<T>(
            this IVirtualForest<T> forest,
            Func<T, bool> predicate)
        {
            return forest.ShallowCopy(roots => forest.TreeWalker.GetChildren(roots, predicate));
        }

        public static IVirtualForest<T> Children<T>(this IVirtualForest<T> forest)
        {
            return forest.ShallowCopy(roots => roots.SelectMany(forest.TreeWalker.GetChildren));
        }
    }
}
