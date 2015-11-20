using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Treenumerable.Linq.TreeWalkers
{
    internal class InternalsTreeWalker<T> : ITreeWalker<T>
    {
        public InternalsTreeWalker(ITreeWalker<T> walker)
        {
            this._Walker = walker;
        }

        private readonly ITreeWalker<T> _Walker;

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
                .GetChildren(
                    node, 
                    x => 
                        this
                        ._Walker
                        .HasChildren(x));
        }
    }
}
