using System.Collections.Generic;
using System.Linq;

namespace Treenumerable.Linq
{
    public static partial class VirtualForestExtensions
    {
        public static IVirtualForest<T> Siblings<T>(this IVirtualForest<T> forest)
        {
            return 
                forest
                .ShallowCopy(roots => 
                    roots
                    .SelectMany(forest.TreeWalker.GetSiblings));
        }

        public static IVirtualForest<T> Siblings<T>(this IVirtualForest<T> forest, IEqualityComparer<T> comparer)
        {
            return 
                forest
                .ShallowCopy(roots => 
                    roots
                    .SelectMany(x => 
                        forest
                        .TreeWalker
                        .GetSiblings(x, comparer)));
        }
    }
}
