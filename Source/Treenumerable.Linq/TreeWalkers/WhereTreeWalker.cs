using System;
using System.Collections.Generic;
using System.Linq;

namespace Treenumerable.Linq.TreeWalkers
{
    internal class WhereTreeWalker<T> : ITreeWalker<T>
    {
        public WhereTreeWalker(ITreeWalker<T> walker, Func<T, bool> predicate)
        {
            this._Walker = walker;
            this._Predicate = predicate;
        }

        private readonly ITreeWalker<T> _Walker;
        private readonly Func<T, bool> _Predicate;
    
        public IEnumerable<T> GetAncestors(T node)
        {
            return 
                this
                ._Walker
                .GetAncestors(node)
                .Where(this._Predicate);
        }

        public IEnumerable<T> GetChildren(T node)
        {
            return
                this
                ._Walker
                .GetDescendants(node, this._Predicate);
                
        }
    }
}
