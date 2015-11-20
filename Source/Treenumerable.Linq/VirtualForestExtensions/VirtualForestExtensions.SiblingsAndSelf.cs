using System.Collections.Generic;
using System.Linq;

namespace Treenumerable.Linq
{
    public static partial class VirtualForestExtensions
    {
        public static IVirtualForest<T> SiblingsAndSelf<T>(this IVirtualForest<T> forest)
        {
            return 
                forest
                .ShallowCopy(roots => 
                    roots
                    .SelectMany(forest.TreeWalker.GetSiblingsAndSelf));
        }
    }
}
