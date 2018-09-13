﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang
{
    public abstract class ClangObject<T> : IDisposable where T : struct
    {
        protected ClangObject()
        {

        }

        protected internal virtual T Value { get; protected set; }

        protected virtual void Dispose()
        {

        }

        public override bool Equals(object obj)
        {
            if (obj is ClangObject<T>)
            {
                ClangObject<T> clangObject = obj as ClangObject<T>;
                return this.EqualsCore(clangObject);
            }
            return false;
        }

        public static bool operator ==(ClangObject<T> left, ClangObject<T> right)
        {
            if (object.ReferenceEquals(left, null) || object.ReferenceEquals(right, null))
            {
                return true;
            }

            return left.Equals(right);
        }

        public static bool operator !=(ClangObject<T> left, ClangObject<T> right)
        {
            if (object.ReferenceEquals(left, null) || object.ReferenceEquals(right, null))
            {
                return false;
            }
            return !left.Equals(right);
        }

        protected abstract bool EqualsCore(ClangObject<T> clangObject);

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