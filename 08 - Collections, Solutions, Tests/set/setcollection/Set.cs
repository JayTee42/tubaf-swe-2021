using System;
using System.Collections.Generic;

namespace SetCollection
{
    public class Set<T> : ICollection<T>
    {
        private List<T> _list;

        // Properties of ICollection<T>:
        public int Count => _list.Count;
        public bool IsReadOnly => false;

        // Methods of ICollection<T>:
        public void Add(T item)
        {
            if (!Contains(item))
            {
                _list.Add(item);
            }
        }

        public void Clear() => _list.Clear();
        public bool Contains(T item) => _list.Contains(item);
        public void CopyTo(T[] a, int index) => _list.CopyTo(a, index);

        // Legacy (non-generic) version!
        // Explicit interface implementation:
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

        // Modern (generic) version!
        public IEnumerator<T> GetEnumerator() => _list.GetEnumerator();

        public bool Remove(T item) => _list.Remove(item);

        // Separate properties:
        public int Cardinality => Count;
        public bool IsEmpty => Count == 0;

        // Separate methods:
        public bool IsSubsetOf(Set<T> other)
        {
            foreach (var element in this)
            {
                if (!other.Contains(element))
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsTrueSubsetOf(Set<T> other) => IsSubsetOf(other) && (Count < other.Count);

        public Set<T> Intersect(Set<T> other)
        {
            var result = new Set<T>();

            foreach (var element in this)
            {
                if (other.Contains(element))
                {
                    result.Add(element);
                }
            }

            return result;
        }

        public Set<T> Union(Set<T> other)
        {
            var result = new Set<T>(this);

            foreach (var element in other)
            {
                result.Add(element);
            }

            return result;
        }

        public Set<T> Subtract(Set<T> other)
        {
            var result = new Set<T>();

            foreach (var element in this)
            {
                if (!other.Contains(element))
                {
                    result.Add(element);
                }
            }

            return result;
        }

        // Constructors:
        public Set() => _list = new List<T>();

        public Set(IEnumerable<T> other)
        {
            _list = new List<T>();

            foreach (var element in other)
            {
                Add(element);
            }
        }

        public Set(int capacity) => _list = new List<T>(capacity);

        public override bool Equals(object obj)
        {
            if (obj is Set<T> other)
            {
                return IsSubsetOf(other) && (Count == other.Count);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            var hc = 0;

            foreach (var element in this)
            {
                // XOR is commutative => the order of the elements does not matter.
                // We will get the same hash code for all permutations of a fixed base list.
                hc ^= element.GetHashCode();
            }

            return hc;
        }
    }
}
