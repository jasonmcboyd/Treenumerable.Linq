using System.Collections.Generic;
using System.Linq;

namespace Treenumerable.Linq
{
    public static partial class VirtualForestExtensions
    {
        public static IVirtualForest<T> FollowingSiblings<T>(this IVirtualForest<T> forest)
        {
            return 
                forest
                .ShallowCopy(roots => 
                    roots
                    .SelectMany(y => 
                        forest
                        .TreeWalker
                        .GetFollowingSiblings(y, forest.Comparer)));
        }

        public static IVirtualForest<T> FollowingSiblings<T>(
            this IVirtualForest<T> forest,
            IEqualityComparer<T> comparer)
        {
            return new VirtualForest<T>(
                forest.TreeWalker,
                comparer,
                forest.Roots.SelectMany(x => 
                    forest
                    .TreeWalker
                    .GetFollowingSiblings(x, comparer)));
        }
    }
}
