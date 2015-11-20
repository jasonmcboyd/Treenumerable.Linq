using System;
using System.Linq;
using Treenumerable.Linq.TreeWalkers;

namespace Treenumerable.Linq
{
    public static partial class VirtualForestExtensions
    {
        public static IVirtualForest<T> Prune<T>(
            this IVirtualForest<T> forest,
            Func<T, bool> predicate,
            PruneOption pruneOption)
        {
            PruneTreeWalker<T> walker = 
                new PruneTreeWalker<T>(
                    forest.TreeWalker, 
                    predicate, 
                    pruneOption);

            switch (pruneOption)
            {
                case PruneOption.PruneDescendants:
                    return
                        forest
                        .ShallowCopy(
                            walker,        
                            roots => roots);
                case PruneOption.PruneTree:
                    return 
                        forest
                        .ShallowCopy(
                            walker, 
                            roots => roots.Where(x => !predicate(x)));
                default:
                    throw new NotImplementedException("Whoops!  Somebody introduced a new pruning option and forgot to update the switch block.");
            }
        }
    }
}
