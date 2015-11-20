using System.Collections.Generic;
using System.Linq;

namespace Treenumerable.Linq.TreeWalkers
{
    internal class DepthTreeWalker<T> : ITreeWalker<DepthNode<T>>
    {
        public DepthTreeWalker(ITreeWalker<T> walker)
        {
            this._Walker = walker;
        }

        private readonly ITreeWalker<T> _Walker;

        public IEnumerable<DepthNode<T>> GetAncestors(DepthNode<T> node)
        {
            return
                this
                ._Walker
                .GetAncestors(node.BaseNode)
                .Select((x, i) => new DepthNode<T>(x, node.Depth - i - 1));
        }

        public IEnumerable<DepthNode<T>> GetChildren(DepthNode<T> node)
        {
            return
                this
                ._Walker
                .GetChildren(node.BaseNode)
                .Select(x => new DepthNode<T>(x, node.Depth + 1));
        }
    }
}
