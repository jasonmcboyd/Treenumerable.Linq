using System.Collections.Generic;

namespace Treenumerable.Linq
{
    public interface INode<T>
    {
        T Value { get; }
        INode<T> Parent { get; }
        bool HasParent { get; }
        IEnumerable<INode<T>> Children { get; }
    }
}
