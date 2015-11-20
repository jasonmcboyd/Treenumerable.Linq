using System.Linq;

namespace Treenumerable.Linq
{
    public static partial class VirtualForestExtensions
    {
        public static IVirtualForest<T> Level<T>(
            this IVirtualForest<T> forest,
            int depth)
        {
            return 
                forest
                .ShallowCopy(roots => 
                    roots
                    .SelectMany(x => 
                        forest
                        .TreeWalker
                        .GetLevel(x, depth)));
        }
    }
}
