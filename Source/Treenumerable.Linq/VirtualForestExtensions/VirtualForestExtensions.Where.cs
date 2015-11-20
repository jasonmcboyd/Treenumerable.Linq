using System;
using System.Linq;
using Treenumerable.Linq.TreeWalkers;

namespace Treenumerable.Linq
{
    public static partial class VirtualForestExtensions
    {
        public static IVirtualForest<T> Where<T>(
            this IVirtualForest<T> forest,
            Func<T, bool> predicate)
        {
            WhereTreeWalker<T> walker = new WhereTreeWalker<T>(forest.TreeWalker, predicate);

            return 
                forest
                .ShallowCopy(
                    walker, 
                    roots => 
                        roots
                        .SelectMany(x => 
                            predicate(x) ? 
                            new T[] { x } : 
                            walker.GetDescendants(x, predicate)));
        }
    }
}
