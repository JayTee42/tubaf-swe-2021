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
    }
}
