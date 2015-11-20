using System;
using System.Collections.Generic;

namespace Treenumerable.Linq
{
    public class VirtualForest<T> : IVirtualForest<T>
    {
        public VirtualForest(ITreeWalker<T> treeWalker, IEnumerable<T> roots) 
            : this(treeWalker, null, roots)
        {
            if (treeWalker == null)
            {
                throw new ArgumentNullException("treeWalker");
            }
            
            this.TreeWalker = treeWalker;
            this.Roots = roots;
        }

        public VirtualForest(
            ITreeWalker<T> treeWalker,
            IEqualityComparer<T> comparer,
            IEnumerable<T> roots)
        {
            if (treeWalker == null)
            {
                throw new ArgumentNullException("treeWalker");
            }

            this.TreeWalker = treeWalker;
            this.Roots = roots;
            this.Comparer = comparer ?? EqualityComparer<T>.Default;
        }

        public VirtualForest(ITreeWalker<T> treeWalker, params T[] roots)
            : this(treeWalker, null, roots)
        {
            if (treeWalker == null)
            {
                throw new ArgumentNullException("treeWalker");
            }

            this.TreeWalker = treeWalker;
            this.Roots = roots;
        }

        public VirtualForest(
            ITreeWalker<T> treeWalker,
            IEqualityComparer<T> comparer,
            params T[] roots)
        {
            if (treeWalker == null)
            {
                throw new ArgumentNullException("treeWalker");
            }

            this.TreeWalker = treeWalker;
            this.Roots = roots;
            this.Comparer = comparer ?? EqualityComparer<T>.Default;
        }

        public ITreeWalker<T> TreeWalker { get; private set; }

        public IEnumerable<T> Roots { get; private set; }

        public IEqualityComparer<T> Comparer { get; private set; }

        public IVirtualForest<T> this[T key]
        {
            get 
            {
                return this.Children(key);
            }
        }

        public IVirtualForest<T> this[int index]
        {
            get
            {
                return this.ChildAt(index);
            }
        }
    }
}
