using System.Collections.Generic;
namespace Treenumerable.Linq
{
    public interface IOrderedVirtualForest<T> : IVirtualForest<T>
    {
        IOrderedVirtualForest<T> CreateOrderedVirtualForest(IComparer<T> comparer);
    }
}
