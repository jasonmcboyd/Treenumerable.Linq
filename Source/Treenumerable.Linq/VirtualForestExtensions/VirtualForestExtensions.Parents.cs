using System.Linq;

namespace Treenumerable.Linq
{
    public static partial class VirtualForestExtensions
    {
        // TODO: what happens when two roots are siblings (have the same parent).
        // Should I deduplicate the results?  If so how?  Using an IEqualityComparer might cause
        // issues.
        public static IVirtualForest<T> Parents<T>(this IVirtualForest<T> forest)
        {
            return
                forest
                .ShallowCopy(roots =>
                    roots
                    .SelectMany(x =>
                        forest
                        .TreeWalker
                        .GetAncestors(x)
                        .Take(1)));
        }
    }
}
