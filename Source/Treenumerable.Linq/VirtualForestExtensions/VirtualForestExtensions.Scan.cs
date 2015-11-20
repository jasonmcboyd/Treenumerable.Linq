using System;
using System.Linq;
using Treenumerable.Linq.TreeWalkers;

namespace Treenumerable.Linq
{
    public static partial class VirtualForestExtensions
    {
        public static IVirtualForest<WrappedNode<TBaseNode, TValue>> Scan<TBaseNode, TValue>(
            this IVirtualForest<TBaseNode> forest,
            Func<TBaseNode, TValue> seedFactory,
            Func<TBaseNode, TValue, TValue> accumulator,
            Func<TBaseNode, TValue, TValue> deccumulator)
        {
            ScanTreeWalker<TBaseNode, TValue> walker = 
                new ScanTreeWalker<TBaseNode, TValue>(
                    forest.TreeWalker, 
                    accumulator, 
                    deccumulator);
            
            return new VirtualForest<WrappedNode<TBaseNode, TValue>>(
                walker,
                forest.Roots.Select(x => new WrappedNode<TBaseNode, TValue>(x, seedFactory(x))));
        }

        public static IVirtualForest<WrappedNode<TBaseNode, TValue>> Scan<TBaseNode, TValue>(
            this IVirtualForest<TBaseNode> forest,
            TValue seed,
            Func<TBaseNode, TValue, TValue> accumulator,
            Func<TBaseNode, TValue, TValue> deccumulator)
        {
            ScanTreeWalker<TBaseNode, TValue> walker =
                new ScanTreeWalker<TBaseNode, TValue>(
                    forest.TreeWalker,
                    accumulator,
                    deccumulator);

            return new VirtualForest<WrappedNode<TBaseNode, TValue>>(
                walker,
                forest.Roots.Select(x => new WrappedNode<TBaseNode, TValue>(x, seed)));
        }

    }
}
