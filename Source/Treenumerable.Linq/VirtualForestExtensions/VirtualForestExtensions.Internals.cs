using System.Linq;
using Treenumerable.Linq.TreeWalkers;

namespace Treenumerable.Linq
{
    public static partial class VirtualForestExtensions
    {
        public static IVirtualForest<T> Internals<T>(this IVirtualForest<T> forest)
        {
            InternalsTreeWalker<T> walker = new InternalsTreeWalker<T>(forest.TreeWalker);

            return 
                forest
                .ShallowCopy(
                    walker, 
                    roots => 
                        roots
                        .Where(x => 
                            forest
                            .TreeWalker
                            .HasChildren(x)));
        }
    }
}
