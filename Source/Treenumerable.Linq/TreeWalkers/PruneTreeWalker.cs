using System;
using System.Collections.Generic;
using System.Linq;

namespace Treenumerable.Linq.TreeWalkers
{
    internal class PruneTreeWalker<T> : ITreeWalker<T>
    {
        public PruneTreeWalker(
            ITreeWalker<T> walker,
            Func<T, bool> predicate,
            PruneOption pruneOption)
        {
            this._Walker = walker;
            this._Predicate = predicate;
            this._PruneOption = pruneOption;
        }

        private readonly ITreeWalker<T> _Walker;
        private readonly Func<T, bool> _Predicate;
        private readonly PruneOption _PruneOption;

        public IEnumerable<T> GetAncestors(T node)
        {
            return
                this
                ._Walker
                .GetAncestors(node);
        }

        public IEnumerable<T> GetChildren(T node)
        {
            switch (this._PruneOption)
            {
                case PruneOption.PruneDescendants:
                    if (this._Predicate(node))
                    {
                        return Enumerable.Empty<T>();
                    }
                    else
                    {
                        return
                            this
                            ._Walker
                            .GetChildren(node);
                    }
                case PruneOption.PruneTree:
                    return
                        this
                        ._Walker
                        .GetChildren(node, x => !this._Predicate(x));
                default:
                    throw new NotImplementedException("Whoops!  Somebody introduced a new pruning option and forgot to update the switch block.");
            }
        }
    }
}
