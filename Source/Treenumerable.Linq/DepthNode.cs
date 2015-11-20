
namespace Treenumerable.Linq
{
    public class DepthNode<T>
    {
        public DepthNode(T baseNode, long depth)
        {
            this.BaseNode = baseNode;
            this.Depth = depth;
        }

        public T BaseNode { get; private set; }
        public long Depth{ get; private set; }
    }
}
