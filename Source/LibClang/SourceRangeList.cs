using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class SourceRangeList:ClangObject<CXSourceRangeList>, IReadOnlyList<SourceRange>
    {
        internal SourceRangeList(CXSourceRangeList sourceRangeList)
        {

            this.Value = sourceRangeList;
        }

        private Dictionary<int, SourceRange> _sourceRanges;

        public SourceRange this[int index]
        {
            get
            {
                if (index < 0 || index > this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return this.getSourceRange(index);
            }
        }

        private void EnsureSourceRanges()
        {
            if (this._sourceRanges == null)
            {
                this._sourceRanges = new Dictionary<int, SourceRange>(this.Count);
            }
        }

        private unsafe SourceRange getSourceRange(int index)
        {
            this.EnsureSourceRanges();
            SourceRange sourceRange = null;
            if (this._sourceRanges.ContainsKey(index))
            {
                sourceRange = this._sourceRanges[index];
            }
            else
            {
                sourceRange = new SourceRange(this.Value.ranges[index]);
                this._sourceRanges.Add(index, sourceRange);
            }
            return sourceRange;
        }

        public int Count
        {
            get
            {
                return (int)this.Value.count;
            }
        }

        public IEnumerator<SourceRange> GetEnumerator()
        {
            this.EnsureSourceRanges();
            for (int i = 0; i < this.Count; i++)
            {
                this.getSourceRange(i);
            }
            return this._sourceRanges.Values.GetEnumerator();
        }

        protected unsafe override void Dispose()
        {
            clang.clang_disposeSourceRangeList((IntPtr)this.Value.ranges);
        }

        protected unsafe override bool EqualsCore(ClangObject<CXSourceRangeList> clangObject)
        {
            return this.Value.ranges == clangObject.Value.ranges;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
