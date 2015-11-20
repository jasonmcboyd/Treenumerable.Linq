using System;
using System.Collections.Generic;

namespace Treenumerable.Linq
{
    internal class OrderByComparer<T, TKey> : IComparer<T>
    {
        public OrderByComparer(
            Func<T, TKey> keySelector,
            IComparer<TKey> comparer,
            bool descending)
        {
            this._KeySelector = keySelector;
            this._Comparer = comparer ?? Comparer<TKey>.Default;
            this._Descending = descending;
        }

        public readonly Func<T, TKey> _KeySelector;
        public readonly IComparer<TKey> _Comparer;
        public readonly bool _Descending;

        public int Compare(T x, T y)
        {
            if (this._Descending)
            {
                return this._Comparer.Compare(this._KeySelector(y), this._KeySelector(x));
            }
            else
            {
                return this._Comparer.Compare(this._KeySelector(x), this._KeySelector(y));
            }
        }
    }
}