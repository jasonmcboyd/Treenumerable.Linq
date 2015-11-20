using System.Collections.Generic;
using Treenumerable.Linq.TreeWalkers;

namespace Treenumerable.Linq
{
    internal class OrderedVirtualForest<T> : VirtualForest<T>, IOrderedVirtualForest<T>
    {
        public OrderedVirtualForest(
            ITreeWalker<T> treeWalker,
            IEqualityComparer<T> equalityComparer,
            CompoundComparer<T> childSorter,
            IEnumerable<T> roots)
            : base(new OrderChildrenByTreeWalker<T>(treeWalker, childSorter), equalityComparer, roots)
        {
            this._ChildSorter = childSorter;
            this._BaseTreeWalker = treeWalker;
        }

        private readonly CompoundComparer<T> _ChildSorter;
        private readonly ITreeWalker<T> _BaseTreeWalker;

        public IOrderedVirtualForest<T> CreateOrderedVirtualForest(IComparer<T> comparer)
        {
            return new OrderedVirtualForest<T>(
                this._BaseTreeWalker,
                this.Comparer,
                this._ChildSorter.CreateCompoundComparer(comparer),
                this.Roots);
        }
    }
}
