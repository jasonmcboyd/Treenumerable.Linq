using System;
using System.Collections.Generic;

namespace Treenumerable.Linq
{
    public static partial class VirtualForestExtensions
    {
        public static IOrderedVirtualForest<T> OrderChildrenBy<T, TKey>(
            this IVirtualForest<T> forest,
            Func<T, TKey> keySelector)
        {
            return forest.OrderChildrenBy(keySelector, null);
        }

        public static IOrderedVirtualForest<T> OrderChildrenBy<T, TKey>(
            this IVirtualForest<T> forest,
            Func<T, TKey> keySelector,
            IComparer<TKey> comparer)
        {
            return
                new OrderedVirtualForest<T>(
                    forest.TreeWalker,
                    forest.Comparer,
                    new CompoundComparer<T>(
                        new OrderByComparer<T, TKey>(
                            keySelector, 
                            comparer ?? Comparer<TKey>.Default, 
                            false)),
                    forest.Roots);
        }
    }
}
