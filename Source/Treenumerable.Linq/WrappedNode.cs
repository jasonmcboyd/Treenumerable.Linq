
namespace Treenumerable.Linq
{
    public class WrappedNode<TBaseNode, TValue>
    {
        public WrappedNode(TBaseNode baseNode, TValue value)
        {
            this.BaseNode = baseNode;
            this.Value = value;
        }

        public TBaseNode BaseNode { get; private set; }
        public TValue Value { get; private set; }
    }
}