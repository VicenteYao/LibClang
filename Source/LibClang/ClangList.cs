namespace LibClang
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="ClangList{TItem}" />
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    public abstract class ClangList<TItem> : ClangObject, IReadOnlyList<TItem> where TItem : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClangList{TItem}"/> class.
        /// </summary>
        internal ClangList()
        {
        }

        internal void Clear()
        {
            if (this._items != null && this._items.Count > 0)
            {
                this._items.Clear();
            }
        }

        /// <summary>
        /// Defines the _items
        /// </summary>
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
        /// <summary>
        /// The GetItemAt
        /// </summary>
        /// <param name="index">The index<see cref="int"/></param>
        /// <returns>The <see cref="TItem"/></returns>
        private TItem GetItemAt(int index)
        {
            this.EnsureItemsContainer();
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

        /// <summary>
        /// The EnsureItemDictionary
        /// </summary>
        private void EnsureItemsContainer()
        {
            if (this.Count > 0 && this._items == null)
            {
                this._items = new Dictionary<int, TItem>(this.Count);
            }
        }

        /// <summary>
        /// Gets the Count
        /// </summary>
        public int Count
        {
            get
            {
                return this.GetCountCore();
            }
        }

        /// <summary>
        /// The GetCountCore
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        protected abstract int GetCountCore();

        /// <summary>
        /// The EnsureItemAt
        /// </summary>
        /// <param name="index">The index<see cref="int"/></param>
        /// <returns>The <see cref="TItem"/></returns>
        protected abstract TItem EnsureItemAt(int index);

        /// <summary>
        /// The GetEnumerator
        /// </summary>
        /// <returns>The <see cref="IEnumerator{TItem}"/></returns>
        public IEnumerator<TItem> GetEnumerator()
        {
            return new Enumerable(this);
        }

        /// <summary>
        /// The GetEnumerator
        /// </summary>
        /// <returns>The <see cref="IEnumerator"/></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// Defines the <see cref="Enumerable" />
        /// </summary>
        private struct Enumerable : IEnumerator<TItem>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref=""/> class.
            /// </summary>
            /// <param name="clangList">The clangObjectList<see cref="ClangList{TItem}"/></param>
            internal Enumerable(ClangList<TItem> clangList)
            {
                this.clangObjectList = clangList;
                this.index = -1;
            }

            /// <summary>
            /// Defines the clangObjectList
            /// </summary>
            private ClangList<TItem> clangObjectList;

            /// <summary>
            /// Defines the index
            /// </summary>
            private int index;

            /// <summary>
            /// Gets the Current
            /// </summary>
            public TItem Current
            {
                get { return this.clangObjectList[this.index]; }
            }

            /// <summary>
            /// Gets the Current
            /// </summary>
            object IEnumerator.Current
            {
                get { return this.Current; }
            }

            /// <summary>
            /// The Dispose
            /// </summary>
            public void Dispose()
            {
            }

            /// <summary>
            /// The MoveNext
            /// </summary>
            /// <returns>The <see cref="bool"/></returns>
            public bool MoveNext()
            {
                if (this.index + 1 > this.clangObjectList.Count - 1)
                {
                    return false;
                }
                this.index++;
                return true;
            }

            /// <summary>
            /// The Reset
            /// </summary>
            public void Reset()
            {
                this.index = -1;
            }
        }
    }
}
