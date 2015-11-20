using System;
using System.Collections.Generic;

namespace Treenumerable.Linq
{
    public static partial class VirtualForestExtensions
    {
        public static IOrderedVirtualForest<T> ThenChildrenBy<T, TKey>(
            this IOrderedVirtualForest<T> forest,
            Func<T, TKey> keySelector)
        {
            return
                forest
                .ThenChildrenBy(
                    keySelector,
                    Comparer<TKey>.Default);
        }

        public static IOrderedVirtualForest<T> ThenChildrenBy<T, TKey>(
            this IOrderedVirtualForest<T> forest,
            Func<T, TKey> keySelector,
            IComparer<TKey> comparer)
        {
            return
                forest
                .CreateOrderedVirtualForest(
                    new OrderByComparer<T, TKey>(
                        keySelector,
                        comparer,
                        false));
        } 
    }
}
