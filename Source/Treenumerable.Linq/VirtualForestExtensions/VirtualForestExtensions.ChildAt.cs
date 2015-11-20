using System.Linq;

namespace Treenumerable.Linq
{
    public static partial class VirtualForestExtensions
    {
        public static IVirtualForest<T> ChildAt<T>(
            this IVirtualForest<T> forest,
            int index)
        {
            return forest.ShallowCopy(roots => forest.TreeWalker.GetChildAt(roots, index));
        }
    }
}
