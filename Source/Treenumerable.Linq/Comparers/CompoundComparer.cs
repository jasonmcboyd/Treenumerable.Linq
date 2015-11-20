using System;
using System.Collections.Generic;

namespace Treenumerable.Linq
{
    internal class CompoundComparer<T> : IComparer<T>
    {
        public CompoundComparer(params IComparer<T>[] comparers)
        {
            this._Comparers = comparers;
        }

        private readonly IComparer<T>[] _Comparers;

        public CompoundComparer<T> CreateCompoundComparer(IComparer<T> comparer)
        {
            IComparer<T>[] comparers = new IComparer<T>[this._Comparers.Length + 1];
            Array.Copy(this._Comparers, comparers, this._Comparers.Length);
            comparers[comparers.Length - 1] = comparer;
            return new CompoundComparer<T>(comparers);
        }

        public int Compare(T x, T y)
        {
            int comparison;
            for (int i = 0; i < this._Comparers.Length - 1; i++)
            {
                comparison = this._Comparers[i].Compare(x, y);
                if (comparison != 0)
                {
                    return comparison;
                }
            }
            return this._Comparers[this._Comparers.Length - 1].Compare(x, y);
        }
    }
}
