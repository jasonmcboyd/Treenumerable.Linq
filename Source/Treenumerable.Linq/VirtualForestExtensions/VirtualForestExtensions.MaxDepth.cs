using System;
using System.Linq;

namespace Treenumerable.Linq
{
    public static partial class VirtualForestExtensions
    {
        public static IVirtualForest<DepthNode<T>> MaxDepth<T>(
            this IVirtualForest<T> forest,
            long maxDepth)
        {
            return
                forest
                .ScanDepth()
                .Prune(x => x.Depth == maxDepth, PruneOption.PruneDescendants);
        }
    }
}