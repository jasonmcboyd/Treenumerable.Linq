using System;
using System.Collections.Generic;

namespace Treenumerable.Linq
{
    public static class VirtualForest
    {
        public static IVirtualForest<T> New<T>(
            ITreeWalker<T> treeWalker,
            IEnumerable<T> roots)
        {
            return new VirtualForest<T>(treeWalker, roots);
        }

        public static IVirtualForest<T> New<T>(
            ITreeWalker<T> treeWalker,
            IEqualityComparer<T> comparer,
            IEnumerable<T> roots)
        {
            return new VirtualForest<T>(treeWalker, comparer, roots);
        }

        public static IVirtualForest<T> New<T>(
            ITreeWalker<T> treeWalker,
            params T[] roots)
        {
            return new VirtualForest<T>(treeWalker, roots);
        }

        public static IVirtualForest<T> New<T>(
            ITreeWalker<T> treeWalker,
            IEqualityComparer<T> comparer,
            params T[] roots)
        {
            return new VirtualForest<T>(treeWalker, comparer, roots);
        }

        internal static IVirtualForest<T> ShallowCopy<T>(
            this IVirtualForest<T> source,
            Func<IEnumerable<T>, IEnumerable<T>> rootsSelector)
        {
            return new VirtualForest<T>(
                source.TreeWalker,
                source.Comparer,
                rootsSelector(source.Roots));
        }

        internal static IVirtualForest<T> ShallowCopy<T>(
            this IVirtualForest<T> source,
            ITreeWalker<T> treeWalker,
            Func<IEnumerable<T>, IEnumerable<T>> rootsSelector)
        {
            return new VirtualForest<T>(
                treeWalker,
                source.Comparer,
                rootsSelector(source.Roots));
        }
    }
}
