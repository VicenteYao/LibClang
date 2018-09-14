using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LibClang
{
    public abstract class ClangObjectList<TItem,TValue> : ClangObject<TValue>, IReadOnlyList<TItem> where TValue:struct
    {
        protected ClangObjectList()
        {

        }


        private Dictionary<int, TItem> itemsDict;

        public TItem this[int index]
        {
            get
            {
                return GetItemAt(index);
            }
        }

        private TItem GetItemAt(int index)
        {
            this.EnsureItemDictionary();
            if (!this.itemsDict.ContainsKey(index))
            {
                TItem item = this.EnsureItemAt(index);
                this.itemsDict.Add(index, item);
            }
            return this.itemsDict[index];
        }

        private void EnsureItemDictionary()
        {
            if (this.Count > 0 && this.itemsDict == null)
            {
                this.itemsDict = new Dictionary<int, TItem>(this.Count);
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
            internal Enumerable(ClangObjectList<TItem, TValue> clangObjectList)
            {
                this.clangObjectList = clangObjectList;
                this.index = -1;
            }

            private ClangObjectList<TItem, TValue> clangObjectList;
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
