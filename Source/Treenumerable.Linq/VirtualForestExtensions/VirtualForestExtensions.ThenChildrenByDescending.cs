using System;
using System.Collections.Generic;
using System.Linq;

namespace Treenumerable.Linq
{
    public static partial class VirtualForestExtensions
    {
        public static IOrderedVirtualForest<T> ThenChildrenByDescending<T, TKey>(
            this IOrderedVirtualForest<T> forest,
            Func<T, TKey> keySelector)
        {
            return
                forest
                .ThenChildrenBy(
                    keySelector,
                    null);
        }

        public static IOrderedVirtualForest<T> ThenChildrenByDescending<T, TKey>(
            this IOrderedVirtualForest<T> forest,
            Func<T, TKey> keySelector,
            IComparer<TKey> comparer)
        {
            return
                forest
                .CreateOrderedVirtualForest(
                    new OrderByComparer<T, TKey>(
                        keySelector,
                        comparer ?? Comparer<TKey>.Default,
                        true));
        } 
    }
}
