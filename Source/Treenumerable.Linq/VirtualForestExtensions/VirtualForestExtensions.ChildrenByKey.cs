using System.Collections.Generic;
using System.Linq;

namespace Treenumerable.Linq
{
    public static partial class VirtualForestExtensions
    {
        public static IVirtualForest<T> Children<T>(
            this IVirtualForest<T> forest,
            T key)
        {
            return forest.ShallowCopy(roots => roots.Where(y => forest.Comparer.Equals(key, y)));
        }

        public static IVirtualForest<T> Children<T>(
            this IVirtualForest<T> forest,
            T key,
            IEqualityComparer<T> comparer)
        {
            return new VirtualForest<T>(
                forest.TreeWalker,
                comparer,
                forest.Roots.Where(x => comparer.Equals(key, x)));
        }
    }
}
