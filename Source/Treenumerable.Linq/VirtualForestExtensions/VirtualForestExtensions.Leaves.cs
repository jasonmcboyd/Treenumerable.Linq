using System.Linq;

namespace Treenumerable.Linq
{
    public static partial class VirtualForestExtensions
    {
        public static IVirtualForest<T> Leaves<T>(this IVirtualForest<T> forest)
        {
            return 
                forest
                .ShallowCopy(roots => roots.SelectMany(forest.TreeWalker.GetLeaves));
        }
    }
}
