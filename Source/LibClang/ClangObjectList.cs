using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LibClang
{
    public abstract class ClangObjectList<TItem> : ClangObject, IReadOnlyList<TItem> where TItem:class
    {
        protected ClangObjectList()
        {

        }


        private Dictionary<int, TItem> _items;

        public TItem this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new IndexOutOfRangeException();
                }
                return GetItemAt(index);
            }
        }

        private TItem GetItemAt(int index)
        {
            this.EnsureItemDictionary();
            TItem item = null;
            if (!this._items.ContainsKey(index))
            {
                item = this.EnsureItemAt(index);
                this._items.Add(index, item);
            }
            else
            {
                item = this._items[index];
            }
            return item;
        }

        private void EnsureItemDictionary()
        {
            if (this.Count > 0 && this._items == null)
            {
                this._items = new Dictionary<int, TItem>(this.Count);
            }
        }

        public int Count
        {
            get {
                return this.GetCountCore();
            }
        }

        protected abstract int GetCountCore();

        protected abstract TItem EnsureItemAt(int index);

        public IEnumerator<TItem> GetEnumerator()
        {
            return new Enumerable(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public struct Enumerable : IEnumerator<TItem>
        {
            internal Enumerable(ClangObjectList<TItem> clangObjectList)
            {
                this.clangObjectList = clangObjectList;
                this.index = -1;
            }

            private ClangObjectList<TItem> clangObjectList;
            private int index;

            public TItem Current { get { return this.clangObjectList[this.index]; } }

            object IEnumerator.Current { get { return this.Current; } }

            public void Dispose()
            {

            }

            public bool MoveNext()
            {
                if (this.index + 1 > this.clangObjectList.Count - 1)
                {
                    return false;
                }
                this.index++;
                return true;
            }

            public void Reset()
            {
                this.index = -1;
            }
        }

    }
}
