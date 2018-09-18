namespace LibClang
{
    using System;

    /// <summary>
    /// Defines the <see cref="ClangObject" />
    /// </summary>
    public abstract class ClangObject 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClangObject"/> class.
        /// </summary>
        internal ClangObject()
        {
        }

        /// <summary>
        /// Gets the Value
        /// </summary>
        protected internal abstract ValueType Value { get; }

        /// <summary>
        /// The Dispose
        /// </summary>
        protected virtual void DisposeCore()
        {
        }

        /// <summary>
        /// The Equals
        /// </summary>
        /// <param name="obj">The obj<see cref="object"/></param>
        /// <returns>The <see cref="bool"/></returns>
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
        /// <summary>
        /// The EqualsCore
        /// </summary>
        /// <param name="clangObject">The clangObject<see cref="ClangObject"/></param>
        /// <returns>The <see cref="bool"/></returns>
        protected virtual bool EqualsCore(ClangObject clangObject)
        {
            return this.Value.Equals(clangObject.Value);
        }

        /// <summary>
        /// The GetHashCode
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        ~ClangObject()
        {
            this.DisposeCore();
        }
    }
}
