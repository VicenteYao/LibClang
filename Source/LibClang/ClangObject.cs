using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang
{
    public abstract class ClangObject : IDisposable
    {
        internal ClangObject()
        {

        }

        protected internal abstract ValueType Value { get; }

        protected virtual void Dispose()
        {

        }

        public override bool Equals(object obj)
        {
            if (obj is ClangObject)
            {
                ClangObject clangObject = obj as ClangObject;
                return this.EqualsCore(clangObject);
            }
            return false;
        }

        public static bool operator ==(ClangObject left, ClangObject right)
        {
            if ((object.ReferenceEquals(left, null) || object.ReferenceEquals(right, null)) && object.ReferenceEquals(left, right))
            {
                return true;
            }
            return left.Equals(right);
        }

        public static bool operator !=(ClangObject left, ClangObject right)
        {
            if ((object.ReferenceEquals(left, null) || object.ReferenceEquals(right, null)) && object.ReferenceEquals(left, right))
            {
                return false;
            }
            return !left.Equals(right);
        }

        protected virtual bool EqualsCore(ClangObject clangObject)
        {
            return this.Value.Equals(clangObject.Value);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        void IDisposable.Dispose()
        {
            this.Dispose();
        }
    }
}
