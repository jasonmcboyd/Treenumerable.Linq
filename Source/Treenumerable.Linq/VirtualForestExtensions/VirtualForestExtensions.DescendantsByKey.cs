using System.Collections.Generic;

namespace Treenumerable.Linq
{
    public static partial class VirtualForestExtensions
    {
        public static IVirtualForest<T> Descendants<T>(
            this IVirtualForest<T> forest,
            T key)
        {
            return forest.ShallowCopy(roots => forest.TreeWalker.GetDescendants(roots, key, forest.Comparer));
        }

        public static IVirtualForest<T> Descendants<T>(
            this IVirtualForest<T> forest,
            T key,
            IEqualityComparer<T> comparer)
        {
            return new VirtualForest<T>(
                forest.TreeWalker,
                comparer,
                forest.TreeWalker.GetDescendants(forest.Roots, key, comparer));
        }
    }
}
