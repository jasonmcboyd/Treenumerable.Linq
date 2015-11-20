using System;
using System.Collections.Generic;
using System.Linq;

namespace Treenumerable.Linq.TreeWalkers
{
    internal class ScanTreeWalker<TBaseNode, TValue> : ITreeWalker<WrappedNode<TBaseNode, TValue>>
    {
        public ScanTreeWalker(
            ITreeWalker<TBaseNode> walker,
            Func<TBaseNode, TValue, TValue> accumulator,
            Func<TBaseNode, TValue, TValue> deccumulator)
        {
            this._Walker = walker;
            this._Accumulator = accumulator;
            this._Deccumulator = deccumulator;
        }

        private readonly ITreeWalker<TBaseNode> _Walker;
        private readonly Func<TBaseNode, TValue, TValue> _Accumulator;
        private readonly Func<TBaseNode, TValue, TValue> _Deccumulator;

        public IEnumerable<WrappedNode<TBaseNode, TValue>> GetAncestors(WrappedNode<TBaseNode, TValue> node)
        {
            return
                this
                ._Walker
                .GetAncestors(node.BaseNode)
                .Select(x =>
                    new WrappedNode<TBaseNode, TValue>(
                        x,
                        this._Deccumulator(x, node.Value)));
        }

        public IEnumerable<WrappedNode<TBaseNode, TValue>> GetChildren(WrappedNode<TBaseNode, TValue> node)
        {
            return
                this
                ._Walker
                .GetChildren(node.BaseNode)
                .Select(x =>
                    new WrappedNode<TBaseNode, TValue>(
                        x,
                        this._Accumulator(x, node.Value)));
        }
    }
}
