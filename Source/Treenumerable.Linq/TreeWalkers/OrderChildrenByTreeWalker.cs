using System.Collections.Generic;
using System.Linq;

namespace Treenumerable.Linq.TreeWalkers
{
    internal class OrderChildrenByTreeWalker<T> : ITreeWalker<T>
    {
        public OrderChildrenByTreeWalker(
            ITreeWalker<T> walker,
            CompoundComparer<T> comparers)
        {
            this._Walker = walker;
            this._Comparers = comparers;
        }

        private readonly ITreeWalker<T> _Walker;
        private readonly CompoundComparer<T> _Comparers;

        public IEnumerable<T> GetAncestors(T node)
        {
            return
                this
                ._Walker
                .GetAncestors(node);
        }

        public IEnumerable<T> GetChildren(T node)
        {
            return
                this
                ._Walker
                .GetChildren(node)
                .OrderBy(x => x, this._Comparers);
        }
    }
}
