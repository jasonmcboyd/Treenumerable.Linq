using System.Collections.Generic;

namespace Treenumerable.Linq
{
    public interface IVirtualForest<T>
    {
        ITreeWalker<T> TreeWalker { get; }
        IEnumerable<T> Roots { get; }
        IEqualityComparer<T> Comparer { get; }
        IVirtualForest<T> this[T key] { get; }
        IVirtualForest<T> this[int index] { get; }
    }
}
