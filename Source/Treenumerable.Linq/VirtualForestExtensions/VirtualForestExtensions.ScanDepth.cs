using System.Linq;
using Treenumerable.Linq.TreeWalkers;

namespace Treenumerable.Linq
{
    public static partial class VirtualForestExtensions
    {
        public static IVirtualForest<DepthNode<T>> ScanDepth<T>(this IVirtualForest<T> forest)
        {
            DepthTreeWalker<T> walker = new DepthTreeWalker<T>(forest.TreeWalker);

            return new VirtualForest<DepthNode<T>>(
                walker,
                forest.Roots.Select(x => new DepthNode<T>(x, 0)));
        }
    }
}
